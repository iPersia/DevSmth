﻿namespace Nzl.Smth.Forms
{
    partial class MessageCenterForm
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
            this.bgwMessager = new System.ComponentModel.BackgroundWorker();
            this.txtMsg = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelUp = new DevExpress.XtraEditors.PanelControl();
            this.txtCache = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelDown = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).BeginInit();
            this.panelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).BeginInit();
            this.panelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtMsg.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Appearance.Text.Options.UseFont = true;
            this.txtMsg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(2, 2);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtMsg.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(780, 351);
            this.txtMsg.TabIndex = 0;
            // 
            // panelUp
            // 
            this.panelUp.Controls.Add(this.txtCache);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(784, 206);
            this.panelUp.TabIndex = 0;
            // 
            // txtCache
            // 
            this.txtCache.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtCache.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCache.Appearance.Text.Options.UseFont = true;
            this.txtCache.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCache.Location = new System.Drawing.Point(2, 2);
            this.txtCache.Name = "txtCache";
            this.txtCache.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtCache.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtCache.ReadOnly = true;
            this.txtCache.Size = new System.Drawing.Size(780, 202);
            this.txtCache.TabIndex = 1;
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.txtMsg);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 206);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(784, 355);
            this.panelDown.TabIndex = 1;
            // 
            // MessageCenterForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "MessageCenterForm";
            this.Text = "Message Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageCenterForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).EndInit();
            this.panelUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).EndInit();
            this.panelDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl txtMsg;
        private System.ComponentModel.BackgroundWorker bgwMessager;
        private DevExpress.XtraEditors.PanelControl panelUp;
        private DevExpress.XtraEditors.PanelControl panelDown;
        private DevExpress.XtraRichEdit.RichEditControl txtCache;
    }
}