namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;
    using Nzl.Smth.Utils;    
    using Nzl.Web.Page;
    using Nzl.Web.Util;


    /// <summary>
    /// Class.
    /// </summary>
    public partial class AtControlContainer : BaseElementControlContainer<AtControl, At>
    {
        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReplyLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private Control _parentControl = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// Ctor.
        /// </summary>
        public AtControlContainer()
        {
            InitializeComponent();
            this.SetBaseUrl(Configuration.AtUrl);

            ///For ToString.
            this.Text = "The at container";

            ///Apply font.
            foreach (DevExpress.XtraBars.Bar bar in this.bmManager.Bars)
            {
                bar.BarAppearance.Normal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bar.BarAppearance.Hovered.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bar.BarAppearance.Pressed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bar.BarAppearance.Disabled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public void SetParent(Control ctl)
        {
            this._parentControl = ctl;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reload()
        {
            this.SetUrlInfo(false);
            this.FetchPage();
        }
        #endregion

        #region override
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
        protected override IList<At> GetItems(WebPage wp)
        {
            return AtFactory.CreateAts(wp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(AtControl ctl, At item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "rf" + item.Url;
                ctl.OnReplyLinkClicked += ReplyControl_OnReplyLinkClicked;
                ctl.OnUserLinkClicked += ReplyControl_OnUserLinkClicked;
                ctl.OnDeleteLinkClicked += ReplyControl_OnDeleteLinkClicked;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(AtControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnReplyLinkClicked -= ReplyControl_OnReplyLinkClicked;
                ctl.OnUserLinkClicked -= ReplyControl_OnUserLinkClicked;
                ctl.OnDeleteLinkClicked -= ReplyControl_OnDeleteLinkClicked;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void WorkCompleted(UrlInfo<AtControl, At> info)
        {
            base.WorkCompleted(info);
            this.bsiPage.Caption = info.Index.ToString().PadLeft(3, '0') + "/" + info.Total.ToString().PadLeft(3, '0');
            AtStatus.Instance.UpdateStatus(info.WebPage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="oeFlag"></param>
        protected override void SetControl(AtControl ctl, bool oeFlag)
        {
            base.SetControl(ctl, oeFlag);
            if (ctl.Data != null)
            {
                if (ctl.Data.IsNew)
                {
                    ctl.ForeColor = Color.Red;
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
        /// <param name="flag"></param>
        protected override void SetControlEnabled(bool flag)
        {
            base.SetControlEnabled(flag);

            this.bbiFirst.Enabled = flag;
            this.bbiPrev.Enabled = flag;
            this.bbiNext.Enabled = flag;
            this.bbiLast.Enabled = flag;
            this.bbiGo.Enabled = flag;
            this.beiGo.Enabled = flag;

            this.bbiRefresh.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <returns></returns>
        private MailControl CreateMailControl(Mail mail)
        {
            MailControl mc = new MailControl();

            return mc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyControl_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnUserLinkClicked != null)
            {
                this.OnUserLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyControl_OnReplyLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnReplyLinkClicked != null)
            {
                this.OnReplyLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyControl_OnDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnDeleteLinkClicked != null)
            {
                this.OnDeleteLinkClicked(sender, e);
            }
        }
        #endregion

        #region event handler.
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
        #endregion
    }
}
