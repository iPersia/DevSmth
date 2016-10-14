namespace Nzl.Smth.Controls.Elements
{
    partial class BoardControl
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
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.lblType = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblBoard = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lblType);
            this.panel.Controls.Add(this.linklblBoard);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(554, 28);
            this.panel.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblType.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblType.Appearance.Options.UseFont = true;
            this.lblType.Appearance.Options.UseForeColor = true;
            this.lblType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblType.Location = new System.Drawing.Point(14, 7);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(24, 12);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "版面";
            // 
            // linklblBoard
            // 
            this.linklblBoard.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.linklblBoard.Appearance.Options.UseFont = true;
            this.linklblBoard.Appearance.Options.UseLinkColor = true;
            this.linklblBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblBoard.Location = new System.Drawing.Point(56, 7);
            this.linklblBoard.Name = "linklblBoard";
            this.linklblBoard.Size = new System.Drawing.Size(30, 12);
            this.linklblBoard.TabIndex = 0;
            this.linklblBoard.TabStop = true;
            this.linklblBoard.Text = "Board";
            // 
            // BoardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "BoardControl";
            this.Size = new System.Drawing.Size(554, 28);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblBoard;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblType;
    }
}
