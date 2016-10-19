namespace Nzl.Smth.Controls.Elements
{
    partial class MailDetailControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelUp = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.linklblDelete = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblID = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblTransfer = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblDateTime = new DevExpress.XtraEditors.LabelControl();
            this.linklblReply = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panelDown = new DevExpress.XtraEditors.PanelControl();
            this.richtxtContent = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).BeginInit();
            this.panelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).BeginInit();
            this.panelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.panelUp.Appearance.Options.UseBackColor = true;
            this.panelUp.Controls.Add(this.lblTitle);
            this.panelUp.Controls.Add(this.linklblDelete);
            this.panelUp.Controls.Add(this.linklblID);
            this.panelUp.Controls.Add(this.linklblTransfer);
            this.panelUp.Controls.Add(this.lblDateTime);
            this.panelUp.Controls.Add(this.linklblReply);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(700, 69);
            this.panelUp.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(14, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(24, 14);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // linklblDelete
            // 
            this.linklblDelete.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblDelete.Appearance.Options.UseFont = true;
            this.linklblDelete.Location = new System.Drawing.Point(155, 42);
            this.linklblDelete.Name = "linklblDelete";
            this.linklblDelete.Size = new System.Drawing.Size(36, 12);
            this.linklblDelete.TabIndex = 11;
            this.linklblDelete.TabStop = true;
            this.linklblDelete.Text = "Delete";
            // 
            // linklblID
            // 
            this.linklblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblID.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblID.Appearance.Options.UseFont = true;
            this.linklblID.Location = new System.Drawing.Point(582, 42);
            this.linklblID.Name = "linklblID";
            this.linklblID.Size = new System.Drawing.Size(72, 12);
            this.linklblID.TabIndex = 2;
            this.linklblID.TabStop = true;
            this.linklblID.Text = "IDIDIDIDIDID";
            // 
            // linklblTransfer
            // 
            this.linklblTransfer.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblTransfer.Appearance.Options.UseFont = true;
            this.linklblTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblTransfer.Location = new System.Drawing.Point(72, 42);
            this.linklblTransfer.Name = "linklblTransfer";
            this.linklblTransfer.Size = new System.Drawing.Size(48, 12);
            this.linklblTransfer.TabIndex = 10;
            this.linklblTransfer.TabStop = true;
            this.linklblTransfer.Text = "Transfer";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(222, 43);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(118, 14);
            this.lblDateTime.TabIndex = 4;
            this.lblDateTime.Text = "2013-02-22 23:53:35";
            // 
            // linklblReply
            // 
            this.linklblReply.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblReply.Appearance.Options.UseFont = true;
            this.linklblReply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblReply.Location = new System.Drawing.Point(14, 42);
            this.linklblReply.Name = "linklblReply";
            this.linklblReply.Size = new System.Drawing.Size(30, 12);
            this.linklblReply.TabIndex = 9;
            this.linklblReply.TabStop = true;
            this.linklblReply.Text = "Reply";
            // 
            // panelDown
            // 
            this.panelDown.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelDown.Appearance.Options.UseBackColor = true;
            this.panelDown.Controls.Add(this.richtxtContent);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 69);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(700, 491);
            this.panelDown.TabIndex = 0;
            // 
            // richtxtContent
            // 
            this.richtxtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richtxtContent.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtxtContent.Appearance.Text.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.richtxtContent.Appearance.Text.Options.UseBackColor = true;
            this.richtxtContent.Appearance.Text.Options.UseFont = true;
            this.richtxtContent.Appearance.Text.Options.UseTextOptions = true;
            this.richtxtContent.Appearance.Text.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.richtxtContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richtxtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richtxtContent.Location = new System.Drawing.Point(2, 2);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Size = new System.Drawing.Size(696, 487);
            this.richtxtContent.TabIndex = 13;
            // 
            // MailDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Name = "MailDetailControl";
            this.Size = new System.Drawing.Size(700, 560);
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).EndInit();
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).EndInit();
            this.panelDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblDelete;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTransfer;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblReply;
        private DevExpress.XtraEditors.LabelControl lblDateTime;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblID;
        private DevExpress.XtraEditors.PanelControl panelUp;
        private DevExpress.XtraEditors.PanelControl panelDown;
        private DevExpress.XtraRichEdit.RichEditControl richtxtContent;
    }
}
