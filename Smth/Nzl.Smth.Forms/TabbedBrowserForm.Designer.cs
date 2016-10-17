namespace Nzl.Smth.Forms
{
    partial class TabbedBrowserForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabbedBrowserForm));
            this.xtcBrowser = new DevExpress.XtraTab.XtraTabControl();
            this.bmManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bsiWelcome = new DevExpress.XtraBars.BarStaticItem();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTop10s = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBoards = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFavors = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMails = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefers = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSettings = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClear = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.riteGo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtcBrowser
            // 
            this.xtcBrowser.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtcBrowser.Appearance.Options.UseFont = true;
            this.xtcBrowser.AppearancePage.Header.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtcBrowser.AppearancePage.Header.Options.UseFont = true;
            this.xtcBrowser.AppearancePage.HeaderActive.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtcBrowser.AppearancePage.HeaderActive.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.xtcBrowser.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtcBrowser.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtcBrowser.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.xtcBrowser.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtcBrowser.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.xtcBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcBrowser.Location = new System.Drawing.Point(0, 49);
            this.xtcBrowser.Name = "xtcBrowser";
            this.xtcBrowser.Size = new System.Drawing.Size(1010, 683);
            this.xtcBrowser.TabIndex = 0;
            this.xtcBrowser.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtcBrowser_SelectedPageChanged);
            this.xtcBrowser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.xtcBrowser_MouseDoubleClick);
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
            this.bsiWelcome,
            this.bbiLogin,
            this.bbiTop10s,
            this.bbiBoards,
            this.bbiMessage,
            this.bbiFavors,
            this.bbiMails,
            this.bbiRefers,
            this.bbiSettings,
            this.bbiClear});
            this.bmManager.MainMenu = this.bar4;
            this.bmManager.MaxItemId = 36;
            this.bmManager.OptionsLayout.AllowAddNewItems = false;
            this.bmManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riteGo,
            this.repositoryItemHyperLinkEdit1});
            this.bmManager.StatusBar = this.bar5;
            // 
            // bar3
            // 
            this.bar3.BarAppearance.Disabled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar3.BarAppearance.Disabled.Options.UseFont = true;
            this.bar3.BarAppearance.Hovered.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar3.BarAppearance.Hovered.Options.UseFont = true;
            this.bar3.BarAppearance.Normal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar3.BarAppearance.Normal.Options.UseFont = true;
            this.bar3.BarAppearance.Pressed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar3.BarAppearance.Pressed.Options.UseFont = true;
            this.bar3.BarName = "Tools";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 1;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiWelcome),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLogin),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTop10s),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBoards),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMessage),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFavors),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMails),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefers),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSettings),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClear)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DisableClose = true;
            this.bar3.OptionsBar.DisableCustomization = true;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Tools";
            // 
            // bsiWelcome
            // 
            this.bsiWelcome.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.bsiWelcome.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bsiWelcome.Caption = "Welcome!";
            this.bsiWelcome.Id = 26;
            this.bsiWelcome.Name = "bsiWelcome";
            this.bsiWelcome.Size = new System.Drawing.Size(120, 0);
            this.bsiWelcome.TextAlignment = System.Drawing.StringAlignment.Near;
            this.bsiWelcome.Width = 120;
            // 
            // bbiLogin
            // 
            this.bbiLogin.Caption = "Log in";
            this.bbiLogin.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiLogin.Id = 27;
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.Size = new System.Drawing.Size(75, 0);
            this.bbiLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogin_ItemClick);
            // 
            // bbiTop10s
            // 
            this.bbiTop10s.Caption = "Top 10\'s";
            this.bbiTop10s.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiTop10s.Id = 28;
            this.bbiTop10s.Name = "bbiTop10s";
            this.bbiTop10s.Size = new System.Drawing.Size(75, 0);
            this.bbiTop10s.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTop10s_ItemClick);
            // 
            // bbiBoards
            // 
            this.bbiBoards.Border = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.bbiBoards.Caption = "Boards";
            this.bbiBoards.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiBoards.Id = 29;
            this.bbiBoards.Name = "bbiBoards";
            this.bbiBoards.Size = new System.Drawing.Size(75, 0);
            this.bbiBoards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBoards_ItemClick);
            // 
            // bbiMessage
            // 
            this.bbiMessage.Caption = "Message";
            this.bbiMessage.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiMessage.Id = 30;
            this.bbiMessage.Name = "bbiMessage";
            this.bbiMessage.Size = new System.Drawing.Size(75, 0);
            this.bbiMessage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMessage_ItemClick);
            // 
            // bbiFavors
            // 
            this.bbiFavors.Caption = "Favors";
            this.bbiFavors.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiFavors.Id = 31;
            this.bbiFavors.Name = "bbiFavors";
            this.bbiFavors.Size = new System.Drawing.Size(75, 0);
            this.bbiFavors.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiFavors.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFavors_ItemClick);
            // 
            // bbiMails
            // 
            this.bbiMails.Caption = "Mails";
            this.bbiMails.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiMails.Id = 32;
            this.bbiMails.Name = "bbiMails";
            this.bbiMails.Size = new System.Drawing.Size(75, 0);
            this.bbiMails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiMails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMails_ItemClick);
            // 
            // bbiRefers
            // 
            this.bbiRefers.Caption = "Refers";
            this.bbiRefers.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiRefers.Id = 33;
            this.bbiRefers.Name = "bbiRefers";
            this.bbiRefers.Size = new System.Drawing.Size(75, 0);
            this.bbiRefers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiRefers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefers_ItemClick);
            // 
            // bbiSettings
            // 
            this.bbiSettings.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiSettings.Caption = "Settings";
            this.bbiSettings.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiSettings.Id = 34;
            this.bbiSettings.Name = "bbiSettings";
            this.bbiSettings.Size = new System.Drawing.Size(75, 0);
            this.bbiSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSettings_ItemClick);
            // 
            // bbiClear
            // 
            this.bbiClear.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiClear.Caption = "Clear";
            this.bbiClear.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiClear.Id = 35;
            this.bbiClear.Name = "bbiClear";
            this.bbiClear.Size = new System.Drawing.Size(75, 0);
            this.bbiClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClear_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1010, 49);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 732);
            this.barDockControlBottom.Size = new System.Drawing.Size(1010, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 49);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 683);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1010, 49);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 683);
            // 
            // riteGo
            // 
            this.riteGo.Appearance.Options.UseTextOptions = true;
            this.riteGo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.riteGo.AutoHeight = false;
            this.riteGo.Name = "riteGo";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // TabbedBrowserForm
            // 
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseTextOptions = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 755);
            this.Controls.Add(this.xtcBrowser);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabbedBrowserForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "水木社区";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabbedTopicBrowserForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.xtcBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtcBrowser;
        private DevExpress.XtraBars.BarManager bmManager;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteGo;
        private DevExpress.XtraBars.BarStaticItem bsiWelcome;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraBars.BarButtonItem bbiLogin;
        private DevExpress.XtraBars.BarButtonItem bbiTop10s;
        private DevExpress.XtraBars.BarButtonItem bbiBoards;
        private DevExpress.XtraBars.BarButtonItem bbiMessage;
        private DevExpress.XtraBars.BarButtonItem bbiFavors;
        private DevExpress.XtraBars.BarButtonItem bbiMails;
        private DevExpress.XtraBars.BarButtonItem bbiRefers;
        private DevExpress.XtraBars.BarButtonItem bbiSettings;
        private DevExpress.XtraBars.BarButtonItem bbiClear;
    }
}