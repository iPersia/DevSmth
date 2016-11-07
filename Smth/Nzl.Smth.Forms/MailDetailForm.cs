namespace Nzl.Smth.Forms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Smth.Controls.Containers;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class MailDetailForm : BaseForm
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferLinkClicked;
        #endregion 

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private string _url = null;

        /// <summary>
        /// 
        /// </summary>
        private MailDetailControlContainer _mccContainer = new MailDetailControlContainer();
        #endregion

        #region Ctor
        /// <summary>
        /// Ctor.
        /// </summary>
        public MailDetailForm()
        {
            InitializeComponent();
            this._mccContainer.Left = 1;
            this._mccContainer.Top = 1;
            this._mccContainer.OnMailAuthorLinkClicked += Mdcc_OnMailAuthorLinkClicked;
            this._mccContainer.OnMailDeleteLinkClicked += Mdcc_OnMailDeleteLinkClicked;
            this._mccContainer.OnMailReplyLinkClicked += Mdcc_OnMailReplyLinkClicked;
            this._mccContainer.OnMailTransferLinkClicked += Mdcc_OnMailTransferLinkClicked;            
            this._mccContainer.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(this._mccContainer.Width + this.Width - this.panelContainer.Width + 2,
                                 this._mccContainer.Height + this.Height - this.panelContainer.Height + 2);
            this.panelContainer.Controls.Add(this._mccContainer);

            ///
            this.HideWhenDeactivate = false;

            ///First loading.
            this._mccContainer.CreateControl();
            this._mccContainer.SetParentControl(this);
        }
        #endregion

        #region properties
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set
            {
                this._mccContainer.Url = value;
            }
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mdcc_OnMailTransferLinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void Mdcc_OnMailReplyLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                Mail mail = linkLabel.Tag as Mail;
                if (mail != null)
                {
                    string content = SmthUtil.GetReplyContent(mail.Title, mail.Content);
                    NewMailForm newMailForm = new NewMailForm(mail.Author, mail.Title, content);
                    newMailForm.StartPosition = FormStartPosition.CenterParent;
                    this.Tag = null;
                    if (newMailForm.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Tag = "ReplyMail" + newMailForm.GetPostString();
                        //e.Link.Visited = true;
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mdcc_OnMailDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                if (string.IsNullOrEmpty(e.Link) == false)
                {
                    MessageForm form = new MessageForm("Confirm", "Do you want to delete this mail?");
                    form.StartPosition = FormStartPosition.CenterParent;
                    this.Tag = null;
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Tag = "ConfirmToDelete" + e.Link;
                        //e.Link.Visited = true;
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mdcc_OnMailAuthorLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                UserForm userForm = new UserForm(e.Link);
                userForm.StartPosition = FormStartPosition.CenterParent;
                userForm.ShowDialog(this);
            }
        }
        #endregion
    }
}
