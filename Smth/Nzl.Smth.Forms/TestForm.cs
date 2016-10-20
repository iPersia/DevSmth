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
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Controls.Complexes;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class TestForm : BaseForm
    {

        PictureBrowserControl ibc = null;

        /// <summary>
        /// Ctor.
        /// </summary>
        public TestForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;

            LinkedList<PictureTopic> pts = Nzl.Smth.Loaders.PictureTopicLoader.Instance.PictureTopics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ibc = new PictureBrowserControl();
            ibc.Top = 1;
            ibc.Left = 1;
            this.panelControl2.Controls.Add(ibc);

            ibc.Dock = DockStyle.Fill;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ibc.RefreshEx();
        }
    }
}
