namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DevExpress.Office.Services;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;

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
            ///For ToString.
            this.Text = "The thread control";

            ///
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

            this.richtxtContent.PopupMenuShowing += RichtxtContent_PopupMenuShowing;

            ///Used to get image stream.
            IUriStreamService uriStreamService = this.richtxtContent.GetService<IUriStreamService>();
            uriStreamService.RegisterProvider(new ImageStreamProvider());

            ///
            this.richtxtContent.DocumentLoaded += RichtxtContent_DocumentLoaded;

#if (X)
            //this.richtxtContent.BorderStyle = BorderStyle.FixedSingle;
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_PopupMenuShowing(object sender, DevExpress.XtraRichEdit.PopupMenuShowingEventArgs e)
        {
            e.Menu = null;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_DocumentLoaded(object sender, EventArgs e)
        {
#if (X)
            System.Diagnostics.Debug.WriteLine(this.GetHashCode() + "\t ThreadControl - RichtxtContent_DocumentLoaded - this.Height" + this.Height);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_SizeChanged(object sender, EventArgs e)
        {
            if (this.Parent == null)
            {
                this.Height = this.richtxtContent.Top
                            + this.richtxtContent.Height
                            + (this.richtxtContent.Top - this.panelTitle.Top - this.panelTitle.Height)
                            + 2;
            }

#if (X)
            System.Diagnostics.Debug.WriteLine(this.GetHashCode() + "\t ThreadControl - RichtxtContent_SizeChanged - this.Height" + this.Height);
#endif
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
            this.HyperlinkLabelControls.Add(linklblQuryType);
            this.HyperlinkLabelControls.Add(lblCopy);
            this.HyperlinkLabelControls.Add(linklblReply);
            this.HyperlinkLabelControls.Add(linklblMail);
            this.HyperlinkLabelControls.Add(linklblTransfer);
            this.HyperlinkLabelControls.Add(linklblDelete);
            this.HyperlinkLabelControls.Add(linklblEdit);
        }

        /// <summary>
        /// 
        /// </summary>
        private static string _staticNewlineToken = "_TOKEN_";

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadContentIPRegex = new Regex(@"(--)?<br />(修改:[a-zA-z][a-zA-Z0-9]{1,11} FROM (\d+\.){3}(\*|\d+)<br />)?FROM (\d+\.){3}(\*|\d+)(<br />)?");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadContentMobileModifyRegex = new Regex(@"※ 修改:·[a-zA-z][a-zA-Z0-9]{1,11} 于 [A-Z][a-z]{2}[^\d]+\d+ \d{2}:\d{2}:\d{2} \d{4} 修改本文·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>※ 来源:·水木社区 <a target=\W_blank\W href=\Whttp://m.newsmth.net\W>http://m.newsmth.net</a>·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadContentForumModifyRegex = new Regex(@"※ 修改:·[a-zA-z][a-zA-Z0-9]{1,11} 于 [A-Z][a-z]{2}[^\d]+\d+ \d{2}:\d{2}:\d{2} \d{4} 修改本文·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>※ 来源:·水木社区 <a target=\W_blank\W href=\Whttp://www.newsmth.net\W>http://www.newsmth.net</a>·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadReplyPattern = new Regex(@"【 在 [a-zA-z][a-zA-Z0-9]{1,11} (\((.+)?\) )?的大作中提到: 】");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticIPRegexForColor = new Regex(_staticNewlineToken + @"\s*--\s*" + _staticNewlineToken + @"\s*(修改:[a-zA-z][a-zA-Z0-9]{1,11} FROM (\d+\.){3}(\*|\d+)\s*" + _staticNewlineToken + @"\s*)?FROM (\d+\.){3}(\*|\d+)");

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

                ///Linklabel.
                this.InitializeLinkLabel(this.linklblQuryType, thread.QueryUrl);
                this.InitializeLinkLabel(this.linklblReply, thread.ReplyUrl);
                this.InitializeLinkLabel(this.linklblMail, thread.MailUrl);
                this.InitializeLinkLabel(this.linklblTransfer, thread.TransferUrl);
                this.InitializeLinkLabel(this.linklblEdit, thread.EditUrl);
                this.InitializeLinkLabel(this.linklblDelete, thread.DeleteUrl);
                this.InitializeLinkLabel(this.linklblID, thread.User, thread.User);

                ///Add content.
                this.richtxtContent.ReadOnly = false;
                this.richtxtContent.BeginUpdate();
                Document doc = this.richtxtContent.Document;                
                try
                {
                    ///Trim ip.
                    if (Configuration.ShowIPinTopic == false)
                    {
                        string contentHtml = _staticThreadContentIPRegex.Replace(thread.ContentHtml, "");
                        contentHtml = _staticThreadContentMobileModifyRegex.Replace(contentHtml, "");
                        contentHtml = _staticThreadContentForumModifyRegex.Replace(contentHtml, "");
                        thread.ContentHtml = contentHtml;
                    }

                    
                    this.richtxtContent.HtmlText = thread.ContentHtml.Replace("<br>", _staticNewlineToken).Replace("<br />", _staticNewlineToken).Replace("<br/>", _staticNewlineToken);
                    {
                        ///Set default font.                        
                        {
                            doc.BeginUpdate();
                            CharacterProperties cp = doc.BeginUpdateCharacters(0, doc.Length);
                            cp.FontName = "宋体";
                            cp.FontSize = 10.5F;
                            doc.EndUpdateCharacters(cp);
                            doc.EndUpdate();
                        }

                        ///Colored the replied thread content.
                        {
                            doc.BeginUpdate();

                            ///Find the reply head.
                            DocumentRange drReplyHeader = null;
                            {
                                DocumentRange[] drs = doc.FindAll(_staticThreadReplyPattern);
                                foreach (DocumentRange dr in drs)
                                {
                                    CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                                    cp.FontName = "宋体";
                                    cp.FontSize = 9;
                                    cp.ForeColor = Color.FromArgb(96, 96, 96);
                                    doc.EndUpdateCharacters(cp);

                                    drReplyHeader = dr;
                                    break;
                                }
                            }

                            ///Find the reply content.
                            {
                                if (drReplyHeader != null)
                                {
                                    DocumentRange[] drs = doc.FindAll(_staticNewlineToken, SearchOptions.None);
                                    DocumentRange drPrev = drReplyHeader;
                                    foreach (DocumentRange dr in drs)
                                    {
                                        if (dr.Start > drReplyHeader.End)
                                        {
                                            DocumentRange targetRange = doc.CreateRange(drPrev.End, dr.End.ToInt() - drPrev.End.ToInt());
                                            string content = doc.GetText(targetRange);
                                            {
                                                content = content.Replace(_staticNewlineToken, "");
                                                if (content.StartsWith(":"))
                                                {
                                                    CharacterProperties cp = doc.BeginUpdateCharacters(targetRange);
                                                    cp.FontName = "宋体";
                                                    cp.FontSize = 9;
                                                    cp.ForeColor = Color.FromArgb(96, 96, 96);
                                                    doc.EndUpdateCharacters(cp);                                                    
                                                }
                                            }
                                        }

                                        drPrev = dr;
                                    }
                                }
                            }

                            doc.EndUpdate();
                        }

                        ///Colored the From IP.
                        if (Configuration.ShowIPinTopic)
                        {
                            doc.BeginUpdate();
                            DocumentRange[] drsa = doc.FindAll(_staticIPRegexForColor);
                            foreach (DocumentRange dr in drsa)
                            {
#if (DEBUG)
                                System.Diagnostics.Debug.WriteLine(this.Data.ID + "\t" + dr.Length + "\t" + doc.GetText(dr));
#endif
                                CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                                cp.FontName = "宋体";
                                cp.FontSize = 9;
                                cp.ForeColor = Color.FromArgb(160, 160, 160);
                                doc.EndUpdateCharacters(cp);
                            }

                            doc.EndUpdate();
                        }

                        ///Colored the reply tail.
                        {
                            doc.BeginUpdate();
                            string repleyContent = SmthUtil.GetReplyText().Replace(@"\s+", _staticNewlineToken);
                            DocumentRange[] drs = doc.FindAll(repleyContent, SearchOptions.None);
                            foreach (DocumentRange dr in drs)
                            {
#if (DEBUG)
                                System.Diagnostics.Debug.WriteLine(this.Data.ID + "\t" + dr.Length + "\t" + doc.GetText(dr));
#endif

                                CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                                cp.FontName = "宋体";
                                cp.FontSize = 9;
                                doc.EndUpdateCharacters(cp);
                            }

                            doc.EndUpdate();
                        }

                        ///Replace by newline
                        {
                            doc.BeginUpdate();
                            DocumentRange[] drs = doc.FindAll(_staticNewlineToken, SearchOptions.None);
                            for (int i = drs.Length - 1; i >= 0; i--)
                            {
                                doc.Replace(drs[i], Environment.NewLine);
                            }

                            doc.EndUpdate();
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
                this.richtxtContent.Enabled = this.richtxtContent.Document.Images.Count > 0 || 
                                              this.richtxtContent.Document.Hyperlinks.Count > 0;
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
                (sender as HyperlinkLabelControl).Tag = SmthUtil.GetReplyContent(this.Data);
                this.OnReplyLinkClicked(sender, e);
                (sender as HyperlinkLabelControl).Tag = null;
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
                (sender as HyperlinkLabelControl).Tag = this.Data.User + "<User>" + SmthUtil.GetReplyContent(this.Data);
                this.OnMailLinkClicked(sender, e);
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
                (sender as HyperlinkLabelControl).Tag = SmthUtil.GetReplyContent(this.Data);
                this.OnEditLinkClicked(sender, e);
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
                this.richtxtContent.SelectAll();
                this.richtxtContent.Copy();
                this.richtxtContent.DeselectAll();
            }
        }
        #endregion
    }    
}
