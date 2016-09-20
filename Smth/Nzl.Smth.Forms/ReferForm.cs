﻿namespace Nzl.Smth.Forms
{
    using System;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;

    public partial class ReferForm : BaseForm
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly ReferForm Instance = new ReferForm();
        #endregion
            
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReferClicked;

        /// <summary>
        /// 
        /// </summary>
        private Form _parentForm = null;

        /// <summary>
        /// 
        /// </summary>
        private Nzl.Smth.Controls.Complexes.ReferControl _rcRefers = new Smth.Controls.Complexes.ReferControl();

        /// <summary>
        /// 
        /// </summary>
        public ReferForm()
        {
            InitializeComponent();
            this._rcRefers.OnDeleteLinkClicked += ReferControl_OnDeleteLinkClicked;
            this._rcRefers.OnReferLinkClicked += ReferControl_OnReferLinkClicked;
            this._rcRefers.OnUserLinkClicked += ReferControl_OnUserLinkClicked;
            this._rcRefers.Dock = DockStyle.Fill;
            this.Size = new System.Drawing.Size(this._rcRefers.Width + 2 + this.Width - this.panelContainer.Width,
                                                this._rcRefers.Height + 2 + this.Height - this.panelContainer.Height);
            
            this.panelContainer.Controls.Clear();
            this.panelContainer.Controls.Add(this._rcRefers);
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
        private void ReferControl_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void ReferControl_OnReferLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnReferClicked != null)
            {
                this.OnReferClicked(sender, e);
            }

            //HyperlinkLabelControl linkLabel = sender as HyperlinkLabelControl;
            //if (linkLabel != null)
            //{
            //    //this._mailDetailForm.StartPosition = FormStartPosition.CenterParent;
            //    //this._mailDetailForm.Url = e.Link;
            //    //this.HideWhenDeactivate = false;
            //    //this._mailDetailForm.ShowDialog(this._parentForm);
            //    //hlc.Tag = this._mailDetailForm.Tag;                
            //    ////e.Link.Visited = true;
            //    //this._mailDetailForm.Tag = null;
            //    //this.Focus();
            //    //this.HideWhenDeactivate = true;

            //    this._postForm.Url = e.Link;
            //    this._postForm.StartPosition = FormStartPosition.CenterParent;
            //    this.HideWhenDeactivate = false;
            //    this._postForm.ShowDialog(this._parentForm);
            //    //e.Link.Visited = true;
            //    this.Focus();
            //    this.HideWhenDeactivate = true;
            //}
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferControl_OnDeleteLinkClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                NewMailForm form = new NewMailForm();
                form.StartPosition = FormStartPosition.CenterParent;
                this.HideWhenDeactivate = false;
                if (form.ShowDialog(this._parentForm) == DialogResult.OK)
                {
                    btn.Tag = form.GetPostString();
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
