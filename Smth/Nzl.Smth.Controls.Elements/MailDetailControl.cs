﻿//#define DESIGNMODE
namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Text;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;

    /// <summary>
    /// 
    /// </summary>
#if (DESIGNMODE)
    public partial class MailDetailControl : UserControl
#else
    public partial class MailDetailControl : BaseElementControl<Mail>
#endif
    {
#if (DESIGNMODE)
#else
        #region events.
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReplyLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public MailDetailControl()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The mail detail control";

            this.linklblID.HyperlinkClick += LinklblID_LinkClicked;
            this.linklblReply.HyperlinkClick += LinklblReply_LinkClicked;
            this.linklblDelete.HyperlinkClick += LinklblDelete_LinkClicked;
            this.linklblTransfer.HyperlinkClick += LinklblTransfer_LinkClicked;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public override void PrepareControls()
        {
            base.PrepareControls();

            ///
            this.HyperlinkLabelControls.Add(this.linklblDelete);
            this.HyperlinkLabelControls.Add(this.linklblTransfer);
            this.HyperlinkLabelControls.Add(this.linklblReply);
            this.HyperlinkLabelControls.Add(this.linklblID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        public override void Initialize(Mail mail)
        {
            base.Initialize(mail);
            if (mail != null)
            {
                try
                {
                    this.lblTitle.Text = mail.Title;
                    this.lblDateTime.Text = mail.DateTime;

                    this.InitializeLinkLabel(this.linklblDelete, mail.DeleteUrl);

                    /////Delete url.
                    //this.linklblDelete.Visible = false;
                    //if (string.IsNullOrEmpty(mail.DeleteUrl) == false)
                    //{
                    //    this.linklblDelete.Visible = true;
                    //    this.linklblDelete.Text = ControlUtil.GetHyperlinkText(this.linklblDelete.Text, mail.DeleteUrl);
                    //    this.linklblDelete.LinkVisited = ControlCenter.IsVisitedUrl(mail.DeleteUrl);
                    //}

                    this.InitializeLinkLabel(this.linklblID, mail.Author, mail.Author);

                    /////ID url.
                    //this.linklblID.Visible = false;
                    //if (string.IsNullOrEmpty(mail.Author) == false)
                    //{
                    //    this.linklblID.Text = mail.Author;
                    //    this.linklblID.Text = ControlUtil.GetHyperlinkText(mail.Author, mail.Author);
                    //}

                    this.InitializeLinkLabel(this.linklblReply, mail.ReplyUrl);

                    /////Reply url.
                    //this.linklblReply.Visible = false;
                    //if (string.IsNullOrEmpty(mail.ReplyUrl) == false)
                    //{
                    //    this.linklblReply.Visible = true;
                    //    this.linklblReply.Text = ControlUtil.GetHyperlinkText(this.linklblReply.Text, mail.ReplyUrl);
                    //    this.linklblReply.Tag = mail;
                    //}

                    this.InitializeLinkLabel(this.linklblTransfer, mail.TransferUrl);

                    /////Transfer url.
                    //this.linklblTransfer.Visible = false;
                    //if (string.IsNullOrEmpty(mail.TransferUrl) == false)
                    //{
                    //    this.linklblTransfer.Visible = true;
                    //    this.linklblTransfer.Text = ControlUtil.GetHyperlinkText(this.linklblTransfer.Text, mail.TransferUrl);
                    //}

                    ///Content.
                    ///Add content.
                    this.richtxtContent.ReadOnly = false;
                    this.richtxtContent.BeginUpdate();
                    Document doc = this.richtxtContent.Document;
                    doc.BeginUpdate();
                    try
                    {
                        this.richtxtContent.Text = mail.Content;

                        {
                            ///Set default font.
                            {
                                CharacterProperties cp = doc.BeginUpdateCharacters(0, doc.Length);
                                cp.FontName = "宋体";
                                cp.FontSize = 9.0F;
                                doc.EndUpdateCharacters(cp);
                            }

                            this.richtxtContent.DeselectAll();
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        doc.EndUpdate();
                        this.richtxtContent.EndUpdate();
                    }


                    this.richtxtContent.ReadOnly = true;
                }
                catch (Exception exp)
                {
                    System.Diagnostics.Debug.WriteLine("Initialize(Mail mail)-" + exp.Message + "\n" + exp.StackTrace);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        public override void SetWidth(int width)
        {
            this.richtxtContent.Width = width - (this.Width - this.richtxtContent.Width);
            this.Width = width;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int ControlHeight
        {
            get
            {
                return 480;
            }
        }

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblTransfer_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnTransferLinkClicked != null)
            {
                this.OnTransferLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblDelete_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnDeleteLinkClicked != null)
            {
                this.OnDeleteLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblReply_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            DevExpress.XtraEditors.HyperlinkLabelControl hlc = sender as DevExpress.XtraEditors.HyperlinkLabelControl;
            if (this.OnReplyLinkClicked != null && hlc != null)
            {
                hlc.Tag = this.Data;
                this.OnReplyLinkClicked(sender, e);
                hlc.Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblID_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnUserLinkClicked != null)
            {
                this.OnUserLinkClicked(sender, e);
            }
        }
        #endregion
#endif
    }
}
