﻿namespace Nzl.Web.Smth.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.ComponentModel;
    using Nzl.Web.Page;
    using Nzl.Web.Util;
    using Nzl.Web.Smth.Utils;
    using Nzl.Web.Smth.Datas;
    using Nzl.Web.Smth.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public delegate Control CreateControlCallback(BaseItem item);

    /// <summary>
    /// 
    /// </summary>
    public class BaseControl : UserControl
    {
        #region variable
        /// <summary>
        /// 
        /// </summary>
        private UrlInfo _urlInfo = new UrlInfo();

        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.BackgroundWorker bwFetchPage;

        /// <summary>
        /// 
        /// </summary>
        private bool _isDoingWork = false;

        /// <summary>
        /// 
        /// </summary>
        private object _isDoingWorkLocker = new object();

        /// <summary>
        /// 
        /// </summary>
        private int _margin = 4;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public BaseControl()
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
                if (container.Controls.Count > 0)
                {
                    IList<Control> ctls = new List<Control>();
                    foreach (Control ctl in container.Controls)
                    {
                        BaseItem thread = ctl.Tag as BaseItem;
                        if (thread != null)
                        {
                            ctls.Add(CreateControl(thread));
                        }
                    }

                    UpdateView(ctls, false);
                }
            }
        }
        #endregion

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
        protected virtual string GetUrl(UrlInfo info)
        {
            return info.BaseUrl + "?p=" + info.Index;
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
                UrlInfo urlInfo = e.Result as UrlInfo;
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
                MessageQueue.Enqueue(MessageFactory.CreateMessage(exp));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected virtual void DoWork(UrlInfo info)
        {
            this.UpdatePageInfo(info.WebPage, info);
            info.Result = this.GetItems(info.WebPage);
            info.Controls = this.PrepareControls(info.Result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected virtual IList<BaseItem> GetItems(WebPage wp)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected virtual bool CheckPage(WebPage wp, UrlInfo info)
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
        /// <param name="state">State is RunWorkerCompletedEventArgs!</param>
        protected void WorkCompletedBase(object state)
        {
            RunWorkerCompletedEventArgs e = state as RunWorkerCompletedEventArgs;
            try
            {
                UrlInfo urlInfo = e.Result as UrlInfo;
                if (urlInfo != null)
                {
                    WorkCompleted(urlInfo);
                }
            }
            catch (Exception exp)
            {
#if (DEBUG)
                CommonUtil.ShowMessage(typeof(BaseControl), exp.Message);
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected virtual void WorkCompleted(UrlInfo info)
        {
            if (info != null)
            {
                if (info.Status == PageStatus.Normal)
                {
                    LogStatus.Instance.UpdateLoginStatus(info.WebPage);
                    if (info.Controls != null)
                    {
                        this.UpdateView(info.Controls, info.IsAppend);
                    }
                }
                else
                {
                    Panel container = this.GetContainer();
                    if (container != null)
                    {
                        container.Controls.Clear();
                        Label lbl = new Label();
                        lbl.AutoSize = true;
                        lbl.Text = Nzl.Util.MiscUtil.GetEnumDescription(info.Status);
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
        protected virtual void SetCtlEnabled(bool flag)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        private IList<BaseItem> PrepareInfos(UrlInfo info)
        {
            return info.Result as IList<BaseItem>;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private void UpdatePageInfo(WebPage page, UrlInfo info)
        {
            if (page != null)
            {
                MatchCollection mtCollection = CommonUtil.GetMatchCollection(@"<a class=\Wplant\W>(?'Current'\d+)/(?'Total'\d+)</a>", page.Html);
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
        private IList<Control> PrepareControls(IList<BaseItem> list)
        {
            IList<Control> listThreacControl = new List<Control>();
            foreach (BaseItem item in list)
            {
                Control ctl = this.GetControl(item);
                if (ctl != null)
                {
                    listThreacControl.Add(ctl);
                }
            }

            return listThreacControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected Control GetControl(BaseItem item)
        {
            object ctl = this.Invoke(new CreateControlCallback(CreateControl), new object[] { item });
            return ctl==null ? null : ctl as Control;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <returns></returns>
        protected virtual Control CreateControl(BaseItem item)
        {            
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        protected virtual void SetControl(Control ctl, bool oeFlag)
        {
            if (oeFlag)
            {
                ctl.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctls"></param>
        /// <param name="isAppend"></param>
        protected virtual void UpdateView(IList<Control> ctls, bool isAppend)
        {
            System.Diagnostics.Debug.WriteLine(this.ToString() + " - UpdateView");
            Panel container = GetContainer();
            if (container != null)
            {
                lock (container)
                {
                    bool flag = false;
                    int accumulateHeight = 0;
                    if (isAppend == false)
                    {
                        foreach (Control ctl in container.Controls)
                        {
                            ctl.Dispose();
                        }

                        container.Controls.Clear();
                        GC.Collect();
                    }
                    else
                    {
                        accumulateHeight = container.Height - 3;
                    }

                    foreach (Control tc in ctls)
                    {
                        tc.Top = accumulateHeight + 1;
                        tc.Left = 1;
                        this.SetControl(tc, flag);
                        flag = !flag;
                        container.Controls.Add(tc);
                        accumulateHeight += tc.Height + 1;
                    }

                    System.Diagnostics.Debug.WriteLine(this.GetType().ToString() +　" － " +　_urlInfo.BaseUrl + " - accumulateHeight:" + accumulateHeight);
                    System.Diagnostics.Debug.WriteLine(this.GetType().ToString() + " － " + _urlInfo.BaseUrl + " - ctl count:" + ctls.Count);
                    
                    container.Height = accumulateHeight + 3;
                    if (isAppend == false)
                    {
                        container.Location = new Point(container.Location.X, this._margin);
                    }
                }
            }
        }

        #region FetchPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwFetchPage_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (this._isDoingWorkLocker)
            {
                try
                {
                    BackgroundWorker bw = sender as BackgroundWorker;
                    UrlInfo urlInfo = e.Argument as UrlInfo;
                    string targetUrl = this.GetUrl(urlInfo);
                    WebPage wp = WebPageFactory.CreateWebPage(targetUrl);
                    if (CheckPage(wp, urlInfo))
                    {
                        urlInfo.WebPage = wp;
                        e.Result = urlInfo;
                        DoWorkBase(e);

                        MessageQueue.Enqueue(MessageFactory.CreateMessage(this.Text == null ? this.GetType().ToString(): this.Text, "Get webpage '" + targetUrl + "' success!"));
                    }

                    e.Result = urlInfo;
                }
                catch (Exception exp)
                {
                    if (Program.LoggerEnabled)
                    {
                        Program.Logger.Error(exp.Message);
                    }

                    (e.Argument as UrlInfo).Status = PageStatus.UnKnown;
                    MessageQueue.Enqueue(MessageFactory.CreateMessage(exp));
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
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }
            else
            {
                WorkCompletedBase(e);
            }

            this.SetCtlEnabled(true);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchPage()
        {
            UrlInfo info = new UrlInfo(this._urlInfo);
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchPrevPage()
        {
            UrlInfo info = new UrlInfo(this._urlInfo);
            info.Index = this._urlInfo.Index - 1;
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchNextPage()
        {
            UrlInfo info = new UrlInfo(this._urlInfo);
            info.Index = this._urlInfo.Index + 1;
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchLastPage()
        {
            UrlInfo info = new UrlInfo(this._urlInfo);
            info.Index = this._urlInfo.Total;
            return FetchPage(info);
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool FetchPage(UrlInfo urlInfo)
        {
            if (urlInfo.Index > 0 && urlInfo.Index <= urlInfo.Total)
            {
                this.bwFetchPage = new System.ComponentModel.BackgroundWorker();
                this.bwFetchPage.DoWork += new System.ComponentModel.DoWorkEventHandler(bwFetchPage_DoWork);
                this.bwFetchPage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bwFetchPage_RunWorkerCompleted);
                this.bwFetchPage.RunWorkerAsync(urlInfo);
#if (DEBUG)
                Nzl.Web.Util.CommonUtil.ShowMessage(System.DateTime.Now + "\t " + this.GetType().ToString() + "\n FetecPage's index is equal to " + urlInfo.Index);
#endif
                SetCtlEnabled(false);
                return true;
            }

            return false;
        }
        #endregion
    }
}
