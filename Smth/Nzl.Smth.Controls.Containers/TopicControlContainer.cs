namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Smth.Logger;
    using Nzl.Web.Util;
    using Nzl.Web.Page;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class TopicControlContainer : BaseControlContainer<TopicControl, Topic>
    {
        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTopicCreateIDLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTopicLastIDLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTopicLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnPostLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnNewClicked;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BoardSettingEventArgs> OnBoardSettingsClicked;
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private BoardSettingEventArgs _Settings = null;

        /// <summary>
        /// 
        /// </summary>
        private Timer _updatingTimer = new Timer();

        /// <summary>
        /// 
        /// </summary>
        private string _boardCode = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// Ctor.
        /// </summary>
        public TopicControlContainer()
        {
            InitializeComponent();
            this._updatingTimer.Tick += _updatingTimer_Tick;
            this._Settings = new BoardSettingEventArgs();

            ///For ToString.
            this.Text = "The topic container";

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

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public string Board
        {
            set
            {
                this._boardCode = value;
                this.SetUrl();
            }

            get
            {
                return this._boardCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TopicBrowserType BrowserType
        {
            get
            {
                return this._Settings.BrowserType;
            }

            set
            {
                this._Settings.BrowserType = value;
            }
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected override IList<Topic> GetItems(WebPage wp)
        {
            IList<Topic> topics = TopicFactory.CreateTopics(wp);
            if (this._Settings.IsShowTop == false)
            {
                IList<Topic> tps = new List<Topic>();
                foreach (Topic topic in topics)
                {
                    if (topic.Mode == TopicStatus.Normal ||
                        topic.Mode == TopicStatus.Magic)
                    {
                        tps.Add(topic);
                    }
                    else
                    {
                        this.RecyclingItem(topic);
                    }
                }

                topics.Clear();
                return tps;
            }

            return topics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void WorkCompleted(UrlInfo<TopicControl, Topic> info)
        {
            base.WorkCompleted(info);
            this.UpdateBoardTitle(info.WebPage);
            this.bsiPage.Caption = info.Index.ToString().PadLeft(6, '0') + "/" + info.Total.ToString().PadLeft(6, '0');

            ///Fetch next page when the container is not full.
            ///The condition is the previous loading is good.
            if (info.WebPage != null &&
                info.WebPage.IsGood &&
                info.Result != null &&
                info.Result.Count > 0 &&
                this.GetPanel().Height < this.panelContainer.Height)
            {
                this.SetUrlInfo(true);
                this.FetchNextPage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="oeFlag"></param>
        protected override void SetControl(TopicControl ctl, bool oeFlag)
        {
            base.SetControl(ctl, oeFlag);
            if (ctl.Data != null)
            {
                if (ctl.Data.Mode == TopicStatus.Top)
                {
                    ctl.ForeColor = Color.Red;
                }
                else if (ctl.Data.Mode == TopicStatus.Magic)
                {
                    ctl.ForeColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    ctl.ForeColor = Color.Blue;
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
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(TopicControl ctl, Topic item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "tc" + item.ID;
                ctl.OnTopicLinkClicked += TopicControl_OnTopicLinkClicked;
                ctl.OnPostLinkClicked += TopicControl_OnPostLinkClicked;
                ctl.OnCreateIDLinkClicked += TopicControl_OnCreateIDLinkClicked;
                ctl.OnLastIDLinkClicked += TopicControl_OnLastIDLinkClicked;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(TopicControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnTopicLinkClicked -= TopicControl_OnTopicLinkClicked;
                ctl.OnPostLinkClicked -= TopicControl_OnPostLinkClicked;
                ctl.OnCreateIDLinkClicked -= TopicControl_OnCreateIDLinkClicked;
                ctl.OnLastIDLinkClicked -= TopicControl_OnLastIDLinkClicked;
            }
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
            this.bbiNew.Enabled = flag;

            this.bbiRefresh.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogin"></param>
        protected override void OnLoginStatusChanged(bool isLogin)
        {
            this.bbiNew.Visibility = isLogin ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Recycling()
        {
            base.Recycling();

            this._Settings = new BoardSettingEventArgs();
            this._updatingTimer.Stop();
        }
        #endregion

        #region event handler.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _updatingTimer_Tick(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(1, false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchPrevPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchNextPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchLastPage();
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
        private void bbiGo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int pageIndex = Int32.MaxValue;
                if (this.beiGo.EditValue != null && string.IsNullOrEmpty(this.beiGo.EditValue.ToString()) == false)
                {
                    pageIndex = System.Convert.ToInt32(this.beiGo.EditValue);
                }


                this.SetUrlInfo(pageIndex, false);
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
        private void bbiOpenInBrowser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonUtil.OpenUrl(this.GetCurrentUrl());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.OnBoardSettingsClicked != null)
            {
                BoardSettingEventArgs bsEventArgs = new BoardSettingEventArgs();
                bsEventArgs.IsShowTop = this._Settings.IsShowTop;
                bsEventArgs.AutoUpdating = this._Settings.AutoUpdating;
                bsEventArgs.BrowserType = this._Settings.BrowserType;
                bsEventArgs.UpdatingInterval = this._Settings.UpdatingInterval;
                this.OnBoardSettingsClicked(sender, bsEventArgs);
                if (bsEventArgs.Tag != null && bsEventArgs.Tag.ToString() == "Updated")
                {
                    this._Settings.IsShowTop = bsEventArgs.IsShowTop;
                    this._Settings.AutoUpdating = bsEventArgs.AutoUpdating;
                    this._Settings.BrowserType = bsEventArgs.BrowserType;
                    this._Settings.UpdatingInterval = bsEventArgs.UpdatingInterval;
                    ApplyBoardSetting();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarManager bm = sender as BarManager;
            if (this.OnNewClicked != null && bm != null)
            {
                HyperlinkClickEventArgs hcea = new HyperlinkClickEventArgs();
                hcea.Link = Configs.Configuration.BaseUrl + "/article/" + this.Board + "/post";
                hcea.Text = null;
                this.OnNewClicked(sender, hcea);
                if (hcea.Text != null)
                {
                    string postString = hcea.Text;
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(hcea.Link, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += NewTopic_Succeeded;
                        pl.Failed += NewTopic_Failed;
                        pl.Start();
                    }
                }

                e.Item.Tag = null;
            }
        }                

        #region NewTopic - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostLoader_ErrorAccured(object sender, MessageEventArgs e)
        {
            this.ShowInformation(e.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTopic_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Creating new post is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTopic_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Creating new post failed!");
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControl_OnPostLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                if (this.OnPostLinkClicked != null)
                {
                    this.OnPostLinkClicked(sender, e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControl_OnTopicLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                if (this.OnTopicLinkClicked != null)
                {
                    this.OnTopicLinkClicked(sender, e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControl_OnCreateIDLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                if (this.OnTopicCreateIDLinkClicked != null)
                {
                    this.OnTopicCreateIDLinkClicked(sender, e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControl_OnLastIDLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                if (this.OnTopicLastIDLinkClicked != null)
                {
                    this.OnTopicLastIDLinkClicked(sender, e);
                }
            }
        }
        #endregion

        #region private
        /// <summary>
        /// 
        /// </summary>
        private void SetUrl()
        {
            this.SetBaseUrl(SmthUtil.GetBoardUrl(this._boardCode, this._Settings.BrowserType));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        private void UpdateBoardTitle(WebPage wp)
        {
            if (wp != null && wp.IsGood)
            {
                this.Text = SmthUtil.GetBoard(wp);
                if (this.Parent != null && this.Text != null)
                {
                    string boardName = this.Text.Substring(0, this.Text.IndexOf("("));
                    this.Parent.Text = "【" + boardName + "】";
                    this.Parent.Tag = "版面-" + this.Text;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        private void ApplyBoardSetting()
        {
            this._updatingTimer.Stop();
            if (this._Settings.AutoUpdating)
            {
                this._updatingTimer.Interval = this._Settings.UpdatingInterval * 1000;
                this._updatingTimer.Start();
            }

            this.SetUrl();
            this.SetUrlInfo(false);
            this.FetchPage();
        }
        #endregion
    }
}
