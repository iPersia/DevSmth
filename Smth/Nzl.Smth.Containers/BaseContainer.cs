﻿namespace Nzl.Smth.Containers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.ComponentModel;
    using Nzl.Web.Page;
    using Nzl.Web.Util;
    using Nzl.Smth.Common;
    using Nzl.Smth.Controls;
    using Nzl.Smth.Utils;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Logger;
    using Nzl.Utils;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    delegate TBaseControl CreateControlCallback<TBaseControl, TBaseItem>(TBaseItem item);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ctl"></param>
    /// <param name="item"></param>
    delegate void InitializeControlCallback<TBaseControl, TBaseItem>(TBaseControl ctl, TBaseItem item);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ctl"></param>
    delegate void UpdateViewCallback<TBaseControl>(TBaseControl ctl);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ctl"></param>
    delegate void InitializeContainerCallback(bool isAppend);



    /// <summary>
    /// 
    /// </summary>
    public class BaseContainer<TBaseControl, TBaseItem> : UserControl
        where TBaseControl : BaseControl<TBaseItem>
        where TBaseItem : BaseItem
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> OnWorkerFailed;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> OnWorkerCancelled;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private UrlInfo<TBaseControl, TBaseItem> _urlInfo = new UrlInfo<TBaseControl, TBaseItem>();

        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.BackgroundWorker bwFetchPage;

        /// <summary>
        /// 
        /// </summary>
        private object _isDoingWorkLocker = new object();

        /// <summary>
        /// 
        /// </summary>
        private int _margin = 4;

        /// <summary>
        /// 
        /// </summary>
        private bool _isWorkCompleted = false;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public BaseContainer()
            : base()
        {
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Panel container = this.GetContainer();
            if (container != null)
            {
                container.Width = this.Width - 10;
                ///Prevent the three time loading of the FetchPage function.
                if (this._isWorkCompleted)
                {
                    this.SetUrlInfo(false);
                    this.FetchPage();
                }
            }
        }
        #endregion

        #region virtual
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        protected virtual Panel GetContainer()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCurrentUrl()
        {
            return this._urlInfo.BaseUrl + "?p=" + this._urlInfo.Index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string GetUrl(UrlInfo<TBaseControl, TBaseItem> info)
        {
            return info.BaseUrl + "?p=" + info.Index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected virtual void DoWork(UrlInfo<TBaseControl, TBaseItem> info)
        {
            this.UpdatePageInfo(info.WebPage, info);
            info.Result = this.GetItems(info.WebPage);
            info.Controls = this.PrepareControls(info.Result);
#if (X)
            System.Diagnostics.Debug.WriteLine("BaseContainer - DoWork - " + info.BaseUrl);
            System.Diagnostics.Debug.WriteLine("BaseContainer - DoWork - this.IsHandleCreated - " + this.IsHandleCreated);
#endif
            if (info.Controls != null && info.Controls.Count > 0)
            {
                if (this.IsHandleCreated)
                {
                    if (this.InvokeRequired)
                    {
                        System.Threading.Thread.Sleep(0);
                        this.Invoke(new InitializeContainerCallback(InitializeContainer), new object[] { info.IsAppend });
                        System.Threading.Thread.Sleep(0);
                    }
                }
                
                this.UpdateView(info.Controls);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctls"></param>
        protected void UpdateView(IList<TBaseControl> ctls)
        {
            foreach (TBaseControl ctl in ctls)
            {
                if (this.IsHandleCreated)
                {
                    if (this.InvokeRequired)
                    {
                        System.Threading.Thread.Sleep(0);
                        this.Invoke(new UpdateViewCallback<TBaseControl>(AddControl), new object[] { ctl });
                        System.Threading.Thread.Sleep(0);
                    }
                }
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InitializeContainer(bool isAppend)
        {
            Panel container = GetContainer();
            if (container != null)
            {
                lock (container)
                {
                    if (isAppend == false)
                    {
                        container.Location = new Point(container.Location.X, this._margin);
                        container.Height = 3;
                        foreach (Control ctl in container.Controls)
                        {
                            TBaseControl bc = ctl as TBaseControl;
                            if (bc != null)
                            {
                                this.RecylingControl(bc);
                            }
                        }

                        container.Controls.Clear();
                        GC.Collect();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual TBaseControl GetRecycledControl()
        {
            return RecycledQueues.GetRecycled<TBaseControl>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        protected virtual void RecylingControl(TBaseControl ctl)
        {
            RecycledQueues.AddRecycled<TBaseControl>(ctl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <returns></returns>
        protected virtual bool CheckAddingControl(TBaseControl ctl)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        protected virtual void AddControl(TBaseControl ctl)
        {
            Panel container = GetContainer();
            if (container != null)
            {
                lock (container)
                {
                    if (CheckAddingControl(ctl))
                    {
                        int accumulateHeight = container.Height - 3;
                        ctl.Top = accumulateHeight + 1;
                        ctl.Left = 1;
                        this.SetControl(ctl, container.Controls.Count % 2 == 0);
                        container.Controls.Add(ctl);
                        accumulateHeight += ctl.Height + 1;
                        container.Height = accumulateHeight + 3;

#if (DEBUG)
                        System.Diagnostics.Debug.WriteLine("BaseContainer - AddControl - container.Controls.Count is " + container.Controls.Count);
#endif

#if (X)
                        Nzl.Web.Util.CommonUtil.ShowMessage(this, "\tBaseContainer - AddControl\n" +
                                                                  "\t\t" + _urlInfo.BaseUrl + " - accumulateHeight:" + accumulateHeight + "\n" +
                                                                  "\t\t" + _urlInfo.BaseUrl + " - ctl name:" + ctl.Name);
#endif
                    }
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected virtual IList<TBaseItem> GetItems(WebPage wp)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected virtual bool CheckPage(WebPage wp, UrlInfo<TBaseControl, TBaseItem> info)
        {
            if (wp == null)
            {
                info.Status = PageStatus.TimeOut;
                return false;
            }

            if (wp != null && wp.IsGood)
            {
                info.Status = PageStatus.Normal;
                if (wp.Html.Contains("<div class=\"sp hl f\">您无权阅读此版面</div>"))
                {
                    info.Status = PageStatus.AccessRestricted;
                    return false;
                }

                if (wp.Html.Contains("<div class=\"sp hl f\">指定的版面不存在</div>") ||
                    wp.Html.Contains("<div class=\"sp hl f\">指定的文章不存在或链接错误</div>"))
                {
                    info.Status = PageStatus.NotFound;
                    return false;
                }

                return true;
            }

            info.Status = PageStatus.UnKnown;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected virtual void WorkCompleted(UrlInfo<TBaseControl, TBaseItem> info)
        {
            if (info != null)
            {
                if (info.Status == PageStatus.Normal)
                {
                    LogStatus.Instance.UpdateLoginStatus(info.WebPage);
                }
                else
                {
                    Panel container = this.GetContainer();
                    if (container != null)
                    {
                        container.Controls.Clear();
                        Label lbl = new Label();
                        lbl.AutoSize = true;
                        lbl.Text = MiscUtil.GetEnumDescription(info.Status);
                        container.Controls.Add(lbl);
                        lbl.Top = 30;
                        lbl.Left = (container.Width - lbl.Width) / 2;
                        container.Height = 60 + lbl.Height;
                        container.Top = 4;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        protected virtual void SetControlEnabled(bool flag)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <returns></returns>
        protected virtual TBaseControl CreateControl(TBaseItem item)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected virtual void InitializeControl(TBaseControl ctl, TBaseItem item)
        {
            if (ctl != null)
            {
                ctl.Initialize(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        protected virtual void SetControl(TBaseControl ctl, bool oeFlag)
        {
            if (oeFlag)
            {
                ctl.BackColor = Color.White;
            }
            else
            {
                ctl.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        protected virtual void UpdateProgress(int proc)
        {
            ///Noting to do.
        }
        #endregion

        #region protected
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        protected void SetBaseUrl(string baseUrl)
        {
            this._urlInfo.BaseUrl = baseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetUrlInfo(int index, bool isAppend)
        {
            this._urlInfo.Index = index;
            this._urlInfo.IsAppend = isAppend;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetUrlInfo(bool isAppend)
        {
            this._urlInfo.IsAppend = isAppend;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        private IList<TBaseItem> PrepareInfos(UrlInfo<TBaseControl, TBaseItem> info)
        {
            return info.Result as IList<TBaseItem>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private void UpdatePageInfo(WebPage wp, UrlInfo<TBaseControl, TBaseItem> info)
        {
            if (wp != null)
            {
                MatchCollection mtCollection = CommonUtil.GetMatchCollection(@"<a class=\Wplant\W>(?'Current'\d+)/(?'Total'\d+)</a>", wp.Html);
                if (mtCollection.Count == 2)
                {
                    this._urlInfo.Index = System.Convert.ToInt32(mtCollection[0].Groups[1].Value);
                    this._urlInfo.Total = System.Convert.ToInt32(mtCollection[0].Groups[2].Value);

                    info.Index = System.Convert.ToInt32(mtCollection[0].Groups[1].Value);
                    info.Total = System.Convert.ToInt32(mtCollection[0].Groups[2].Value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listThread"></param>
        private IList<TBaseControl> PrepareControls(IList<TBaseItem> list)
        {
            IList<TBaseControl> listThreacControl = new List<TBaseControl>();
            foreach (TBaseItem item in list)
            {
                TBaseControl ctl = this.GetControl(item);
                if (ctl != null)
                {
                    listThreacControl.Add(ctl);
                }
            }
#if (DEBUG)
            System.Diagnostics.Debug.WriteLine("BaseContainer - PrepareControls - TBaseControl count is " + list.Count);
#endif
            return listThreacControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected TBaseControl GetControl(TBaseItem item)
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    TBaseControl ctl = this.GetRecycledControl();
                    if (ctl == null)
                    {
#if (DEBUG)
                        System.Diagnostics.Debug.WriteLine("BaseContainer - GetControl - GetRecycledControl failed, type is " + typeof(TBaseControl).ToString());
#endif
                        System.Threading.Thread.Sleep(0);
                        object obj = this.Invoke(new CreateControlCallback<TBaseControl,TBaseItem>(CreateControl), new object[] { item });
                        System.Threading.Thread.Sleep(0);
                        ctl = obj as TBaseControl;
                    }
                    
                    if (ctl != null)
                    {
                        if (this.IsHandleCreated)
                        {
                            if (this.InvokeRequired)
                            {
                                System.Threading.Thread.Sleep(0);
                                this.Invoke(new InitializeControlCallback<TBaseControl, TBaseItem>(InitializeControl), new object[] { ctl, item });
                                System.Threading.Thread.Sleep(0);
                            }
                        }

                        return ctl;
                    }
                }
            }

            return null;
        }
        #endregion

        #region FetchPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwFetchPage_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            lock (this._isDoingWorkLocker)
            {
                try
                {
                    UrlInfo<TBaseControl, TBaseItem> urlInfo = e.Argument as UrlInfo<TBaseControl, TBaseItem>;
                    if (CheckPage(urlInfo.WebPage, urlInfo))
                    {
                        e.Result = urlInfo;
                        DoWorkBase(e);
                    }

                    MessageQueue.Enqueue(MessageFactory.CreateMessage(this.Text == null ? this.GetType().ToString() : this.Text,
                                                                      Nzl.Utils.MiscUtil.GetEnumDescription(urlInfo.Status) + " The page is '" + this.GetUrl(urlInfo) + "'!"));
                    e.Result = urlInfo;
                }
                catch (Exception exp)
                {
                    if (Logger.Enabled)
                    {
                        Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                    }

                    (e.Argument as UrlInfo<TBaseControl, TBaseItem>).Status = PageStatus.UnKnown;
                    MessageQueue.Enqueue(MessageFactory.CreateMessage(exp));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state">State is DoWorkEventArgs!</param>
        protected void DoWorkBase(object state)
        {
            DoWorkEventArgs e = state as DoWorkEventArgs;
            try
            {
                UrlInfo<TBaseControl, TBaseItem> urlInfo = e.Result as UrlInfo<TBaseControl, TBaseItem>;
                if (urlInfo != null)
                {
                    DoWork(urlInfo);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception exp)
            {
                e.Cancel = true;
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(this.ToString() + "\t" + exp.Message + "\n" + exp.StackTrace);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwFetchPage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    WorkFailedBase(e);
                }
                else if (e.Cancelled)
                {
                    WorkCancelledBase(e);
                }
                else
                {
                    WorkCompletedBase(e);
                }

                this._isWorkCompleted = true;
                this.SetControlEnabled(true);
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state">State is RunWorkerCompletedEventArgs!</param>
        protected void WorkCompletedBase(RunWorkerCompletedEventArgs e)
        {
            UrlInfo<TBaseControl, TBaseItem> urlInfo = e.Result as UrlInfo<TBaseControl, TBaseItem>;
            if (urlInfo != null)
            {
                WorkCompleted(urlInfo);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state">State is RunWorkerCompletedEventArgs!</param>
        protected void WorkCancelledBase(RunWorkerCompletedEventArgs e)
        {
            this.WorkCancelled(e.Error != null ? e.Error.Message : "Work is cancelled!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state">State is RunWorkerCompletedEventArgs!</param>
        protected void WorkFailedBase(RunWorkerCompletedEventArgs e)
        {
            this.WorkCancelled(e.Error != null ? e.Error.Message : "Work is failed!");
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchPage()
        {
            UrlInfo<TBaseControl, TBaseItem> info = new UrlInfo<TBaseControl, TBaseItem>(this._urlInfo);
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchPrevPage()
        {
            UrlInfo<TBaseControl, TBaseItem> info = new UrlInfo<TBaseControl, TBaseItem>(this._urlInfo);
            info.Index = this._urlInfo.Index - 1;
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchNextPage()
        {
            UrlInfo<TBaseControl, TBaseItem> info = new UrlInfo<TBaseControl, TBaseItem>(this._urlInfo);
            info.Index = this._urlInfo.Index + 1;
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchLastPage()
        {
            UrlInfo<TBaseControl, TBaseItem> info = new UrlInfo<TBaseControl, TBaseItem>(this._urlInfo);
            info.Index = this._urlInfo.Total;
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchPage(UrlInfo<TBaseControl, TBaseItem> urlInfo)
        {
            if (urlInfo.Index > 0 && urlInfo.Index <= urlInfo.Total && string.IsNullOrEmpty(urlInfo.BaseUrl) == false)
            {
                PageLoader pl = new PageLoader(this.GetUrl(urlInfo));
                pl.Tag = urlInfo;
                pl.PageLoaded += new EventHandler(PageLoader_PageLoaded);
                PageDispatcher.Instance.Add(pl);
#if (X)
                Nzl.Web.Util.CommonUtil.ShowMessage(this, "BaseContainer - FetchPage(UrlInfo's index is equal to " + urlInfo.Index + ")!");
#endif
                SetControlEnabled(false);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageLoader_PageLoaded(object sender, EventArgs e)
        {
            PageLoader pl = sender as PageLoader;
            if (pl != null)
            {
                WebPage wp = pl.GetResult() as WebPage;
                if (wp != null && wp.IsGood)
                {
                    UrlInfo<TBaseControl, TBaseItem> info = pl.Tag as UrlInfo<TBaseControl, TBaseItem>;
                    info.WebPage = wp;
                    if (this.IsHandleCreated)
                    {
                        if (this.InvokeRequired)
                        {
                            System.Threading.Thread.Sleep(0);
                            this.Invoke(new PageLoadedCallback(PageLoaded), new object[] { info });
                            System.Threading.Thread.Sleep(0);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void PageLoaded(object pageInfor)
        {
            UrlInfo<TBaseControl, TBaseItem> info = pageInfor as UrlInfo<TBaseControl, TBaseItem>;
            this.bwFetchPage = new System.ComponentModel.BackgroundWorker();
            this.bwFetchPage.DoWork += new System.ComponentModel.DoWorkEventHandler(bwFetchPage_DoWork);
            this.bwFetchPage.ProgressChanged += BwFetchPage_ProgressChanged;
            this.bwFetchPage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bwFetchPage_RunWorkerCompleted);
            this.bwFetchPage.WorkerReportsProgress = true;
            this.bwFetchPage.RunWorkerAsync(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwFetchPage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void WorkFailed(string msg)
        {
            if (this.OnWorkerFailed != null)
            {
                this.OnWorkerFailed(this, new MessageEventArgs(msg));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void WorkCancelled(string msg)
        {
            if (this.OnWorkerCancelled != null)
            {
                this.OnWorkerCancelled(this, new MessageEventArgs(msg));
            }
        }
        #endregion
    }
}
