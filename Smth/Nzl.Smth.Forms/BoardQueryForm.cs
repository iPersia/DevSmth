namespace Nzl.Smth.Forms
{
    using System.Windows.Forms;
    using DevExpress.Utils;

    /// <summary>
    /// 
    /// </summary>
    public partial class BoardQueryForm : BaseForm
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly BoardQueryForm Instance = new BoardQueryForm();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardLinkLableClicked;

        /// <summary>
        /// 
        /// </summary>
        private Form _parentForm = null;

        /// <summary>
        /// 
        /// </summary>
        BoardQueryForm()
        {
            InitializeComponent();
            this.bccBoards.OnBoardLinkClicked += BoardControlContainer_OnBoardLinkClicked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardControlContainer_OnBoardLinkClicked(object sender, HyperlinkClickEventArgs e)
        {  
            if (this.OnBoardLinkLableClicked != null)
            {
                this.OnBoardLinkLableClicked(sender, e);
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
        private void btnGo_Click(object sender, System.EventArgs e)
        {
            this.bccBoards.Url = "http://m.newsmth.net/go?name=" + this.txtBoard.Text;
            this.bccBoards.Recycling();
            this.bccBoards.Reusing();
            this.bccBoards.Refetch();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrEmpty(this.txtBoard.Text) == false)
            {
                this.bccBoards.Url = "http://m.newsmth.net/go?name=" + this.txtBoard.Text;
                this.bccBoards.Recycling();
                this.bccBoards.Reusing();
                this.bccBoards.Refetch();
            }
        }
    }
}
