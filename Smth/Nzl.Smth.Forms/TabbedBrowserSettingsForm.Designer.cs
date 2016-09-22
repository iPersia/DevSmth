namespace Nzl.Smth.Forms
{
    partial class TabbedBrowserSettingsForm
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.gpAutoUpdating = new DevExpress.XtraEditors.GroupControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbNewMailCheckingInterval = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTop10sLoadingInterval = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSectionTopUpdatingInterval = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.gcSkins = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.btnClearCache = new DevExpress.XtraEditors.SimpleButton();
            this.gcUISettings = new DevExpress.XtraEditors.GroupControl();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBaseControlLocationMargin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBaseControlContainerLocationMargin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gpAutoUpdating)).BeginInit();
            this.gpAutoUpdating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNewMailCheckingInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTop10sLoadingInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSectionTopUpdatingInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSkins)).BeginInit();
            this.gcSkins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUISettings)).BeginInit();
            this.gcUISettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaseControlLocationMargin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaseControlContainerLocationMargin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(144, 438);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpAutoUpdating
            // 
            this.gpAutoUpdating.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.gpAutoUpdating.Appearance.Options.UseBackColor = true;
            this.gpAutoUpdating.Controls.Add(this.label6);
            this.gpAutoUpdating.Controls.Add(this.cmbNewMailCheckingInterval);
            this.gpAutoUpdating.Controls.Add(this.label5);
            this.gpAutoUpdating.Controls.Add(this.label4);
            this.gpAutoUpdating.Controls.Add(this.cmbTop10sLoadingInterval);
            this.gpAutoUpdating.Controls.Add(this.label3);
            this.gpAutoUpdating.Controls.Add(this.label2);
            this.gpAutoUpdating.Controls.Add(this.cmbSectionTopUpdatingInterval);
            this.gpAutoUpdating.Controls.Add(this.label1);
            this.gpAutoUpdating.Location = new System.Drawing.Point(14, 14);
            this.gpAutoUpdating.Name = "gpAutoUpdating";
            this.gpAutoUpdating.Size = new System.Drawing.Size(359, 149);
            this.gpAutoUpdating.TabIndex = 5;
            this.gpAutoUpdating.Text = "Updating intervals";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(322, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(9, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "s.";
            // 
            // cmbNewMailCheckingInterval
            // 
            this.cmbNewMailCheckingInterval.Location = new System.Drawing.Point(227, 101);
            this.cmbNewMailCheckingInterval.Name = "cmbNewMailCheckingInterval";
            this.cmbNewMailCheckingInterval.Properties.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbNewMailCheckingInterval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNewMailCheckingInterval.Size = new System.Drawing.Size(87, 20);
            this.cmbNewMailCheckingInterval.TabIndex = 11;
            this.cmbNewMailCheckingInterval.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "New mail checking interval";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(322, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "s.";
            // 
            // cmbTop10sLoadingInterval
            // 
            this.cmbTop10sLoadingInterval.Location = new System.Drawing.Point(227, 66);
            this.cmbTop10sLoadingInterval.Name = "cmbTop10sLoadingInterval";
            this.cmbTop10sLoadingInterval.Properties.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbTop10sLoadingInterval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTop10sLoadingInterval.Size = new System.Drawing.Size(87, 20);
            this.cmbTop10sLoadingInterval.TabIndex = 8;
            this.cmbTop10sLoadingInterval.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Top 10s loading interval";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(322, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "s.";
            // 
            // cmbSectionTopUpdatingInterval
            // 
            this.cmbSectionTopUpdatingInterval.Location = new System.Drawing.Point(227, 29);
            this.cmbSectionTopUpdatingInterval.Name = "cmbSectionTopUpdatingInterval";
            this.cmbSectionTopUpdatingInterval.Properties.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbSectionTopUpdatingInterval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSectionTopUpdatingInterval.Size = new System.Drawing.Size(87, 20);
            this.cmbSectionTopUpdatingInterval.TabIndex = 5;
            this.cmbSectionTopUpdatingInterval.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Setion top updating interval";
            // 
            // panelContainer
            // 
            this.panelContainer.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContainer.Appearance.Options.UseBackColor = true;
            this.panelContainer.Controls.Add(this.gcSkins);
            this.panelContainer.Controls.Add(this.btnClearCache);
            this.panelContainer.Controls.Add(this.gcUISettings);
            this.panelContainer.Controls.Add(this.btnOK);
            this.panelContainer.Controls.Add(this.gpAutoUpdating);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(387, 474);
            this.panelContainer.TabIndex = 6;
            // 
            // gcSkins
            // 
            this.gcSkins.Controls.Add(this.galleryControlClient1);
            this.gcSkins.DesignGalleryGroupIndex = 0;
            this.gcSkins.DesignGalleryItemIndex = 0;
            this.gcSkins.Location = new System.Drawing.Point(14, 294);
            this.gcSkins.Name = "gcSkins";
            this.gcSkins.Size = new System.Drawing.Size(359, 138);
            this.gcSkins.TabIndex = 3;
            this.gcSkins.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.gcSkins;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(338, 134);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCache.Location = new System.Drawing.Point(259, 438);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(114, 27);
            this.btnClearCache.TabIndex = 7;
            this.btnClearCache.TabStop = false;
            this.btnClearCache.Text = "Clear cache";
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // gcUISettings
            // 
            this.gcUISettings.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.gcUISettings.Appearance.Options.UseBackColor = true;
            this.gcUISettings.Controls.Add(this.label7);
            this.gcUISettings.Controls.Add(this.label9);
            this.gcUISettings.Controls.Add(this.cmbBaseControlLocationMargin);
            this.gcUISettings.Controls.Add(this.label10);
            this.gcUISettings.Controls.Add(this.label11);
            this.gcUISettings.Controls.Add(this.cmbBaseControlContainerLocationMargin);
            this.gcUISettings.Controls.Add(this.label12);
            this.gcUISettings.Location = new System.Drawing.Point(14, 168);
            this.gcUISettings.Name = "gcUISettings";
            this.gcUISettings.Size = new System.Drawing.Size(359, 120);
            this.gcUISettings.TabIndex = 6;
            this.gcUISettings.Text = "UI settings";
            // 
            // label7
            // 
            this.label7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label7.Appearance.Options.UseForeColor = true;
            this.label7.Location = new System.Drawing.Point(55, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "UI settings take effect need restart the App.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(322, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "px";
            // 
            // cmbBaseControlLocationMargin
            // 
            this.cmbBaseControlLocationMargin.Location = new System.Drawing.Point(227, 66);
            this.cmbBaseControlLocationMargin.Name = "cmbBaseControlLocationMargin";
            this.cmbBaseControlLocationMargin.Properties.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.cmbBaseControlLocationMargin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBaseControlLocationMargin.Size = new System.Drawing.Size(87, 20);
            this.cmbBaseControlLocationMargin.TabIndex = 8;
            this.cmbBaseControlLocationMargin.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(20, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 14);
            this.label10.TabIndex = 7;
            this.label10.Text = "Control container margin";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(322, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 14);
            this.label11.TabIndex = 6;
            this.label11.Text = "px";
            // 
            // cmbBaseControlContainerLocationMargin
            // 
            this.cmbBaseControlContainerLocationMargin.Location = new System.Drawing.Point(227, 29);
            this.cmbBaseControlContainerLocationMargin.Name = "cmbBaseControlContainerLocationMargin";
            this.cmbBaseControlContainerLocationMargin.Properties.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.cmbBaseControlContainerLocationMargin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBaseControlContainerLocationMargin.Size = new System.Drawing.Size(87, 20);
            this.cmbBaseControlContainerLocationMargin.TabIndex = 5;
            this.cmbBaseControlContainerLocationMargin.TabStop = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(20, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 14);
            this.label12.TabIndex = 4;
            this.label12.Text = "Panel container margin";
            // 
            // TabbedBrowserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 474);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TabbedBrowserSettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.gpAutoUpdating)).EndInit();
            this.gpAutoUpdating.ResumeLayout(false);
            this.gpAutoUpdating.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNewMailCheckingInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTop10sLoadingInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSectionTopUpdatingInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSkins)).EndInit();
            this.gcSkins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUISettings)).EndInit();
            this.gcUISettings.ResumeLayout(false);
            this.gcUISettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaseControlLocationMargin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaseControlContainerLocationMargin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl gpAutoUpdating;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSectionTopUpdatingInterval;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTop10sLoadingInterval;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbNewMailCheckingInterval;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.GroupControl gcUISettings;
        private DevExpress.XtraEditors.LabelControl label9;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBaseControlLocationMargin;
        private DevExpress.XtraEditors.LabelControl label10;
        private DevExpress.XtraEditors.LabelControl label11;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBaseControlContainerLocationMargin;
        private DevExpress.XtraEditors.LabelControl label12;
        private DevExpress.XtraEditors.LabelControl label7;
        private DevExpress.XtraEditors.SimpleButton btnClearCache;
        private DevExpress.XtraBars.Ribbon.GalleryControl gcSkins;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}