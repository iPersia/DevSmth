namespace Nzl.Smth.Controls.Elements
{
    partial class TopControl
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
            this.linklblBoard = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblReplies = new DevExpress.XtraEditors.LabelControl();
            this.linklblTop = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblIndex = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Appearance.Options.UseBackColor = true;
            this.panel.Controls.Add(this.linklblBoard);
            this.panel.Controls.Add(this.lblReplies);
            this.panel.Controls.Add(this.linklblTop);
            this.panel.Controls.Add(this.lblIndex);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(511, 47);
            this.panel.TabIndex = 0;
            // 
            // linklblBoard
            // 
            this.linklblBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblBoard.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblBoard.Appearance.Options.UseFont = true;
            this.linklblBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblBoard.Location = new System.Drawing.Point(402, 14);
            this.linklblBoard.Name = "linklblBoard";
            this.linklblBoard.Size = new System.Drawing.Size(35, 14);
            this.linklblBoard.TabIndex = 7;
            this.linklblBoard.TabStop = true;
            this.linklblBoard.Text = "Board";
            // 
            // lblReplies
            // 
            this.lblReplies.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReplies.Appearance.Options.UseFont = true;
            this.lblReplies.Location = new System.Drawing.Point(92, 16);
            this.lblReplies.Name = "lblReplies";
            this.lblReplies.Size = new System.Drawing.Size(21, 14);
            this.lblReplies.TabIndex = 6;
            this.lblReplies.Text = "(0)";
            this.lblReplies.Visible = false;
            // 
            // linklblTop
            // 
            this.linklblTop.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblTop.Appearance.Options.UseFont = true;
            this.linklblTop.Location = new System.Drawing.Point(52, 16);
            this.linklblTop.Name = "linklblTop";
            this.linklblTop.Size = new System.Drawing.Size(21, 14);
            this.linklblTop.TabIndex = 1;
            this.linklblTop.TabStop = true;
            this.linklblTop.Text = "Top";
            // 
            // lblIndex
            // 
            this.lblIndex.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIndex.Appearance.Options.UseFont = true;
            this.lblIndex.Location = new System.Drawing.Point(20, 16);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(14, 14);
            this.lblIndex.TabIndex = 0;
            this.lblIndex.Text = "10";
            // 
            // TopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "TopControl";
            this.Size = new System.Drawing.Size(511, 47);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl lblIndex;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTop;
        private DevExpress.XtraEditors.LabelControl lblReplies;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblBoard;
    }
}
