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
            this.panel1.Size = new System.Drawing.Size(475, 24);
            this.panel1.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("宋体", 9F);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblType.Location = new System.Drawing.Point(12, 6);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 12);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "目录";
            // 
            // linklblSection
            // 
            this.linklblSection.AutoSize = true;
            this.linklblSection.Font = new System.Drawing.Font("宋体", 9F);
            this.linklblSection.Location = new System.Drawing.Point(48, 6);
            this.linklblSection.Name = "linklblSection";
            this.linklblSection.Size = new System.Drawing.Size(47, 12);
            this.linklblSection.TabIndex = 0;
            this.linklblSection.TabStop = true;
            this.linklblSection.Text = "Section";
            // 
            // SectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SectionControl";
            this.Size = new System.Drawing.Size(475, 24);
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
