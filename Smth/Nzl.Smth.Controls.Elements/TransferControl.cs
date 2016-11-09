namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Web.Util;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class TransferControl : BaseElementControl<Transfer>
    //public partial class TransferControl : XtraUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferClikced;

        /// <summary>
        /// Ctor.
        /// </summary>
        public TransferControl()
        {
            InitializeComponent();

            ///For ToString.
            this.Text = "The transfer control";

            ///
            this.linklblTransfer.HyperlinkClick += LinklblTransfer_HyperlinkClick;
        }

        /// <summary>
        /// 
        /// target=Nesus&threads=on&noref=on&noatt=on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblTransfer_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnTransferClikced != null)
            {
                if (string.IsNullOrEmpty(this.Data.Url) == false &&
                    string.IsNullOrWhiteSpace(this.cmbUsers.Text) == false)
                {
                    string postString = "target=" + this.cmbUsers.Text;
                    if (this.ckbThreads.Checked)
                    {
                        postString += "&threads=on";
                    }

                    if (this.ckbNoRef.Checked)
                    {
                        postString += "&noref=on";
                    }

                    if (this.ckbNoAtt.Checked)
                    {
                        postString += "&noatt=on";
                    }

                    e.Text = postString;
                    this.OnTransferClikced(sender, e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transfer"></param>
        public override void Initialize(Transfer transfer)
        {
            base.Initialize(transfer);
            this.cmbUsers.Properties.Items.Clear();
            this.cmbUsers.SelectedIndex = -1;
            this.ckbThreads.Checked = false;
            this.ckbNoRef.Checked = false;
            this.ckbNoAtt.Checked = false;
            this.ckbThreads.Visible = false;
            this.ckbNoRef.Visible = false;
            this.ckbNoAtt.Visible = false;
            this.linklblTransfer.Text = "Transfer";
            if (transfer != null)
            {
                this.InitializeLinkLabel(this.linklblTransfer, transfer.Url);
                if (transfer.Users != null)
                {
                    foreach (string user in transfer.Users)
                    {
                        this.cmbUsers.Properties.Items.Add(user);
                    }
                }                

                this.ckbThreads.Checked = false;
                this.ckbNoRef.Checked = false;
                this.ckbNoAtt.Checked = false;

                this.ckbThreads.Visible = transfer.IsShowThreads;
                this.ckbNoAtt.Visible = transfer.IsShowNoRef;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbThreads_CheckedChanged(object sender, EventArgs e)
        {
            this.ckbNoRef.Visible = this.ckbThreads.Checked;
            if (this.ckbThreads.Checked == false)
            {
                this.ckbNoRef.Checked = false;
            }
        }
    }
}

