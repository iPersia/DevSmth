namespace Nzl.Smth.Controls.Elements
{
    partial class ThreadControl
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
            this.lblFloor = new DevExpress.XtraEditors.LabelControl();
            this.linklblID = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.richtxtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.linklblEdit = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblDelete = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblTransfer = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblDateTime = new DevExpress.XtraEditors.LabelControl();
            this.linklblMail = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblQuryType = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblReply = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblCopy = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFloor
            // 
            this.lblFloor.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloor.Appearance.Options.UseFont = true;
            this.lblFloor.Location = new System.Drawing.Point(11, 5);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(36, 12);
            this.lblFloor.TabIndex = 0;
            this.lblFloor.Text = "9999楼";
            this.lblFloor.Visible = false;
            // 
            // linklblID
            // 
            this.linklblID.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblID.Appearance.Options.UseFont = true;
            this.linklblID.Location = new System.Drawing.Point(62, 5);
            this.linklblID.Name = "linklblID";
            this.linklblID.Size = new System.Drawing.Size(72, 12);
            this.linklblID.TabIndex = 1;
            this.linklblID.TabStop = true;
            this.linklblID.Text = "IDIDIDIDIDID";
            this.linklblID.Visible = false;
            // 
            // panel
            // 
            this.panel.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Appearance.Options.UseBackColor = true;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Controls.Add(this.richtxtContent);
            this.panel.Controls.Add(this.panelTitle);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(700, 70);
            this.panel.TabIndex = 4;
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
            this.richtxtContent.AutoSizeMode = DevExpress.XtraRichEdit.AutoSizeMode.Vertical;
            this.richtxtContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richtxtContent.Location = new System.Drawing.Point(16, 39);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Size = new System.Drawing.Size(664, 21);
            this.richtxtContent.TabIndex = 12;
            this.richtxtContent.Text = "Text....";
            // 
            // panelTitle
            // 
            this.panelTitle.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelTitle.Appearance.Options.UseBackColor = true;
            this.panelTitle.Appearance.Options.UseForeColor = true;
            this.panelTitle.Controls.Add(this.linklblEdit);
            this.panelTitle.Controls.Add(this.linklblDelete);
            this.panelTitle.Controls.Add(this.linklblID);
            this.panelTitle.Controls.Add(this.lblFloor);
            this.panelTitle.Controls.Add(this.linklblTransfer);
            this.panelTitle.Controls.Add(this.lblDateTime);
            this.panelTitle.Controls.Add(this.linklblMail);
            this.panelTitle.Controls.Add(this.linklblQuryType);
            this.panelTitle.Controls.Add(this.linklblReply);
            this.panelTitle.Controls.Add(this.lblCopy);
            this.panelTitle.Location = new System.Drawing.Point(5, 8);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(688, 23);
            this.panelTitle.TabIndex = 11;
            // 
            // linklblEdit
            // 
            this.linklblEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblEdit.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblEdit.Appearance.Options.UseFont = true;
            this.linklblEdit.Location = new System.Drawing.Point(336, 5);
            this.linklblEdit.Name = "linklblEdit";
            this.linklblEdit.Size = new System.Drawing.Size(24, 12);
            this.linklblEdit.TabIndex = 9;
            this.linklblEdit.TabStop = true;
            this.linklblEdit.Text = "Edit";
            this.linklblEdit.Visible = false;
            // 
            // linklblDelete
            // 
            this.linklblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblDelete.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblDelete.Appearance.Options.UseFont = true;
            this.linklblDelete.Location = new System.Drawing.Point(377, 5);
            this.linklblDelete.Name = "linklblDelete";
            this.linklblDelete.Size = new System.Drawing.Size(36, 12);
            this.linklblDelete.TabIndex = 10;
            this.linklblDelete.TabStop = true;
            this.linklblDelete.Text = "Delete";
            this.linklblDelete.Visible = false;
            // 
            // linklblTransfer
            // 
            this.linklblTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblTransfer.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblTransfer.Appearance.Options.UseFont = true;
            this.linklblTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblTransfer.Location = new System.Drawing.Point(520, 5);
            this.linklblTransfer.Name = "linklblTransfer";
            this.linklblTransfer.Size = new System.Drawing.Size(48, 12);
            this.linklblTransfer.TabIndex = 8;
            this.linklblTransfer.TabStop = true;
            this.linklblTransfer.Text = "Transfer";
            this.linklblTransfer.Visible = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateTime.Appearance.Options.UseFont = true;
            this.lblDateTime.Location = new System.Drawing.Point(161, 5);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(48, 12);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "DateTime";
            this.lblDateTime.Visible = false;
            // 
            // linklblMail
            // 
            this.linklblMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblMail.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblMail.Appearance.Options.UseFont = true;
            this.linklblMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblMail.Location = new System.Drawing.Point(432, 5);
            this.linklblMail.Name = "linklblMail";
            this.linklblMail.Size = new System.Drawing.Size(24, 12);
            this.linklblMail.TabIndex = 7;
            this.linklblMail.TabStop = true;
            this.linklblMail.Text = "Mail";
            this.linklblMail.Visible = false;
            // 
            // linklblQuryType
            // 
            this.linklblQuryType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblQuryType.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblQuryType.Appearance.Options.UseFont = true;
            this.linklblQuryType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblQuryType.Location = new System.Drawing.Point(589, 5);
            this.linklblQuryType.Name = "linklblQuryType";
            this.linklblQuryType.Size = new System.Drawing.Size(42, 12);
            this.linklblQuryType.TabIndex = 4;
            this.linklblQuryType.TabStop = true;
            this.linklblQuryType.Text = "Related";
            // 
            // linklblReply
            // 
            this.linklblReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblReply.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblReply.Appearance.Options.UseFont = true;
            this.linklblReply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblReply.Location = new System.Drawing.Point(472, 5);
            this.linklblReply.Name = "linklblReply";
            this.linklblReply.Size = new System.Drawing.Size(30, 12);
            this.linklblReply.TabIndex = 6;
            this.linklblReply.TabStop = true;
            this.linklblReply.Text = "Reply";
            this.linklblReply.Visible = false;
            // 
            // lblCopy
            // 
            this.lblCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopy.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCopy.Appearance.Options.UseFont = true;
            this.lblCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCopy.Location = new System.Drawing.Point(651, 5);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(24, 12);
            this.lblCopy.TabIndex = 5;
            this.lblCopy.TabStop = true;
            this.lblCopy.Text = "Copy";
            this.lblCopy.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.lblCopy_LinkClicked);
            // 
            // ThreadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "ThreadControl";
            this.Size = new System.Drawing.Size(700, 70);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFloor;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblID;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl lblDateTime;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblQuryType;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblCopy;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblReply;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblMail;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTransfer;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblDelete;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblEdit;
        private DevExpress.XtraEditors.PanelControl panelTitle;
        private DevExpress.XtraRichEdit.RichEditControl richtxtContent;
    }
}