namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraBars;
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
    public partial class MailControlContainer : BaseControlContainer<MailControl, Mail>
    {
        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnMailLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event ItemClickEventHandler OnNewMailClicked;
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private MailBoxType _mailBoxType = MailBoxType.Inbox;
        /// <summary>
        /// 
        /// </summary>
        private Control _parentControl = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// Ctor.
        /// </summary>
        MailControlContainer()
        {
            InitializeComponent();

            ///For ToString.
            this.Text = "The mail container";

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
        /// Ctor.
        /// </summary>
        public MailControlContainer(MailBoxType type)
            : this()
        {
            this._mailBoxType = type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public void SetParent(Control ctl)
        {
            this._parentControl = ctl;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public string Url
        {
            set
            {
                this.SetBaseUrl(value);
            }
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.IsResponingMouseWheel = false;
            this.InitializeSize();
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
        protected override IList<Mail> GetItems(WebPage wp)
        {
            return MailFactory.CreateMails(wp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(MailControl ctl, Mail item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "mc" + item.Url;
                ctl.OnMailLinkClicked += Tc_OnMailLinkClicked;
                ctl.OnUserLinkClicked += Tc_OnUserLinkClicked;
                ctl.OnDeleteLinkClicked += Tc_OnDeleteLinkClicked;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(MailControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnMailLinkClicked -= Tc_OnMailLinkClicked;
                ctl.OnUserLinkClicked -= Tc_OnUserLinkClicked;
                ctl.OnDeleteLinkClicked -= Tc_OnDeleteLinkClicked;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void WorkCompleted(UrlInfo<MailControl, Mail> info)
        {
            base.WorkCompleted(info);
            this.bsiPage.Caption = info.Index.ToString().PadLeft(3, '0') + "/" + info.Total.ToString().PadLeft(3, '0');
            if (this._mailBoxType == MailBoxType.Inbox)
            {
                MailStatus.Instance.UpdateStatus(info.WebPage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="oeFlag"></param>
        protected override void SetControl(MailControl ctl, bool oeFlag)
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
        /// <param name="isLogin"></param>
        protected override void OnLoginStatusChanged(bool isLogin)
        {
            this.bbiNew.Visibility = isLogin ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.OnNewMailClicked != null)
            {
                e.Item.Tag = null;
                this.OnNewMailClicked(sender, e);
                if (e.Item.Tag != null)
                {
                    string postString = e.Item.Tag as string;
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(Configuration.SendMailUrl, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += NewMail_Succeeded;
                        pl.Failed += NewMail_Failed;
                        pl.Start();
                    }
                }
            }
        }

        #region NewMail - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMail_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Sending mail is completed!");
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMail_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Sending mail failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tc_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void Tc_OnDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnDeleteLinkClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnDeleteLinkClicked(sender, e);
                if (hlc.Tag != null && hlc.Tag.ToString() == "Yes")
                {
                    PostLoader pl = new PostLoader(e.Link);
                    pl.ErrorAccured += PostLoader_ErrorAccured;
                    pl.Succeeded += MailDelete_Succeeded;
                    pl.Failed += MailDelete_Failed;
                    pl.Start();
                }

                hlc.Tag = null;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tc_OnMailLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnMailLinkClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnMailLinkClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string infor = hlc.Tag.ToString();
                    ///Deleting mail.
                    if (infor.Contains("ConfirmToDelete"))
                    {
                        PostLoader pl = new PostLoader(infor.Replace("ConfirmToDelete", ""));
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += MailDelete_Succeeded;
                        pl.Failed += MailDelete_Failed;
                        pl.Start();
                    }

                    ///Replying mail.
                    if (infor.Contains("ReplyMail"))
                    {
                        PostLoader pl = new PostLoader(Configuration.SendMailUrl, infor.Replace("ReplyMail", ""));
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += MailReply_Succeeded;
                        pl.Failed += MailReply_Failed;
                        pl.Start();
                    }
                }

                hlc.Tag = null;
            }
        }

        #region MailReply - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailReply_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Replying the mail is completed!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailReply_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Replying the mail failed!");
        }
        #endregion

        #region MailDelete - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailDelete_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Deleting the mail is completed!");
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailDelete_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Deleting the mail failed!");
        }
        #endregion
        #endregion

        #region private
        /// <summary>
        /// 
        /// </summary>
        private void InitializeSize()
        {
            int dHeight = this.Height - this.panelContainer.Height;
            this.GetPanel().Size = new Size(this.Width
                                              - Configuration.BaseControlContainerLocationMargin * 2
                                              - this.GetPanelContainerBoarderMargin(),
                                            MailControl.ControlHeight * 10
                                              + Configuration.BaseControlLocationMargin * 11
                                              + this.GetControlContainerBoarderMargin());
            this.Height = this.GetPanel().Height
                        + dHeight
                        + Configuration.BaseControlContainerLocationMargin * 2
                        + this.GetPanelContainerBoarderMargin();
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
        #endregion
    }
}
