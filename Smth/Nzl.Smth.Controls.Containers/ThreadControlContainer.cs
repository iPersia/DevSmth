//#define DESIGNMODE
namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using Nzl.Recycling;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;
    using Nzl.Web.Page;
    
    /// <summary>
    /// The topic form.
    /// </summary>
#if (DESIGNMODE)
    public partial class ThreadControlContainer : UserControl
#else
    public partial class ThreadControlContainer : BaseElementControlContainer<ThreadControl, Thread>
#endif
    {
#if (DESIGNMODE)
#else
        #region events.
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadQueryTypeLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadReplyLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTopicReplyLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<TopicSettingEventArgs> OnTopicSettingsClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadMailLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadTransferLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadEditLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnThreadDeleteLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event LinkClickedEventHandler OnThreadContentLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> OnCaptionChanged;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private string _topic;

        /// <summary>
        /// The url.
        /// </summary>
        private string _topicUrl;

        /// <summary>
        /// 
        /// </summary>
        private string _subject;

        /// <summary>
        /// 
        /// </summary>
        private string _postUrl;

        /// <summary>
        /// 
        /// </summary>
        private string _targetUserID;

        /// <summary>
        /// 
        /// </summary>
        private TopicSettingEventArgs _Settings = null;

        /// <summary>
        /// 
        /// </summary>
        private Timer _updatingTimer = new Timer();

        /// <summary>
        /// 
        /// </summary>
        private Thread _hostThread = null;

        /// <summary>
        /// 
        /// </summary>
        private UrlInfo<ThreadControl, Thread> _resultUrlInfo = new UrlInfo<ThreadControl, Thread>();
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public string Url
        {
            get
            {
                return this._topicUrl;
            }

            set
            {
                this._topicUrl = value;
                this.SetBaseUrl(this._topicUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TargetUserID
        {
            get
            {
                return this._targetUserID;
            }

            set
            {
                this._targetUserID = value;
                if (string.IsNullOrEmpty(this._targetUserID) == false)
                {
                    this.bbiSettings.Visibility =  BarItemVisibility.Never;
                    this.bbiBoard.Visibility = BarItemVisibility.Never;
                    this.bbiReply.Visibility = BarItemVisibility.Never;
                }
            }
        }
        #endregion

        #region Ctors.
        /// <summary>
        /// Ctor.
        /// </summary>
        public ThreadControlContainer()
        {
            InitializeComponent();
            this._updatingTimer.Tick += _updatingTimer_Tick;

            ///For ToString.
            this.Text = "The thread container";
            
            ///Initialize settings.
            this._Settings = new TopicSettingEventArgs();

            ///Apply font.
            foreach (DevExpress.XtraBars.Bar bar in this.bmManager.Bars)
            {
                bar.BarAppearance.Normal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bar.BarAppearance.Hovered.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bar.BarAppearance.Pressed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bar.BarAppearance.Disabled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }
        #endregion

        #region overrides
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void DoWork(UrlInfo<ThreadControl, Thread> info)
        {
            base.DoWork(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void WorkCompleted(UrlInfo<ThreadControl, Thread> info)
        {
            base.WorkCompleted(info);
            if (info.Status == PageStatus.Normal)
            {
                this.UpdateInfor(info.WebPage);
                this.bsiPage.Caption = info.Index.ToString().PadLeft(3, '0') + "/" + info.Total.ToString().PadLeft(3, '0');
                this._resultUrlInfo = info;

                ///Save the host thread.
                if (info.Index == 1 &&                     
                    info.Result.Count > 0 &&
                    info.Result[0].Floor == "楼主" &&
                    this._hostThread == null)
                {
                    this._hostThread = info.Result[0];
                }

                ///Reset base url.
                string url = this.GetCurrentUrl();
                if (url != null &&
                    url.Contains(Configuration.BaseUrl) &&
                    url.IndexOf('?') > 0)
                {
                    this.SetBaseUrl(url.Substring(0, url.IndexOf('?')));
                }

                ///Fetch next page when the container is not full.
                ///The condition is the previous loading is good.
                if (info.WebPage != null && 
                    info.WebPage.IsGood &&
                    info.Result != null &&
                    info.Result.Count > 0 &&
                    this.GetPanel().Height < this.panelContainer.Height)
                {
                    if (this._Settings.BrowserType == ThreadBrowserType.FirstReply)
                    {
                        this.SetUrlInfo(true);
                        this.FetchNextPage();
                    }
                    else
                    {
                        this.SetUrlInfo(true);
                        this.FetchPrevPage();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override PanelControl GetPanel()
        {
            return this.panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override PanelControl GetPanelContainer()
        {
            return this.panelContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected override IList<Thread> GetItems(WebPage wp)
        {
            IList<Thread> threads = ThreadFactory.CreateThreads(wp);
            if (this._Settings.BrowserType == ThreadBrowserType.LastReply)
            {
                IList<Thread> reversedThreads = new List<Thread>();
                if (threads != null)
                {
                    if (this._hostThread != null)
                    {
                        reversedThreads.Insert(0, this._hostThread);
                    }

                    for (int i = threads.Count - 1; i >= 0; i--)
                    {
                        reversedThreads.Add(threads[i]);
                    }

                    return reversedThreads;
                }
            }

            return threads;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(ThreadControl ctl, Thread item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "tc" + item.ID;
                ctl.OnUserLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnUserClicked);
                ctl.OnQueryTypeLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnQueryTypeLinkClicked);
                ctl.OnEditLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnEditLinkClicked);
                ctl.OnDeleteLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnDeleteLinkClicked);
                ctl.OnReplyLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnReplyLinkClicked);
                ctl.OnMailLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnMailLinkClicked);
                ctl.OnTransferLinkClicked += new HyperlinkClickEventHandler(ThreadControl_OnTransferLinkClicked);
                ctl.OnTextBoxLinkClicked += ThreadControl_OnTextBoxLinkClicked;
                ctl.OnTextBoxMouseWheel += this.Container_MouseWheel;
                if (string.IsNullOrEmpty(this._targetUserID) == false)
                {
                    ctl.IsPlainView = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(ThreadControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnUserLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnUserClicked);
                ctl.OnQueryTypeLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnQueryTypeLinkClicked);
                ctl.OnEditLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnEditLinkClicked);
                ctl.OnDeleteLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnDeleteLinkClicked);
                ctl.OnReplyLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnReplyLinkClicked);
                ctl.OnMailLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnMailLinkClicked);
                ctl.OnTransferLinkClicked -= new HyperlinkClickEventHandler(ThreadControl_OnTransferLinkClicked);
                ctl.OnTextBoxLinkClicked -= ThreadControl_OnTextBoxLinkClicked;
                ctl.OnTextBoxMouseWheel -= this.Container_MouseWheel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected override void RecyclingItem(Thread thread)
        {
            if (this._hostThread != thread)
            {
                base.RecyclingItem(thread);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <returns></returns>
        protected override bool CheckAddingControl(ThreadControl ctl)
        {
            if (this._Settings.BrowserType == ThreadBrowserType.LastReply &&
                this._Settings.AutoUpdating == false &&
                ctl.Name != null)
            {
                return this.GetPanel().Controls.ContainsKey(ctl.Name) == false;
            }

            return base.CheckAddingControl(ctl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetCurrentUrl()
        {
            return base.GetCurrentUrl() + (string.IsNullOrEmpty(this._targetUserID) ? "" : "&au=" + this._targetUserID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetUrl(UrlInfo<ThreadControl, Thread> info)
        {
            return base.GetUrl(info) + (string.IsNullOrEmpty(this._targetUserID) ? "" : "&au=" + this._targetUserID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        protected override void SetControlEnabled(bool flag)
        {
            base.SetControlEnabled(flag);

            this.bbiFirst.Enabled = flag;
            this.bbiPrev.Enabled = flag;
            this.bbiNext.Enabled = flag;
            this.bbiLast.Enabled = flag;
            this.bbiGo.Enabled = flag;
            this.bbiSettings.Enabled = flag;
            this.beiGo.Enabled = flag;

            this.bbiRefresh.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void FetchPageOnMouseWheel()
        {
            this.SetUrlInfo(true);
            if (this._Settings.BrowserType == ThreadBrowserType.FirstReply)
            {
                this.FetchNextPage();
            }
            else if (this._Settings.AutoUpdating == false)
            {
                this.FetchPrevPage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogin"></param>
        protected override void OnLoginStatusChanged(bool isLogin)
        {
            this.bbiReply.Visibility = BarItemVisibility.Never;
            if (string.IsNullOrEmpty(this._targetUserID) == false)
            {
                this.bbiReply.Visibility = isLogin && string.IsNullOrEmpty(this._postUrl) == false ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        public override void Recycling()
        {
            base.Recycling();

            ///Recyling the host thread.
            if (this._hostThread != null)
            {
                RecycledQueues.AddRecycled<Thread>(this._hostThread);
                this._hostThread = null;
            }

            ///Initialize the settings.
            this._Settings = new TopicSettingEventArgs();
            this._updatingTimer.Stop();
            this._topic = null;
            this._topicUrl = null;
            this._subject = null;
            this._postUrl = null;
            this._targetUserID = null;
        }
        #endregion

        #region Get information       
        #endregion

        #region Event handler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _updatingTimer_Tick(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchLastPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            if (this._Settings.BrowserType == ThreadBrowserType.FirstReply)
            {
                this.SetUrlInfo(1, false);
                this.FetchPage();
            }
            else
            {
                this.FetchLastPage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            if (this._Settings.BrowserType == ThreadBrowserType.LastReply)
            {
                this.FetchNextPage();
            }
            else
            {
                this.FetchPrevPage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            if (this._Settings.BrowserType == ThreadBrowserType.FirstReply)
            {
                this.FetchNextPage();
            }
            else
            {
                this.FetchPrevPage();
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            if (this._Settings.BrowserType == ThreadBrowserType.LastReply)
            {
                this.SetUrlInfo(1, false);
                this.FetchPage();
            }
            else
            {
                this.FetchLastPage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiGo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int pageIndex = Int32.MaxValue;
                if (this.beiGo.EditValue != null && string.IsNullOrEmpty(this.beiGo.EditValue.ToString()) == false)
                {
                    pageIndex = System.Convert.ToInt32(this.beiGo.EditValue.ToString());
                }

                if (this._Settings.BrowserType == ThreadBrowserType.FirstReply)
                {
                    this.SetUrlInfo(pageIndex, false);
                }
                else
                {
                    this.SetUrlInfo(this._resultUrlInfo.Total - pageIndex + 1, false);
                }

                this.FetchPage();
                this.beiGo.EditValue = "";
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }

#if (DEBUG)
                CommonUtil.ShowMessage(typeof(ThreadControlContainer), exp.Message);
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.OnTopicSettingsClicked != null)
            {
                TopicSettingEventArgs tsEventArgs = new TopicSettingEventArgs();
                tsEventArgs.AutoUpdating = this._Settings.AutoUpdating;
                tsEventArgs.BrowserType = this._Settings.BrowserType;
                tsEventArgs.UpdatingInterval = this._Settings.UpdatingInterval;
                this.OnTopicSettingsClicked(sender, tsEventArgs);
                if (tsEventArgs.Tag != null && tsEventArgs.Tag.ToString() == "Updated")
                {
                    this._Settings.AutoUpdating = tsEventArgs.AutoUpdating;
                    this._Settings.BrowserType = tsEventArgs.BrowserType;
                    this._Settings.UpdatingInterval = tsEventArgs.UpdatingInterval;
                    ApplyTopicSetting();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiReply_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            BarManager bm = sender as BarManager;
            if (this.OnTopicReplyLinkClicked != null && bm != null)
            {
                e.Text = null;
                this.OnTopicReplyLinkClicked(sender, e);
                if (this.Text != null)
                {
                    string postString = e.Text;
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(this._postUrl, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadReply_Succeeded;
                        pl.Failed += ThreadReply_Failed;
                        pl.Start();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiOpenInBrowser_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonUtil.OpenUrl(this.GetCurrentUrl());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiBoard_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnBoardLinkClicked != null)
            {
                this.OnBoardLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ApplyTopicSetting()
        {
            if (this._Settings.BrowserType == ThreadBrowserType.FirstReply)
            {
                this._updatingTimer.Stop();
                this.SetUrlInfo(1, false);
                this.FetchPage();
            }

            if (this._Settings.BrowserType == ThreadBrowserType.LastReply)
            {
                this._updatingTimer.Stop();
                if (this._Settings.AutoUpdating)
                {
                    this._updatingTimer.Interval = this._Settings.UpdatingInterval * 1000;
                    this._updatingTimer.Start();
                }

                this.SetUrlInfo(false);
                this.FetchLastPage();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostLoader_ErrorAccured(object sender, MessageEventArgs e)
        {
            this.ShowInformation(e.Message);
        }

        #region ThreadReply - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadReply_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Replying the thread is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchLastPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadReply_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Replying the thread failed!");
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnUserClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnThreadUserLinkClicked != null)
            {
                this.OnThreadUserLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnQueryTypeLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnThreadQueryTypeLinkClicked != null)
            {
                this.OnThreadQueryTypeLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnReplyLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnThreadReplyLinkClicked != null && hlc != null)
            {
                ///hlc.Tag = null;
                this.OnThreadReplyLinkClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string postString = hlc.Tag.ToString();                    
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(e.Link, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadReply_Succeeded;
                        pl.Failed += ThreadReply_Failed;
                        pl.Start();
                    }
                }

                hlc.Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnMailLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnThreadMailLinkClicked != null && hlc != null)
            {
                ///hlc.Tag = null;
                this.OnThreadMailLinkClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string postString = hlc.Tag as string;
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(Configuration.SendMailUrl, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadMail_Succeeded;
                        pl.Failed += ThreadMail_Failed;
                        pl.Start();
                    }                    
                }

                hlc.Tag = null;
            }
        }

        #region ThreadMail - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadMail_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Sending mail is completed!");          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadMail_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Sending mail failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnTransferLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnThreadTransferLinkClicked != null)
            {
                this.OnThreadTransferLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnEditLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnThreadEditLinkClicked != null && hlc != null)
            {
                ///hlc.Tag = null;
                this.OnThreadEditLinkClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string postString = hlc.Tag.ToString();                    
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(e.Link, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadEdit_Succeeded;
                        pl.Failed += ThreadEdit_Failed;
                        pl.Start();
                    }
                }

                hlc.Tag = null;
            }
        }

        #region ThreadEdit - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadEdit_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Editting the thread is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchLastPage(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadEdit_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Editting the thread failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnThreadDeleteLinkClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnThreadDeleteLinkClicked(sender, e);
                if (hlc.Tag != null && hlc.Tag.ToString() == "Yes")
                {
                    PostLoader pl = new PostLoader(e.Link);
                    pl.ErrorAccured += PostLoader_ErrorAccured;
                    pl.Succeeded += ThreadDelete_Succeeded;
                    pl.Failed += ThreadDelete_Failed;
                    pl.Start();
                }

                hlc.Tag = null;
            }
        }

        #region ThreadDelete - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadDelete_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Deleting the thread is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchPage();     
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadDelete_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Deleting the thread failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControl_OnTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (this.OnThreadContentLinkClicked != null)
            {
                this.OnThreadContentLinkClicked(sender, e);
            }
        }
        #endregion

        #region Updating
        /// <summary>
        /// 
        /// </summary>
        private void UpdateInfor(WebPage wp)
        {
            this._topic = SmthUtil.GetTopic(wp);
            this.Text = this._topic + " - " + SmthUtil.GetBoard(wp);
            if (string.IsNullOrEmpty(this._targetUserID) == false)
            {
                this.Text = "只看" + this._targetUserID + " - " + this.Text;
            }

            ///
            if (this.OnCaptionChanged != null)
            {
                string msg = "主题:" + this._topic + " - " + SmthUtil.GetBoard(wp);
                this.OnCaptionChanged(this, new MessageEventArgs(msg));
            }

            this._subject = this._topic;//CommonUtil.GetMatch(@"<input type=\Whidden\W name=\Wsubject\W value=\W(?'subject'Re[0-9A-Z,%,~,-]+)\W\s/>", html, 1);
            this._postUrl = CommonUtil.GetMatch(@"<form action=\W(?'post'/article/[\w, %2E, %5F, \.]+/post/\d+)\W method=\Wpost\W>", wp.Html, 1);
            this.bbiReply.Caption = "Reply";
            if (string.IsNullOrEmpty(this._postUrl) == false)
            {
                this._postUrl.Replace("%2E", ".");
                this._postUrl.Replace("%5F", "_");
                this._postUrl = Configuration.BaseUrl + this._postUrl;

                this.bbiReply.Visibility = string.IsNullOrEmpty(this._targetUserID) ? BarItemVisibility.Always : BarItemVisibility.Never;
                this.bbiReply.Caption = ControlUtil.GetHyperlinkText(this.bbiReply.Caption, this._postUrl);
            }
            
            string board = SmthUtil.GetBoard(wp);
            this.bbiBoard.Caption = "Board";
            if (board != null && string.IsNullOrEmpty(this._targetUserID))
            {
                string engBoardName = CommonUtil.GetMatch(@"\((?'Board'.+)\)", board, "Board");
                string chnBoardName = board.Replace("(" + engBoardName + ")", "");
                this.bbiBoard.Caption = chnBoardName;
                this.bbiBoard.Caption = ControlUtil.GetHyperlinkText(this.bbiBoard.Caption, engBoardName);
            }

            this.bbiReply.Visibility = LogStatus.Instance.IsLogin && string.IsNullOrEmpty(this._targetUserID) ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
        #endregion

#endif
    }
}
