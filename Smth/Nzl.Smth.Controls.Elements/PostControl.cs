﻿namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Office.Services;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Utils;

    /// <summary>
    /// Thread control.
    /// </summary>
    public partial class PostControl : BaseElementControl<Post>
    {
        #region events.
        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnNewClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnReplyClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnExpandClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnHostClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnSubjectExpandClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnSourceClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnLastClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnNextClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnSubjectLastClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnSubjectNextClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnMailClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnUserClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnEditClicked;

        /// <summary>
        ///
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteClicked;

        /// <summary>
        /// 
        /// </summary>
        public event DevExpress.XtraRichEdit.HyperlinkClickEventHandler OnTextBoxLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event MouseEventHandler OnTextBoxMouseWheel;
        #endregion

        #region Ctors.
        /// <summary>
        /// Ctor.
        /// </summary>
        public PostControl()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The post control";

            this.richtxtContent.GotFocus += RichtxtContent_GotFocus;
            this.richtxtContent.MouseWheel += new MouseEventHandler(richtxtContent_MouseWheel);
            this.richtxtContent.SizeChanged += RichtxtContent_SizeChanged;

            ///Need to be optimized.
            ///Used to get image stream.
            IUriStreamService uriStreamService = this.richtxtContent.GetService<IUriStreamService>();
            uriStreamService.RegisterProvider(new ImageStreamProvider());

            ///
            this.richtxtContent.HyperlinkClick += richtxtContent_LinkClicked;
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
        public override void PrepareControls()
        {
            base.PrepareControls();

            ///
            this.HyperlinkLabelControls.Add(linklblID);
            this.HyperlinkLabelControls.Add(lblCopy);
            this.HyperlinkLabelControls.Add(linklblReply);
            this.HyperlinkLabelControls.Add(linklblTransfer);
            this.HyperlinkLabelControls.Add(linklblExpand);
            this.HyperlinkLabelControls.Add(linklblHost);
            this.HyperlinkLabelControls.Add(linklblSubjectExpand);
            this.HyperlinkLabelControls.Add(linklblSource);
            this.HyperlinkLabelControls.Add(linklblBoard);
            this.HyperlinkLabelControls.Add(linklblLast);
            this.HyperlinkLabelControls.Add(linklblNext);
            this.HyperlinkLabelControls.Add(linklblSubjectLast);
            this.HyperlinkLabelControls.Add(linklblSubjectNext);
            this.HyperlinkLabelControls.Add(linklblNew);
            this.HyperlinkLabelControls.Add(linklblMail);
            this.HyperlinkLabelControls.Add(linklblDelete);
            this.HyperlinkLabelControls.Add(linklblEdit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        public override void Initialize(Post refer)
        {
            base.Initialize(refer);
            if (refer != null)
            {
                ///DateTime
                this.lblDateTime.Visible = true;
                this.lblDateTime.Text = refer.DateTime;

                ///Subject
                this.lblSubject.Text = refer.Subject;
                this.lblSubject.Visible = true;
                this.linklblExpand.Tag = refer.Subject != null ? refer.Subject.Replace("主题:Re: ", "") : "";
                this.linklblSubjectExpand.Tag = refer.Subject != null ? refer.Subject.Replace("主题:Re: ", "") : "";

                ///ID
                this.linklblID.Text = refer.Author;

                ///Board
                this.linklblBoard.Text = refer.Board;
                                    
                ///Urls
                this.InitializeLinkLabel(this.linklblBoard, refer.Board);
                this.InitializeLinkLabel(this.linklblDelete, refer.DeleteUrl);
                this.InitializeLinkLabel(this.linklblEdit, refer.EditUrl);
                this.InitializeLinkLabel(this.linklblExpand, refer.ExpandUrl);
                this.InitializeLinkLabel(this.linklblHost, refer.HostUrl);
                this.InitializeLinkLabel(this.linklblID, refer.Author);
                this.InitializeLinkLabel(this.linklblLast, refer.LastUrl);
                this.InitializeLinkLabel(this.linklblMail, refer.MailUrl);
                this.InitializeLinkLabel(this.linklblNew, refer.NewUrl);
                this.InitializeLinkLabel(this.linklblNext, refer.NextUrl);
                this.InitializeLinkLabel(this.linklblReply, refer.ReplyUrl);
                this.InitializeLinkLabel(this.linklblSource, refer.SourceUrl);
                this.InitializeLinkLabel(this.linklblSubjectExpand, refer.SubjectExpandUrl);
                this.InitializeLinkLabel(this.linklblSubjectLast, refer.SubjectLastUrl);
                this.InitializeLinkLabel(this.linklblSubjectNext, refer.SubjectNextUrl);
                this.InitializeLinkLabel(this.linklblTransfer, refer.TransferUrl);

                ///Tag
                this.linklblExpand.Tag = refer.Subject.Replace("主题:Re: ", "");
                this.linklblSubjectExpand.Tag = refer.Subject.Replace("主题:Re: ", "");

                ///Add content.
                this.richtxtContent.ReadOnly = false;
                this.richtxtContent.ApplyContent(refer.Data.ContentHtml);
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
                this.panel.BackColor = value;
                this.richtxtContent.BackColor = value;
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
            if (this.OnUserClicked != null)
            {
                this.OnUserClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblReply_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnReplyClicked != null)
            {
                (sender as HyperlinkLabelControl).Tag = SmthUtil.GetReplyContent(this.Data.Author, this.Data.Content);
                this.OnReplyClicked(sender, e);
                (sender as HyperlinkLabelControl).Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblTransfer_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnTransferClicked != null)
            {
                this.OnTransferClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblNew_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnNewClicked!=null)
            {
                this.OnNewClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblExpand_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnExpandClicked != null)
            {
                this.OnExpandClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblHost_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnHostClicked != null)
            {
                this.OnHostClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblSubjectExpand_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnSubjectExpandClicked != null)
            {
                this.OnSubjectExpandClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblSource_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnSourceClicked != null)
            {
                this.OnSourceClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblBoard_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnBoardClicked != null)
            {
                this.OnBoardClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblLast_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnLastClicked != null)
            {
                this.OnLastClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblNext_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnNextClicked != null)
            {
                this.OnNextClicked(sender, e);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblSubjectLast_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnSubjectLastClicked != null)
            {
                this.OnSubjectLastClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblSubjectNext_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnSubjectNextClicked != null)
            {
                this.OnSubjectNextClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblMail_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnMailClicked != null)
            {
                (sender as HyperlinkLabelControl).Tag = this.Data.Author + "<User>" + SmthUtil.GetReplyContent(this.Data.Author, this.Data.Content);
                this.OnMailClicked(sender, e);
                (sender as HyperlinkLabelControl).Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblEdit_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnEditClicked != null)
            {
                (sender as HyperlinkLabelControl).Tag = SmthUtil.GetReplyContent(this.Data.Author, this.Data.Content);
                this.OnEditClicked(sender, e);
                (sender as HyperlinkLabelControl).Tag = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblDelete_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnDeleteClicked != null)
            {
                this.OnDeleteClicked(sender, e);
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
        private void richtxtContent_LinkClicked(object sender, DevExpress.XtraRichEdit.HyperlinkClickEventArgs e)
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
            this.panel.Focus();
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
                this.richtxtContent.SelectAll();
                this.richtxtContent.Copy();
                this.richtxtContent.DeselectAll();
            }
        }
        #endregion
    }
}
