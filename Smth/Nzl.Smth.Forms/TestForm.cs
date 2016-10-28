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
    public partial class TestForm : BaseForm
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public TestForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;
        }

        IList<Image> images = new List<Image>();

        private void TestForm_Load(object sender, EventArgs e)
        {
            
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150531045005.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150608191242.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150609184731.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150609184734.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614090618.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614090659.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614090729.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614093659.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614180029.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614180033.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614180035.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614180037.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614180038.jpg"));
            images.Add(Image.FromFile(@"d:\Images\Camera-K910\20150630\20150614180039.jpg"));
            this.pictureGalleryControl1.Pictures = images;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.pictureGalleryControl1.SelectImage(images[5]);
        }
    }
}