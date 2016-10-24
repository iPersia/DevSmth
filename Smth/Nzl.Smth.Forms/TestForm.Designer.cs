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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.pictureGalleryControl1 = new Nzl.Smth.Controls.Complexes.PictureGalleryControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
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
            this.pictureGalleryControl1.Location = new System.Drawing.Point(12, 130);
            this.pictureGalleryControl1.Name = "pictureGalleryControl1";
            this.pictureGalleryControl1.Pictures = null;
            this.pictureGalleryControl1.Size = new System.Drawing.Size(816, 150);
            this.pictureGalleryControl1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 510);
            this.Controls.Add(this.pictureGalleryControl1);
            this.Name = "TestForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }
        private DevExpress.Utils.ImageCollection imageCollection1;
        private Controls.Complexes.PictureGalleryControl pictureGalleryControl1;

        #endregion

        ///private System.Windows.Forms.RichTextBox richTextBoxEx1;
    }
}