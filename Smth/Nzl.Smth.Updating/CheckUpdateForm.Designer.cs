namespace Nzl.Smth.Updating
{
    partial class CheckUpdateForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bmManager = new DevExpress.XtraBars.BarManager();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bbiCheck = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDownload = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.riteGo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.richtxtReleaseNote = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lcReleaseDate = new DevExpress.XtraEditors.LabelControl();
            this.lcUrgency = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lcCurrentVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lcLatestVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bmManager
            // 
            this.bmManager.AllowCustomization = false;
            this.bmManager.AllowHtmlText = true;
            this.bmManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar4,
            this.bar5});
            this.bmManager.DockControls.Add(this.barDockControlTop);
            this.bmManager.DockControls.Add(this.barDockControlBottom);
            this.bmManager.DockControls.Add(this.barDockControlLeft);
            this.bmManager.DockControls.Add(this.barDockControlRight);
            this.bmManager.Form = this;
            this.bmManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiCheck,
            this.bbiDownload});
            this.bmManager.MainMenu = this.bar4;
            this.bmManager.MaxItemId = 25;
            this.bmManager.OptionsLayout.AllowAddNewItems = false;
            this.bmManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riteGo});
            this.bmManager.StatusBar = this.bar5;
            // 
            // bar3
            // 
            this.bar3.BarName = "Tools";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 1;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheck),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDownload)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DisableClose = true;
            this.bar3.OptionsBar.DisableCustomization = true;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Tools";
            // 
            // bbiCheck
            // 
            this.bbiCheck.Caption = "Check";
            this.bbiCheck.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiCheck.Id = 1;
            this.bbiCheck.Name = "bbiCheck";
            this.bbiCheck.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
            this.bbiCheck.Size = new System.Drawing.Size(60, 0);
            this.bbiCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCheck_ItemClick);
            // 
            // bbiDownload
            // 
            this.bbiDownload.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiDownload.Caption = "Download!";
            this.bbiDownload.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiDownload.Id = 24;
            this.bbiDownload.Name = "bbiDownload";
            this.bbiDownload.Size = new System.Drawing.Size(100, 0);
            this.bbiDownload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDownload_ItemClick);
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(262, 152);
            this.bar4.FloatSize = new System.Drawing.Size(46, 29);
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            this.bar4.Visible = false;
            // 
            // bar5
            // 
            this.bar5.BarName = "Status bar";
            this.bar5.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Status bar";
            this.bar5.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(524, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 433);
            this.barDockControlBottom.Size = new System.Drawing.Size(524, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 382);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(524, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 382);
            // 
            // riteGo
            // 
            this.riteGo.Appearance.Options.UseTextOptions = true;
            this.riteGo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.riteGo.AutoHeight = false;
            this.riteGo.Name = "riteGo";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 51);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(524, 382);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.richtxtReleaseNote);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 76);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(520, 304);
            this.panelControl3.TabIndex = 4;
            // 
            // richtxtReleaseNote
            // 
            this.richtxtReleaseNote.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richtxtReleaseNote.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtxtReleaseNote.Appearance.Text.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.richtxtReleaseNote.Appearance.Text.Options.UseBackColor = true;
            this.richtxtReleaseNote.Appearance.Text.Options.UseFont = true;
            this.richtxtReleaseNote.Appearance.Text.Options.UseTextOptions = true;
            this.richtxtReleaseNote.Appearance.Text.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.richtxtReleaseNote.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richtxtReleaseNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richtxtReleaseNote.Location = new System.Drawing.Point(2, 2);
            this.richtxtReleaseNote.MenuManager = this.bmManager;
            this.richtxtReleaseNote.Name = "richtxtReleaseNote";
            this.richtxtReleaseNote.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtReleaseNote.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richtxtReleaseNote.Size = new System.Drawing.Size(516, 300);
            this.richtxtReleaseNote.TabIndex = 13;
            this.richtxtReleaseNote.Text = "Text....";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lcLatestVersion);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.lcCurrentVersion);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.lcReleaseDate);
            this.panelControl2.Controls.Add(this.lcUrgency);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(520, 74);
            this.panelControl2.TabIndex = 3;
            // 
            // lcReleaseDate
            // 
            this.lcReleaseDate.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcReleaseDate.Appearance.Options.UseFont = true;
            this.lcReleaseDate.Location = new System.Drawing.Point(432, 43);
            this.lcReleaseDate.Name = "lcReleaseDate";
            this.lcReleaseDate.Size = new System.Drawing.Size(60, 12);
            this.lcReleaseDate.TabIndex = 3;
            this.lcReleaseDate.Text = "2016-10-18";
            // 
            // lcUrgency
            // 
            this.lcUrgency.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcUrgency.Appearance.Options.UseFont = true;
            this.lcUrgency.Location = new System.Drawing.Point(432, 17);
            this.lcUrgency.Name = "lcUrgency";
            this.lcUrgency.Size = new System.Drawing.Size(24, 12);
            this.lcUrgency.TabIndex = 2;
            this.lcUrgency.Text = "一般";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(344, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 12);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Release date";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(374, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 12);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Urgency";
            // 
            // lcCurrentVersion
            // 
            this.lcCurrentVersion.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcCurrentVersion.Appearance.Options.UseFont = true;
            this.lcCurrentVersion.Location = new System.Drawing.Point(125, 17);
            this.lcCurrentVersion.Name = "lcCurrentVersion";
            this.lcCurrentVersion.Size = new System.Drawing.Size(24, 12);
            this.lcCurrentVersion.TabIndex = 5;
            this.lcCurrentVersion.Text = "一般";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(20, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(90, 12);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Current version";
            // 
            // lcLatestVersion
            // 
            this.lcLatestVersion.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcLatestVersion.Appearance.Options.UseFont = true;
            this.lcLatestVersion.Location = new System.Drawing.Point(125, 43);
            this.lcLatestVersion.Name = "lcLatestVersion";
            this.lcLatestVersion.Size = new System.Drawing.Size(24, 12);
            this.lcLatestVersion.TabIndex = 7;
            this.lcLatestVersion.Text = "一般";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(20, 43);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(84, 12);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Latest version";
            // 
            // CheckUpdateForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 456);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckUpdateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Check updating";
            ((System.ComponentModel.ISupportInitialize)(this.bmManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager bmManager;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem bbiCheck;
        private DevExpress.XtraBars.BarButtonItem bbiDownload;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteGo;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lcUrgency;
        private DevExpress.XtraEditors.LabelControl lcReleaseDate;
        private DevExpress.XtraRichEdit.RichEditControl richtxtReleaseNote;
        private DevExpress.XtraEditors.LabelControl lcLatestVersion;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lcCurrentVersion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}

