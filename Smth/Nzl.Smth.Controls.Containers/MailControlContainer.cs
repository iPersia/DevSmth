﻿namespace Nzl.Smth.Controls.Containers
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
        public event EventHandler OnNewMailClicked;
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
            this.Text = "Mail Container";
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
            this.IsResponingMouseWheel = false;
            this.InitializeSize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Panel GetPanel()
        {
            return this.panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Panel GetPanelContainer()
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
            this.lblPage.Text = info.Index.ToString().PadLeft(3, '0') + "/" + info.Total.ToString().PadLeft(3, '0');
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

            this.btnFirst.Enabled = flag;
            this.btnPrev.Enabled = flag;
            this.btnNext.Enabled = flag;
            this.btnLast.Enabled = flag;
            this.btnGo.Enabled = flag;
            this.txtGoTo.Enabled = flag;

            this.btnRefresh.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogin"></param>
        protected override void OnLoginStatusChanged(bool isLogin)
        {
            this.btnNew.Visible = isLogin;
        }
        #endregion

        #region event handler.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.SetUrlInfo(1, false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchPrevPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchNextPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchLastPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = Int32.MaxValue;
                if (string.IsNullOrEmpty(this.txtGoTo.Text) == false)
                {
                    pageIndex = System.Convert.ToInt32(this.txtGoTo.Text);
                }

                this.SetUrlInfo(pageIndex, false);
                this.FetchPage();
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
        private void btnOpenInBrower_Click(object sender, EventArgs e)
        {
            CommonUtil.OpenUrl(this.GetCurrentUrl());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.OnNewMailClicked != null)
            {
                this.OnNewMailClicked(sender, e);
                Button btn = sender as Button;
                if (btn != null && btn.Tag != null)
                {
                    string postString = btn.Tag as string;
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
