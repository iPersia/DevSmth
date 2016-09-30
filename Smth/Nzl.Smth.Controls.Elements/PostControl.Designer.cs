namespace Nzl.Smth.Controls.Elements
{
    partial class PostControl
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
            this.linklblID = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.richtxtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.linklblDelete = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblEdit = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblMail = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblNew = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblSubjectLast = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblSubjectNext = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblLast = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblNext = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblBoard = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblSource = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblSubjectExpand = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblHost = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblExpand = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.linklblTransfer = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblDateTime = new DevExpress.XtraEditors.LabelControl();
            this.linklblReply = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblCopy = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // linklblID
            // 
            this.linklblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblID.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblID.Appearance.Options.UseFont = true;
            this.linklblID.Location = new System.Drawing.Point(584, 34);
            this.linklblID.Name = "linklblID";
            this.linklblID.Size = new System.Drawing.Size(72, 12);
            this.linklblID.TabIndex = 1;
            this.linklblID.TabStop = true;
            this.linklblID.Text = "IDIDIDIDIDID";
            this.linklblID.Visible = false;
            this.linklblID.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblID_LinkClicked);
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
            this.panel.Size = new System.Drawing.Size(840, 163);
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
            this.richtxtContent.Location = new System.Drawing.Point(18, 94);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtContent.Size = new System.Drawing.Size(796, 21);
            this.richtxtContent.TabIndex = 12;
            this.richtxtContent.Text = "Text....";
            // 
            // panelTitle
            // 
            this.panelTitle.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelTitle.Appearance.Options.UseBackColor = true;
            this.panelTitle.Appearance.Options.UseForeColor = true;
            this.panelTitle.Controls.Add(this.linklblDelete);
            this.panelTitle.Controls.Add(this.linklblEdit);
            this.panelTitle.Controls.Add(this.linklblMail);
            this.panelTitle.Controls.Add(this.linklblNew);
            this.panelTitle.Controls.Add(this.linklblSubjectLast);
            this.panelTitle.Controls.Add(this.linklblSubjectNext);
            this.panelTitle.Controls.Add(this.linklblLast);
            this.panelTitle.Controls.Add(this.linklblNext);
            this.panelTitle.Controls.Add(this.linklblBoard);
            this.panelTitle.Controls.Add(this.linklblSource);
            this.panelTitle.Controls.Add(this.linklblSubjectExpand);
            this.panelTitle.Controls.Add(this.linklblHost);
            this.panelTitle.Controls.Add(this.linklblExpand);
            this.panelTitle.Controls.Add(this.lblSubject);
            this.panelTitle.Controls.Add(this.linklblID);
            this.panelTitle.Controls.Add(this.linklblTransfer);
            this.panelTitle.Controls.Add(this.lblDateTime);
            this.panelTitle.Controls.Add(this.linklblReply);
            this.panelTitle.Controls.Add(this.lblCopy);
            this.panelTitle.Location = new System.Drawing.Point(3, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(831, 82);
            this.panelTitle.TabIndex = 11;
            // 
            // linklblDelete
            // 
            this.linklblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblDelete.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblDelete.Appearance.Options.UseFont = true;
            this.linklblDelete.Location = new System.Drawing.Point(574, 57);
            this.linklblDelete.Name = "linklblDelete";
            this.linklblDelete.Size = new System.Drawing.Size(36, 12);
            this.linklblDelete.TabIndex = 23;
            this.linklblDelete.TabStop = true;
            this.linklblDelete.Text = "Delete";
            this.linklblDelete.Visible = false;
            this.linklblDelete.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblDelete_LinkClicked);
            // 
            // linklblEdit
            // 
            this.linklblEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblEdit.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblEdit.Appearance.Options.UseFont = true;
            this.linklblEdit.Location = new System.Drawing.Point(533, 57);
            this.linklblEdit.Name = "linklblEdit";
            this.linklblEdit.Size = new System.Drawing.Size(24, 12);
            this.linklblEdit.TabIndex = 22;
            this.linklblEdit.TabStop = true;
            this.linklblEdit.Text = "Edit";
            this.linklblEdit.Visible = false;
            this.linklblEdit.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblEdit_LinkClicked);
            // 
            // linklblMail
            // 
            this.linklblMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblMail.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblMail.Appearance.Options.UseFont = true;
            this.linklblMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblMail.Location = new System.Drawing.Point(677, 57);
            this.linklblMail.Name = "linklblMail";
            this.linklblMail.Size = new System.Drawing.Size(24, 12);
            this.linklblMail.TabIndex = 21;
            this.linklblMail.TabStop = true;
            this.linklblMail.Text = "Mail";
            this.linklblMail.Visible = false;
            this.linklblMail.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblMail_LinkClicked);
            // 
            // linklblNew
            // 
            this.linklblNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblNew.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblNew.Appearance.Options.UseFont = true;
            this.linklblNew.Location = new System.Drawing.Point(793, 7);
            this.linklblNew.Name = "linklblNew";
            this.linklblNew.Size = new System.Drawing.Size(18, 12);
            this.linklblNew.TabIndex = 20;
            this.linklblNew.TabStop = true;
            this.linklblNew.Text = "New";
            this.linklblNew.Visible = false;
            this.linklblNew.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblNew_LinkClicked);
            // 
            // linklblSubjectLast
            // 
            this.linklblSubjectLast.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblSubjectLast.Appearance.Options.UseFont = true;
            this.linklblSubjectLast.Location = new System.Drawing.Point(97, 57);
            this.linklblSubjectLast.Name = "linklblSubjectLast";
            this.linklblSubjectLast.Size = new System.Drawing.Size(72, 12);
            this.linklblSubjectLast.TabIndex = 19;
            this.linklblSubjectLast.TabStop = true;
            this.linklblSubjectLast.Text = "Subject Last";
            this.linklblSubjectLast.Visible = false;
            this.linklblSubjectLast.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblSubjectLast_LinkClicked);
            // 
            // linklblSubjectNext
            // 
            this.linklblSubjectNext.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblSubjectNext.Appearance.Options.UseFont = true;
            this.linklblSubjectNext.Location = new System.Drawing.Point(194, 57);
            this.linklblSubjectNext.Name = "linklblSubjectNext";
            this.linklblSubjectNext.Size = new System.Drawing.Size(72, 12);
            this.linklblSubjectNext.TabIndex = 18;
            this.linklblSubjectNext.TabStop = true;
            this.linklblSubjectNext.Text = "Subject Next";
            this.linklblSubjectNext.Visible = false;
            this.linklblSubjectNext.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblSubjectNext_LinkClicked);
            // 
            // linklblLast
            // 
            this.linklblLast.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblLast.Appearance.Options.UseFont = true;
            this.linklblLast.Location = new System.Drawing.Point(15, 57);
            this.linklblLast.Name = "linklblLast";
            this.linklblLast.Size = new System.Drawing.Size(24, 12);
            this.linklblLast.TabIndex = 17;
            this.linklblLast.TabStop = true;
            this.linklblLast.Text = "Last";
            this.linklblLast.Visible = false;
            this.linklblLast.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblLast_LinkClicked);
            // 
            // linklblNext
            // 
            this.linklblNext.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblNext.Appearance.Options.UseFont = true;
            this.linklblNext.Location = new System.Drawing.Point(56, 57);
            this.linklblNext.Name = "linklblNext";
            this.linklblNext.Size = new System.Drawing.Size(24, 12);
            this.linklblNext.TabIndex = 16;
            this.linklblNext.TabStop = true;
            this.linklblNext.Text = "Next";
            this.linklblNext.Visible = false;
            this.linklblNext.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblNext_LinkClicked);
            // 
            // linklblBoard
            // 
            this.linklblBoard.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblBoard.Appearance.Options.UseFont = true;
            this.linklblBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblBoard.Location = new System.Drawing.Point(227, 7);
            this.linklblBoard.Name = "linklblBoard";
            this.linklblBoard.Size = new System.Drawing.Size(30, 12);
            this.linklblBoard.TabIndex = 15;
            this.linklblBoard.TabStop = true;
            this.linklblBoard.Text = "Board";
            this.linklblBoard.Visible = false;
            this.linklblBoard.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblBoard_LinkClicked);
            // 
            // linklblSource
            // 
            this.linklblSource.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblSource.Appearance.Options.UseFont = true;
            this.linklblSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblSource.Location = new System.Drawing.Point(173, 7);
            this.linklblSource.Name = "linklblSource";
            this.linklblSource.Size = new System.Drawing.Size(36, 12);
            this.linklblSource.TabIndex = 14;
            this.linklblSource.TabStop = true;
            this.linklblSource.Text = "Source";
            this.linklblSource.Visible = false;
            this.linklblSource.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblSource_LinkClicked);
            // 
            // linklblSubjectExpand
            // 
            this.linklblSubjectExpand.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblSubjectExpand.Appearance.Options.UseFont = true;
            this.linklblSubjectExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblSubjectExpand.Location = new System.Drawing.Point(111, 7);
            this.linklblSubjectExpand.Name = "linklblSubjectExpand";
            this.linklblSubjectExpand.Size = new System.Drawing.Size(42, 12);
            this.linklblSubjectExpand.TabIndex = 13;
            this.linklblSubjectExpand.TabStop = true;
            this.linklblSubjectExpand.Text = "Subject";
            this.linklblSubjectExpand.Visible = false;
            this.linklblSubjectExpand.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblSubjectExpand_LinkClicked);
            // 
            // linklblHost
            // 
            this.linklblHost.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblHost.Appearance.Options.UseFont = true;
            this.linklblHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblHost.Location = new System.Drawing.Point(70, 7);
            this.linklblHost.Name = "linklblHost";
            this.linklblHost.Size = new System.Drawing.Size(24, 12);
            this.linklblHost.TabIndex = 12;
            this.linklblHost.TabStop = true;
            this.linklblHost.Text = "Host";
            this.linklblHost.Visible = false;
            this.linklblHost.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblHost_LinkClicked);
            // 
            // linklblExpand
            // 
            this.linklblExpand.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblExpand.Appearance.Options.UseFont = true;
            this.linklblExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblExpand.Location = new System.Drawing.Point(15, 7);
            this.linklblExpand.Name = "linklblExpand";
            this.linklblExpand.Size = new System.Drawing.Size(36, 12);
            this.linklblExpand.TabIndex = 11;
            this.linklblExpand.TabStop = true;
            this.linklblExpand.Text = "Expand";
            this.linklblExpand.Visible = false;
            this.linklblExpand.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblExpand_LinkClicked);
            // 
            // lblSubject
            // 
            this.lblSubject.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubject.Appearance.Options.UseFont = true;
            this.lblSubject.Location = new System.Drawing.Point(15, 34);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(42, 12);
            this.lblSubject.TabIndex = 9;
            this.lblSubject.Text = "Subject";
            this.lblSubject.Visible = false;
            // 
            // linklblTransfer
            // 
            this.linklblTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblTransfer.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblTransfer.Appearance.Options.UseFont = true;
            this.linklblTransfer.Location = new System.Drawing.Point(717, 57);
            this.linklblTransfer.Name = "linklblTransfer";
            this.linklblTransfer.Size = new System.Drawing.Size(48, 12);
            this.linklblTransfer.TabIndex = 8;
            this.linklblTransfer.TabStop = true;
            this.linklblTransfer.Text = "Transfer";
            this.linklblTransfer.Visible = false;
            this.linklblTransfer.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblTransfer_LinkClicked);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateTime.Appearance.Options.UseFont = true;
            this.lblDateTime.Location = new System.Drawing.Point(681, 34);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(114, 12);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "2016-09-07 16:02:25";
            this.lblDateTime.Visible = false;
            // 
            // linklblReply
            // 
            this.linklblReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblReply.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblReply.Appearance.Options.UseFont = true;
            this.linklblReply.Location = new System.Drawing.Point(629, 57);
            this.linklblReply.Name = "linklblReply";
            this.linklblReply.Size = new System.Drawing.Size(30, 12);
            this.linklblReply.TabIndex = 6;
            this.linklblReply.TabStop = true;
            this.linklblReply.Text = "Reply";
            this.linklblReply.Visible = false;
            this.linklblReply.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.linklblReply_LinkClicked);
            // 
            // lblCopy
            // 
            this.lblCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopy.Appearance.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCopy.Appearance.Options.UseFont = true;
            this.lblCopy.Location = new System.Drawing.Point(786, 57);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(24, 12);
            this.lblCopy.TabIndex = 5;
            this.lblCopy.TabStop = true;
            this.lblCopy.Text = "Copy";
            this.lblCopy.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.lblCopy_LinkClicked);
            // 
            // PostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "PostControl";
            this.Size = new System.Drawing.Size(840, 163);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblID;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl lblDateTime;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblCopy;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblReply;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTransfer;
        private DevExpress.XtraEditors.PanelControl panelTitle;
        private DevExpress.XtraEditors.LabelControl lblSubject;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblExpand;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblHost;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblSubjectExpand;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblSource;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblBoard;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblLast;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblNext;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblSubjectLast;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblSubjectNext;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblNew;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblMail;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblDelete;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblEdit;
        private DevExpress.XtraRichEdit.RichEditControl richtxtContent;
    }
}