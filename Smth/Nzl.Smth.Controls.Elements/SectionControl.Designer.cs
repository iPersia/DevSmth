namespace Nzl.Smth.Controls.Elements
{
    partial class SectionControl
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
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.linklblSection = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.linklblSection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 28);
            this.panel1.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblType.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblType.Appearance.Options.UseFont = true;
            this.lblType.Appearance.Options.UseForeColor = true;
            this.lblType.Location = new System.Drawing.Point(14, 7);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(24, 12);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "目录";
            // 
            // linklblSection
            // 
            this.linklblSection.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.linklblSection.Appearance.LinkColor = System.Drawing.Color.Blue;
            this.linklblSection.Appearance.Options.UseFont = true;
            this.linklblSection.Appearance.Options.UseLinkColor = true;
            this.linklblSection.Appearance.Options.UsePressedColor = true;
            this.linklblSection.Appearance.Options.UseVisitedColor = true;
            this.linklblSection.Appearance.PressedColor = System.Drawing.Color.Red;
            this.linklblSection.Appearance.VisitedColor = System.Drawing.Color.Green;
            this.linklblSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblSection.Location = new System.Drawing.Point(56, 7);
            this.linklblSection.Name = "linklblSection";
            this.linklblSection.Size = new System.Drawing.Size(42, 12);
            this.linklblSection.TabIndex = 0;
            this.linklblSection.Text = "Section";
            // 
            // SectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SectionControl";
            this.Size = new System.Drawing.Size(554, 28);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblSection;
        private DevExpress.XtraEditors.LabelControl lblType;
    }
}
