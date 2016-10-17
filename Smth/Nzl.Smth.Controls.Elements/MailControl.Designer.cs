namespace Nzl.Smth.Controls.Elements
{
    partial class MailControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linklblAuthor = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblDT = new DevExpress.XtraEditors.LabelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.linklblDelete = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblIndex = new DevExpress.XtraEditors.LabelControl();
            this.linklblTitle = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // linklblAuthor
            // 
            this.linklblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblAuthor.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblAuthor.Appearance.Options.UseFont = true;
            this.linklblAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblAuthor.Location = new System.Drawing.Point(439, 15);
            this.linklblAuthor.Name = "linklblAuthor";
            this.linklblAuthor.Size = new System.Drawing.Size(78, 12);
            this.linklblAuthor.TabIndex = 3;
            this.linklblAuthor.TabStop = true;
            this.linklblAuthor.Text = "ZZZZZZZZZZZZZ";
            // 
            // lblDT
            // 
            this.lblDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDT.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDT.Appearance.Options.UseFont = true;
            this.lblDT.Location = new System.Drawing.Point(569, 15);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(114, 12);
            this.lblDT.TabIndex = 2;
            this.lblDT.Text = "2013-02-01 01:01:01";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.linklblDelete);
            this.panel.Controls.Add(this.lblIndex);
            this.panel.Controls.Add(this.linklblAuthor);
            this.panel.Controls.Add(this.lblDT);
            this.panel.Controls.Add(this.linklblTitle);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(696, 40);
            this.panel.TabIndex = 1;
            // 
            // linklblDelete
            // 
            this.linklblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblDelete.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblDelete.Appearance.Options.UseFont = true;
            this.linklblDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblDelete.Location = new System.Drawing.Point(523, 15);
            this.linklblDelete.Name = "linklblDelete";
            this.linklblDelete.Size = new System.Drawing.Size(36, 12);
            this.linklblDelete.TabIndex = 5;
            this.linklblDelete.TabStop = true;
            this.linklblDelete.Text = "Delete";
            // 
            // lblIndex
            // 
            this.lblIndex.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIndex.Appearance.Options.UseFont = true;
            this.lblIndex.Location = new System.Drawing.Point(13, 15);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(12, 12);
            this.lblIndex.TabIndex = 4;
            this.lblIndex.Text = "00";
            // 
            // linklblTitle
            // 
            this.linklblTitle.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblTitle.Appearance.Options.UseFont = true;
            this.linklblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblTitle.Location = new System.Drawing.Point(33, 15);
            this.linklblTitle.Name = "linklblTitle";
            this.linklblTitle.Size = new System.Drawing.Size(60, 12);
            this.linklblTitle.TabIndex = 0;
            this.linklblTitle.TabStop = true;
            this.linklblTitle.Text = "Mail Title";
            // 
            // MailControl
            // 
            this.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "MailControl";
            this.Size = new System.Drawing.Size(696, 40);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl linklblAuthor;
        private DevExpress.XtraEditors.LabelControl lblDT;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTitle;
        private DevExpress.XtraEditors.LabelControl lblIndex;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblDelete;
    }
}
