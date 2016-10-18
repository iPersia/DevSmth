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
            this.richtxtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.richEditControl2 = new DevExpress.XtraRichEdit.RichEditControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // richtxtContent
            // 
            this.richtxtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richtxtContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richtxtContent.Location = new System.Drawing.Point(12, 63);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.ReadOnly = true;
            this.richtxtContent.Size = new System.Drawing.Size(320, 196);
            this.richtxtContent.TabIndex = 0;
            this.richtxtContent.Text = "<h1>Big</h1>";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(21, 24);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(74, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // richEditControl2
            // 
            this.richEditControl2.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richEditControl2.Location = new System.Drawing.Point(396, 63);
            this.richEditControl2.Name = "richEditControl2";
            this.richEditControl2.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditControl2.ReadOnly = true;
            this.richEditControl2.Size = new System.Drawing.Size(265, 447);
            this.richEditControl2.TabIndex = 2;
            this.richEditControl2.Text = "<h1>Big</h1>";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(396, 24);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(74, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 510);
            this.Controls.Add(this.richEditControl2);
            this.Controls.Add(this.richtxtContent);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "TestForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Mail Detail";
            this.ResumeLayout(false);

        }

        private DevExpress.XtraRichEdit.RichEditControl richtxtContent;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;

        #endregion

        ///private System.Windows.Forms.RichTextBox richTextBoxEx1;
    }
}