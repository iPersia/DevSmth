namespace Nzl.Smth.Forms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class MessageForm : BaseForm
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public MessageForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;

            this.richtxtMessage.SizeChanged += RichtxtContent_SizeChanged;
            this.richtxtMessage.PopupMenuShowing += RichtxtContent_PopupMenuShowing;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MessageForm(string msg)
            : this()
        {
            this.richtxtMessage.ReadOnly = false;
            this.richtxtMessage.BeginUpdate();
            DevExpress.XtraRichEdit.API.Native.Document doc = this.richtxtMessage.Document;
            doc.BeginUpdate();
            try
            {
                doc.Text = "";
                doc.AppendText(msg);
                this.richtxtMessage.DeselectAll();
            }
            catch
            {

            }
            finally
            {
                doc.EndUpdate();
                this.richtxtMessage.EndUpdate();
            }

            this.richtxtMessage.ReadOnly = true;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MessageForm(string caption, string msg)
            : this(msg)
        {
            this.Text = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.richtxtMessage.Height + 140;
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
