namespace Nzl.Smth.Forms
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.pictureGalleryControl1 = new Nzl.Smth.Controls.Complexes.PictureGalleryControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.pictureBrowserControl1 = new Nzl.Smth.Controls.Complexes.PictureBrowserControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "$$7GL5RWWOB]O9PVOG1Q1YR.jpg");
            this.imageCollection1.Images.SetKeyName(1, "$%7P~1LA(20%242`}[FO]`B.jpg");
            this.imageCollection1.Images.SetKeyName(2, "$%G)5)Q27F)9SCFHVTTEWV5.jpg");
            this.imageCollection1.Images.SetKeyName(3, "$%K@$5}`4RQ(28W5UM~@JHV.jpg");
            this.imageCollection1.Images.SetKeyName(4, "$]DQU}8}QNTK1631E53I)W4.jpg");
            // 
            // pictureGalleryControl1
            // 
            this.pictureGalleryControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureGalleryControl1.Location = new System.Drawing.Point(2, 2);
            this.pictureGalleryControl1.Name = "pictureGalleryControl1";
            this.pictureGalleryControl1.Pictures = null;
            this.pictureGalleryControl1.Size = new System.Drawing.Size(987, 292);
            this.pictureGalleryControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(37, 69);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureGalleryControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 185);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(991, 296);
            this.panelControl1.TabIndex = 2;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(997, 510);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Controls.Add(this.simpleButton1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(991, 481);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.pictureBrowserControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(991, 481);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // pictureBrowserControl1
            // 
            this.pictureBrowserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBrowserControl1.Location = new System.Drawing.Point(0, 0);
            this.pictureBrowserControl1.Name = "pictureBrowserControl1";
            this.pictureBrowserControl1.Size = new System.Drawing.Size(991, 481);
            this.pictureBrowserControl1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 510);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "TestForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private DevExpress.Utils.ImageCollection imageCollection1;
        private Controls.Complexes.PictureGalleryControl pictureGalleryControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Controls.Complexes.PictureBrowserControl pictureBrowserControl1;

        #endregion

        ///private System.Windows.Forms.RichTextBox richTextBoxEx1;
    }
}