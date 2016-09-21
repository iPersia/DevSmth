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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabbedBrowserForm));
            this.tcTopics = new DevExpress.XtraTab.XtraTabControl();
            this.scBrowser = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnRefer = new DevExpress.XtraEditors.SimpleButton();
            this.linklblUserID = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.btnMessge = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadTop = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogon = new DevExpress.XtraEditors.SimpleButton();
            this.btnMail = new DevExpress.XtraEditors.SimpleButton();
            this.btnFavor = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoardNavi = new DevExpress.XtraEditors.SimpleButton();
            this.btnSettings = new DevExpress.XtraEditors.SimpleButton();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcTopics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scBrowser)).BeginInit();
            this.scBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTopics
            // 
            this.tcTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTopics.Location = new System.Drawing.Point(2, 2);
            this.tcTopics.Name = "tcTopics";
            this.tcTopics.Size = new System.Drawing.Size(1004, 690);
            this.tcTopics.TabIndex = 0;
            this.tcTopics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tcTopics_MouseDoubleClick);
            // 
            // scBrowser
            // 
            this.scBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBrowser.Horizontal = false;
            this.scBrowser.IsSplitterFixed = true;
            this.scBrowser.Location = new System.Drawing.Point(0, 0);
            this.scBrowser.Name = "scBrowser";
            this.scBrowser.Panel1.Controls.Add(this.panelMenu);
            this.scBrowser.Panel2.Controls.Add(this.panelContainer);
            this.scBrowser.Size = new System.Drawing.Size(1008, 729);
            this.scBrowser.SplitterPosition = 30;
            this.scBrowser.TabIndex = 1;
            // 
            // panelMenu
            // 
            this.panelMenu.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Appearance.Options.UseBackColor = true;
            this.panelMenu.Controls.Add(this.btnRefer);
            this.panelMenu.Controls.Add(this.linklblUserID);
            this.panelMenu.Controls.Add(this.btnMessge);
            this.panelMenu.Controls.Add(this.btnLoadTop);
            this.panelMenu.Controls.Add(this.btnLogon);
            this.panelMenu.Controls.Add(this.btnMail);
            this.panelMenu.Controls.Add(this.btnFavor);
            this.panelMenu.Controls.Add(this.btnClear);
            this.panelMenu.Controls.Add(this.btnBoardNavi);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1008, 30);
            this.panelMenu.TabIndex = 0;
            // 
            // btnRefer
            // 
            this.btnRefer.Location = new System.Drawing.Point(642, 2);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(75, 27);
            this.btnRefer.TabIndex = 16;
            this.btnRefer.Text = "Refers";
            this.btnRefer.Visible = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // linklblUserID
            // 
            this.linklblUserID.Location = new System.Drawing.Point(14, 10);
            this.linklblUserID.Name = "linklblUserID";
            this.linklblUserID.Size = new System.Drawing.Size(55, 14);
            this.linklblUserID.TabIndex = 15;
            this.linklblUserID.Text = "Welcome!";
            // 
            // btnMessge
            // 
            this.btnMessge.Location = new System.Drawing.Point(402, 2);
            this.btnMessge.Name = "btnMessge";
            this.btnMessge.Size = new System.Drawing.Size(75, 27);
            this.btnMessge.TabIndex = 14;
            this.btnMessge.TabStop = false;
            this.btnMessge.Text = "Message";
            this.btnMessge.Click += new System.EventHandler(this.btnMessge_Click);
            // 
            // btnLoadTop
            // 
            this.btnLoadTop.Location = new System.Drawing.Point(242, 2);
            this.btnLoadTop.Name = "btnLoadTop";
            this.btnLoadTop.Size = new System.Drawing.Size(75, 27);
            this.btnLoadTop.TabIndex = 6;
            this.btnLoadTop.Text = "Top 10\'s";
            this.btnLoadTop.Click += new System.EventHandler(this.btnLoadTop_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(162, 2);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(75, 27);
            this.btnLogon.TabIndex = 10;
            this.btnLogon.Text = "Log in";
            this.btnLogon.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnMail
            // 
            this.btnMail.Location = new System.Drawing.Point(562, 2);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(75, 27);
            this.btnMail.TabIndex = 13;
            this.btnMail.Text = "Mails";
            this.btnMail.Visible = false;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btnFavor
            // 
            this.btnFavor.Location = new System.Drawing.Point(482, 2);
            this.btnFavor.Name = "btnFavor";
            this.btnFavor.Size = new System.Drawing.Size(75, 27);
            this.btnFavor.TabIndex = 12;
            this.btnFavor.Text = "Favors";
            this.btnFavor.Visible = false;
            this.btnFavor.Click += new System.EventHandler(this.btnFavor_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(927, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 27);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBoardNavi
            // 
            this.btnBoardNavi.Location = new System.Drawing.Point(322, 2);
            this.btnBoardNavi.Name = "btnBoardNavi";
            this.btnBoardNavi.Size = new System.Drawing.Size(75, 27);
            this.btnBoardNavi.TabIndex = 11;
            this.btnBoardNavi.Text = "Boards";
            this.btnBoardNavi.Click += new System.EventHandler(this.btnBoardNavi_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(847, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 27);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Setting";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Appearance.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panelContainer.Appearance.Options.UseBackColor = true;
            this.panelContainer.Controls.Add(this.tcTopics);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1008, 694);
            this.panelContainer.TabIndex = 1;
            // 
            // TabbedBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.scBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabbedBrowserForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "水木社区";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabbedTopicBrowserForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tcTopics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scBrowser)).EndInit();
            this.scBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcTopics;
        private DevExpress.XtraEditors.SplitContainerControl scBrowser;
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.SimpleButton btnSettings;
        private DevExpress.XtraEditors.SimpleButton btnClear;        
        private DevExpress.XtraEditors.SimpleButton btnLoadTop;
        private DevExpress.XtraEditors.SimpleButton btnMessge;
        private DevExpress.XtraEditors.SimpleButton btnLogon;
        private DevExpress.XtraEditors.SimpleButton btnMail;
        private DevExpress.XtraEditors.SimpleButton btnFavor;
        private DevExpress.XtraEditors.SimpleButton btnBoardNavi;
        private DevExpress.XtraEditors.SimpleButton btnRefer;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblUserID;
        
    }
}