﻿namespace Nzl.Smth.Controls.Elements
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
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.linklblEdit = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblDelete = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblTransfer = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblDateTime = new DevExpress.XtraEditors.LabelControl();
            this.linklblMail = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblQuryType = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblReply = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblCopy = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.richtxtContent = new Nzl.Controls.RichTextBoxEx();
            this.panel.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFloor
            // 
            this.lblFloor.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloor.Location = new System.Drawing.Point(2, 4);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(42, 12);
            this.lblFloor.TabIndex = 0;
            this.lblFloor.Text = "9999楼";
            this.lblFloor.Visible = false;
            // 
            // linklblID
            // 
            this.linklblID.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblID.Location = new System.Drawing.Point(53, 4);
            this.linklblID.Name = "linklblID";
            this.linklblID.Size = new System.Drawing.Size(77, 12);
            this.linklblID.TabIndex = 1;
            this.linklblID.TabStop = true;
            this.linklblID.Text = "IDIDIDIDIDID";
            this.linklblID.Visible = false;
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.panel.Controls.Add(this.panelTitle);
            this.panel.Controls.Add(this.richtxtContent);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(600, 98);
            this.panel.TabIndex = 4;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.panelTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelTitle.Location = new System.Drawing.Point(4, 7);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(590, 20);
            this.panelTitle.TabIndex = 11;
            // 
            // linklblEdit
            // 
            this.linklblEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblEdit.AutoSize = true;
            this.linklblEdit.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblEdit.Location = new System.Drawing.Point(288, 4);
            this.linklblEdit.Name = "linklblEdit";
            this.linklblEdit.Size = new System.Drawing.Size(29, 12);
            this.linklblEdit.TabIndex = 9;
            this.linklblEdit.TabStop = true;
            this.linklblEdit.Text = "Edit";
            this.linklblEdit.Visible = false;
            // 
            // linklblDelete
            // 
            this.linklblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblDelete.AutoSize = true;
            this.linklblDelete.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblDelete.Location = new System.Drawing.Point(323, 4);
            this.linklblDelete.Name = "linklblDelete";
            this.linklblDelete.Size = new System.Drawing.Size(41, 12);
            this.linklblDelete.TabIndex = 10;
            this.linklblDelete.TabStop = true;
            this.linklblDelete.Text = "Delete";
            this.linklblDelete.Visible = false;
            // 
            // linklblTransfer
            // 
            this.linklblTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblTransfer.AutoSize = true;
            this.linklblTransfer.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblTransfer.Location = new System.Drawing.Point(446, 4);
            this.linklblTransfer.Name = "linklblTransfer";
            this.linklblTransfer.Size = new System.Drawing.Size(53, 12);
            this.linklblTransfer.TabIndex = 8;
            this.linklblTransfer.TabStop = true;
            this.linklblTransfer.Text = "Transfer";
            this.linklblTransfer.Visible = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateTime.Location = new System.Drawing.Point(138, 4);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(53, 12);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "DateTime";
            this.lblDateTime.Visible = false;
            // 
            // linklblMail
            // 
            this.linklblMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblMail.AutoSize = true;
            this.linklblMail.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblMail.Location = new System.Drawing.Point(370, 4);
            this.linklblMail.Name = "linklblMail";
            this.linklblMail.Size = new System.Drawing.Size(29, 12);
            this.linklblMail.TabIndex = 7;
            this.linklblMail.TabStop = true;
            this.linklblMail.Text = "Mail";
            this.linklblMail.Visible = false;
            // 
            // linklblQuryType
            // 
            this.linklblQuryType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblQuryType.AutoSize = true;
            this.linklblQuryType.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblQuryType.Location = new System.Drawing.Point(505, 4);
            this.linklblQuryType.Name = "linklblQuryType";
            this.linklblQuryType.Size = new System.Drawing.Size(47, 12);
            this.linklblQuryType.TabIndex = 4;
            this.linklblQuryType.TabStop = true;
            this.linklblQuryType.Text = "Related";
            // 
            // linklblReply
            // 
            this.linklblReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblReply.AutoSize = true;
            this.linklblReply.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblReply.Location = new System.Drawing.Point(405, 4);
            this.linklblReply.Name = "linklblReply";
            this.linklblReply.Size = new System.Drawing.Size(35, 12);
            this.linklblReply.TabIndex = 6;
            this.linklblReply.TabStop = true;
            this.linklblReply.Text = "Reply";
            this.linklblReply.Visible = false;
            // 
            // lblCopy
            // 
            this.lblCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopy.AutoSize = true;
            this.lblCopy.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCopy.Location = new System.Drawing.Point(558, 4);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(29, 12);
            this.lblCopy.TabIndex = 5;
            this.lblCopy.TabStop = true;
            this.lblCopy.Text = "Copy";
            this.lblCopy.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.lblCopy_LinkClicked);
            // 
            // richtxtContent
            // 
            this.richtxtContent.BackColor = System.Drawing.SystemColors.Control;
            this.richtxtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richtxtContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richtxtContent.HiglightColor = Nzl.Controls.RtfColor.White;
            this.richtxtContent.Location = new System.Drawing.Point(15, 37);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.Size = new System.Drawing.Size(570, 37);
            this.richtxtContent.TabIndex = 2;
            this.richtxtContent.TabStop = false;
            this.richtxtContent.Text = "";
            this.richtxtContent.TextColor = Nzl.Controls.RtfColor.Black;
            this.richtxtContent.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richtxtContent_LinkClicked);
            this.richtxtContent.Enter += new System.EventHandler(this.richtxtContent_Enter);
            // 
            // ThreadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "ThreadControl";
            this.Size = new System.Drawing.Size(600, 98);
            this.panel.ResumeLayout(false);
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
        //private System.Windows.Forms.RichTextBox richtxtContent;
        private Nzl.Controls.RichTextBoxEx richtxtContent;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblQuryType;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblCopy;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblReply;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblMail;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTransfer;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblDelete;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblEdit;
        private DevExpress.XtraEditors.PanelControl panelTitle;
    }
}