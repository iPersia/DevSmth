﻿namespace Nzl.Smth.Forms
{
    using System;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;

    public partial class MailBoxForm : BaseForm
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly MailBoxForm Instance = new MailBoxForm();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private Form _parentForm = null;

        /// <summary>
        /// 
        /// </summary>
        private Nzl.Smth.Controls.Complexes.MailBoxControl _mbcMails = new Smth.Controls.Complexes.MailBoxControl();

        /// <summary>
        /// 
        /// </summary>
        private MailDetailForm _mailDetailForm = new MailDetailForm();

        /// <summary>
        /// 
        /// </summary>
        public MailBoxForm()
        {
            InitializeComponent();
            this._mbcMails.OnMailLinkClicked += MbcMailBox_OnMailLinkClicked;
            this._mbcMails.OnUserLinkClicked += MbcMailBox_OnUserLinkClicked;
            this._mbcMails.OnDeleteLinkClicked += MbcMailBox_OnDeleteLinkClicked;
            this._mbcMails.OnNewMailClicked += MbcMailBox_OnNewMailClicked;

            this._mbcMails.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Clear();
            this.panelContainer.Controls.Add(this._mbcMails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public void SetParent(Form parent)
        {
            this._parentForm = parent;
        }       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MbcMailBox_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            if (linkLabel != null)
            {
                UserForm form  = new UserForm(e.Link);
                form.StartPosition = FormStartPosition.CenterParent;
                this.HideWhenDeactivate = false;
                form.ShowDialog(this._parentForm);
                this.Focus();
                this.HideWhenDeactivate = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MbcMailBox_OnMailLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this._mailDetailForm.StartPosition = FormStartPosition.CenterParent;
                this._mailDetailForm.Url = e.Link;
                this.HideWhenDeactivate = false;
                this._mailDetailForm.ShowDialog(this._parentForm);
                hlc.Tag = this._mailDetailForm.Tag;
                this._mailDetailForm.Tag = null;
                //e.Link.Visited = true;
                this.Focus();
                this.HideWhenDeactivate = true;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MbcMailBox_OnNewMailClicked(object sender, ItemClickEventArgs e)
        {
            BarManager bm = sender as BarManager;
            if (bm != null)
            {
                NewMailForm form = new NewMailForm();
                form.StartPosition = FormStartPosition.CenterParent;
                this.HideWhenDeactivate = false;
                if (form.ShowDialog(this._parentForm) == DialogResult.OK)
                {
                    e.Item.Tag = form.GetPostString();
                }

                this.Focus();
                this.HideWhenDeactivate = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MbcMailBox_OnDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                if (string.IsNullOrEmpty(e.Link) == false)
                {
                    MessageForm form = new MessageForm("Confirm", "Do you want to delete this mail?");
                    form.StartPosition = FormStartPosition.CenterParent;
                    this.Tag = null;
                    this.HideWhenDeactivate = false;
                    if (form.ShowDialog(this._parentForm) == DialogResult.OK)
                    {
                        hlc.Tag = "Yes";
                        //e.Link.Visited = true;
                    }

                    this.Focus();
                    this.HideWhenDeactivate = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            if (this._parentForm != null)
            {
                this._parentForm.Focus();
            }
        }
    }
}
