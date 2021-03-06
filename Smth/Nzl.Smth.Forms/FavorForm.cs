﻿namespace Nzl.Smth.Forms
{
    using System.Windows.Forms;
    using DevExpress.Utils;

    /// <summary>
    /// 
    /// </summary>
    public partial class FavorForm : BaseForm
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly FavorForm Instance = new FavorForm();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnFavorBoardLinkLableClicked;

        /// <summary>
        /// 
        /// </summary>
        private Form _parentForm = null;

        /// <summary>
        /// 
        /// </summary>
        FavorForm()
        {
            InitializeComponent();
            this.bccFavor.OnBoardLinkClicked += FcFavor_OnBoardLinkClicked;

            ///
            this.btnRefresh.Left = (this.panelMenu.Width - this.btnRefresh.Width) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FcFavor_OnBoardLinkClicked(object sender, HyperlinkClickEventArgs e)
        {  
            if (this.OnFavorBoardLinkLableClicked != null)
            {
                this.OnFavorBoardLinkLableClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FavorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            if (this._parentForm != null)
            {
                this._parentForm.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.bccFavor.Refetch();
        }
    }
}
