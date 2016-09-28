﻿namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Controls.Base;    
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;

    /// <summary>
    /// Thread control.
    /// </summary>
    public partial class ThreadControl : BaseControl<Thread>
    {
        #region events.
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnQueryTypeLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReplyLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnMailLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnEditLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event LinkClickedEventHandler OnTextBoxLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event MouseEventHandler OnTextBoxMouseWheel;
        #endregion

        #region Ctors.
        /// <summary>
        /// Ctor.
        /// </summary>
        public ThreadControl()
        {
            InitializeComponent();
            this.linklblID.HyperlinkClick += new HyperlinkClickEventHandler(linklblID_LinkClicked);
            this.linklblQuryType.HyperlinkClick += new HyperlinkClickEventHandler(linklblQuryType_LinkClicked);
            this.linklblReply.HyperlinkClick += new HyperlinkClickEventHandler(linklblReply_LinkClicked);
            this.linklblMail.HyperlinkClick += new HyperlinkClickEventHandler(linklblMail_LinkClicked);
            this.linklblTransfer.HyperlinkClick += new HyperlinkClickEventHandler(linklblTransfer_LinkClicked);
            this.linklblEdit.HyperlinkClick += new HyperlinkClickEventHandler(linklblEdit_LinkClicked);
            this.linklblDelete.HyperlinkClick += new HyperlinkClickEventHandler(linklblDelete_LinkClicked);
            this.richtxtContent.MouseWheel += new MouseEventHandler(richtxtContent_MouseWheel);

            this.richtxtContent.GotFocus += RichtxtContent_GotFocus;
            this.richtxtContent.SizeChanged += RichtxtContent_SizeChanged;

#if (DEBUG)
            //this.richtxtContent.BorderStyle = BorderStyle.FixedSingle;
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.richtxtContent.Top
                        + this.richtxtContent.Height
                        + (this.richtxtContent.Top - this.panelTitle.Top - this.panelTitle.Height)
                        + 2;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_GotFocus(object sender, EventArgs e)
        {
            this.panel.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        public override void Initialize(Thread thread)
        {
            base.Initialize(thread);
            if (thread != null)
            {
                ///Name
                this.Name = "tc" + thread.ID;

                ///Floor
                this.lblFloor.Visible = true;
                if (thread.Floor == "楼主")
                {
                    this.lblFloor.Text = thread.Floor.PadLeft(4);
                }
                else
                {
                    this.lblFloor.Text = thread.Floor.PadLeft(5);
                }
                
                ///DateTime
                this.lblDateTime.Visible = true;
                this.lblDateTime.Text = thread.DateTime;

                ///Query type
                if (thread.QueryType == "只看此ID")
                {
                    this.linklblQuryType.Text = "Related";
                }
                else
                {
                    this.linklblQuryType.Text = "Spreads";
                }

                this.InitializeLinkLabel(this.linklblQuryType, thread.QueryUrl);
                this.InitializeLinkLabel(this.linklblReply, thread.ReplyUrl);
                this.InitializeLinkLabel(this.linklblMail, thread.MailUrl);
                this.InitializeLinkLabel(this.linklblTransfer, thread.TransferUrl);
                this.InitializeLinkLabel(this.linklblEdit, thread.EditUrl);
                this.InitializeLinkLabel(this.linklblDelete, thread.DeleteUrl);
                this.InitializeLinkLabel(this.linklblID, thread.User, thread.User);

                ///Add content.
                this.richtxtContent.ReadOnly = false;
                this.richtxtContent.Document.Text = "";
                this.richtxtContent.AddContent(thread);
                this.richtxtContent.ReadOnly = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        public override void SetWidth(int width)
        {
            base.SetWidth(width);
            this.Width = width;
            this.panelTitle.Width = this.Width - 12;
            this.richtxtContent.Left = this.panelTitle.Left + 5;
            this.richtxtContent.Width = this.panelTitle.Width - 10;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public override Color BackColor
        {
            set
            {
                this.richtxtContent.Views.SimpleView.BackColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPlainView
        {
            set
            {
                if (value)
                {
                    this.linklblDelete.Visible = false;
                    this.linklblEdit.Visible = false;
                    this.linklblMail.Visible = false;
                    this.linklblReply.Visible = false;
                    this.linklblQuryType.Visible = false;
                    this.linklblTransfer.Visible = false;
                }
            }
        }
        #endregion

        #region Event handler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblID_LinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void linklblQuryType_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnQueryTypeLinkClicked != null)
            {
                this.OnQueryTypeLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblReply_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnReplyLinkClicked != null)
            {
                (sender as LinkLabel).Tag = SmthUtil.GetReplyContent(this.Data);
                this.OnReplyLinkClicked(sender, e);
                (sender as LinkLabel).Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblMail_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnMailLinkClicked != null)
            {
                (sender as LinkLabel).Tag = this.Data.User + "<User>" + SmthUtil.GetReplyContent(this.Data);
                this.OnMailLinkClicked(sender, e);
                (sender as LinkLabel).Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblTransfer_LinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void linklblEdit_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnEditLinkClicked != null)
            {
                (sender as LinkLabel).Tag = SmthUtil.GetReplyContent(this.Data);
                this.OnEditLinkClicked(sender, e);
                (sender as LinkLabel).Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblDelete_LinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void richtxtContent_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.OnTextBoxMouseWheel != null)
            {
                this.OnTextBoxMouseWheel(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richtxtContent_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (this.OnTextBoxLinkClicked != null)
            {
                this.OnTextBoxLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richtxtContent_Enter(object sender, EventArgs e)
        {
            //this.panel.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCopy_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                this.richtxtContent.Copy();
            }
        }
        #endregion
    }
}
