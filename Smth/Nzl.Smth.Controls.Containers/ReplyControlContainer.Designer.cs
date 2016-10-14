namespace Nzl.Smth.Controls.Containers
{
    partial class ReplyControlContainer
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
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.bmManager = new DevExpress.XtraBars.BarManager();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bbiFirst = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrev = new DevExpress.XtraBars.BarButtonItem();
            this.bsiPage = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNext = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLast = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.beiGo = new DevExpress.XtraBars.BarEditItem();
            this.riteGo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bbiGo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenInBrowser = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteGo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panel);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 51);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(840, 561);
            this.panelContainer.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Location = new System.Drawing.Point(5, 5);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(829, 117);
            this.panel.TabIndex = 0;
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
            this.bbiFirst,
            this.bbiPrev,
            this.bbiNext,
            this.bbiLast,
            this.bsiPage,
            this.bbiGo,
            this.beiGo,
            this.bbiRefresh,
            this.bbiOpenInBrowser});
            this.bmManager.MainMenu = this.bar4;
            this.bmManager.MaxItemId = 24;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFirst),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrev),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiPage, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNext, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.beiGo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiGo),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenInBrowser, true)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DisableClose = true;
            this.bar3.OptionsBar.DisableCustomization = true;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Tools";
            // 
            // bbiFirst
            // 
            this.bbiFirst.Caption = "First";
            this.bbiFirst.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiFirst.Id = 1;
            this.bbiFirst.Name = "bbiFirst";
            this.bbiFirst.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
            this.bbiFirst.Size = new System.Drawing.Size(60, 0);
            this.bbiFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFirst_ItemClick);
            // 
            // bbiPrev
            // 
            this.bbiPrev.Caption = "Prev";
            this.bbiPrev.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiPrev.Id = 5;
            this.bbiPrev.Name = "bbiPrev";
            this.bbiPrev.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrev_ItemClick);
            // 
            // bsiPage
            // 
            this.bsiPage.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bsiPage.Caption = "000000/999999";
            this.bsiPage.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bsiPage.Id = 8;
            this.bsiPage.Name = "bsiPage";
            this.bsiPage.Size = new System.Drawing.Size(120, 0);
            this.bsiPage.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiNext
            // 
            this.bbiNext.Caption = "Next";
            this.bbiNext.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiNext.Id = 6;
            this.bbiNext.Name = "bbiNext";
            this.bbiNext.Size = new System.Drawing.Size(60, 0);
            this.bbiNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNext_ItemClick);
            // 
            // bbiLast
            // 
            this.bbiLast.Caption = "Last";
            this.bbiLast.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiLast.Id = 7;
            this.bbiLast.Name = "bbiLast";
            this.bbiLast.Size = new System.Drawing.Size(60, 0);
            this.bbiLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLast_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.bbiRefresh.Id = 17;
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.Size = new System.Drawing.Size(60, 0);
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // beiGo
            // 
            this.beiGo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.beiGo.Edit = this.riteGo;
            this.beiGo.Id = 13;
            this.beiGo.Name = "beiGo";
            // 
            // riteGo
            // 
            this.riteGo.Appearance.Options.UseTextOptions = true;
            this.riteGo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.riteGo.AutoHeight = false;
            this.riteGo.Name = "riteGo";
            // 
            // bbiGo
            // 
            this.bbiGo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.bbiGo.Caption = "Go";
            this.bbiGo.Id = 12;
            this.bbiGo.Name = "bbiGo";
            this.bbiGo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGo_ItemClick);
            // 
            // bbiOpenInBrowser
            // 
            this.bbiOpenInBrowser.Caption = "Open in Browser";
            this.bbiOpenInBrowser.Id = 23;
            this.bbiOpenInBrowser.Name = "bbiOpenInBrowser";
            this.bbiOpenInBrowser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOpenInBrowser_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(840, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 612);
            this.barDockControlBottom.Size = new System.Drawing.Size(840, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 561);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(840, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 561);
            // 
            // ReplyControlContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReplyControlContainer";
            this.Size = new System.Drawing.Size(840, 635);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteGo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraBars.BarManager bmManager;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem bbiFirst;
        private DevExpress.XtraBars.BarButtonItem bbiPrev;
        private DevExpress.XtraBars.BarStaticItem bsiPage;
        private DevExpress.XtraBars.BarButtonItem bbiNext;
        private DevExpress.XtraBars.BarButtonItem bbiLast;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarEditItem beiGo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteGo;
        private DevExpress.XtraBars.BarButtonItem bbiGo;
        private DevExpress.XtraBars.BarButtonItem bbiOpenInBrowser;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
