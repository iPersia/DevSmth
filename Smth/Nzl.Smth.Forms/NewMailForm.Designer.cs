namespace Nzl.Smth.Forms
{
    partial class NewMailForm
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
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.ckbBackup = new DevExpress.XtraEditors.CheckEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.richtxtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSendTo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.ckbBackup);
            this.panel.Controls.Add(this.btnSend);
            this.panel.Controls.Add(this.richtxtContent);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.txtTitle);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.txtSendTo);
            this.panel.Controls.Add(this.label1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(474, 394);
            this.panel.TabIndex = 0;
            // 
            // ckbBackup
            // 
            this.ckbBackup.EditValue = true;
            this.ckbBackup.Location = new System.Drawing.Point(15, 329);
            this.ckbBackup.Name = "ckbBackup";
            this.ckbBackup.Properties.Caption = "Backup to outbox";
            this.ckbBackup.Size = new System.Drawing.Size(120, 19);
            this.ckbBackup.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSend.Location = new System.Drawing.Point(187, 360);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // richtxtContent
            // 
            this.richtxtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richtxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richtxtContent.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtxtContent.Appearance.Text.Options.UseFont = true;
            this.richtxtContent.Location = new System.Drawing.Point(12, 141);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Size = new System.Drawing.Size(450, 176);
            this.richtxtContent.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Content:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(12, 88);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(450, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title:";
            // 
            // txtSendTo
            // 
            this.txtSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendTo.Location = new System.Drawing.Point(12, 35);
            this.txtSendTo.Name = "txtSendTo";
            this.txtSendTo.Size = new System.Drawing.Size(450, 20);
            this.txtSendTo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send To:";
            // 
            // NewMailForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 394);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "NewMailForm";
            this.Text = "New Mail";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.TextEdit txtSendTo;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.CheckEdit ckbBackup;
        private DevExpress.XtraRichEdit.RichEditControl richtxtContent;
    }
}