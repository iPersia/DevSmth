namespace Nzl.Smth.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DevExpress.Office;
    using DevExpress.Office.Services;
    using DevExpress.Office.Utils;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Controls.Complexes;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class TransferForm : BaseForm
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public TransferForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;

            this.tccContainer.OnTransferClikced += TransferControlContainer_OnTransferClikced;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferControlContainer_OnTransferClikced(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                MessageForm form = new MessageForm("Confirmation", "Do you want to tranfer the content?");
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    hlc.Tag = "Yes";

                    this.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void SetUrl(string url)
        {
            this.tccContainer.Url = url;
        }
    }
}