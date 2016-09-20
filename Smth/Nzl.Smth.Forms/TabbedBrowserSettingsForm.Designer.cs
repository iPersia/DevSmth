﻿namespace Nzl.Smth.Forms
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
            this.gpAutoUpdating = new System.Windows.Forms.GroupBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbNewMailCheckingInterval = new System.Windows.Forms.ComboBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTop10sLoadingInterval = new System.Windows.Forms.ComboBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSectionTopUpdatingInterval = new System.Windows.Forms.ComboBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnClearCache = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBaseControlLocationMargin = new System.Windows.Forms.ComboBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBaseControlContainerLocationMargin = new System.Windows.Forms.ComboBox();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.gpAutoUpdating.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(127, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpAutoUpdating
            // 
            this.gpAutoUpdating.Controls.Add(this.label6);
            this.gpAutoUpdating.Controls.Add(this.cmbNewMailCheckingInterval);
            this.gpAutoUpdating.Controls.Add(this.label5);
            this.gpAutoUpdating.Controls.Add(this.label4);
            this.gpAutoUpdating.Controls.Add(this.cmbTop10sLoadingInterval);
            this.gpAutoUpdating.Controls.Add(this.label3);
            this.gpAutoUpdating.Controls.Add(this.label2);
            this.gpAutoUpdating.Controls.Add(this.cmbSectionTopUpdatingInterval);
            this.gpAutoUpdating.Controls.Add(this.label1);
            this.gpAutoUpdating.Location = new System.Drawing.Point(12, 12);
            this.gpAutoUpdating.Name = "gpAutoUpdating";
            this.gpAutoUpdating.Size = new System.Drawing.Size(308, 128);
            this.gpAutoUpdating.TabIndex = 5;
            this.gpAutoUpdating.TabStop = false;
            this.gpAutoUpdating.Text = "Updating intervals";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "s.";
            // 
            // cmbNewMailCheckingInterval
            // 
            this.cmbNewMailCheckingInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewMailCheckingInterval.FormattingEnabled = true;
            this.cmbNewMailCheckingInterval.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbNewMailCheckingInterval.Location = new System.Drawing.Point(195, 87);
            this.cmbNewMailCheckingInterval.Name = "cmbNewMailCheckingInterval";
            this.cmbNewMailCheckingInterval.Size = new System.Drawing.Size(75, 20);
            this.cmbNewMailCheckingInterval.TabIndex = 11;
            this.cmbNewMailCheckingInterval.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "New mail checking interval";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "s.";
            // 
            // cmbTop10sLoadingInterval
            // 
            this.cmbTop10sLoadingInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTop10sLoadingInterval.FormattingEnabled = true;
            this.cmbTop10sLoadingInterval.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbTop10sLoadingInterval.Location = new System.Drawing.Point(195, 57);
            this.cmbTop10sLoadingInterval.Name = "cmbTop10sLoadingInterval";
            this.cmbTop10sLoadingInterval.Size = new System.Drawing.Size(75, 20);
            this.cmbTop10sLoadingInterval.TabIndex = 8;
            this.cmbTop10sLoadingInterval.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Top 10s loading interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "s.";
            // 
            // cmbSectionTopUpdatingInterval
            // 
            this.cmbSectionTopUpdatingInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSectionTopUpdatingInterval.FormattingEnabled = true;
            this.cmbSectionTopUpdatingInterval.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbSectionTopUpdatingInterval.Location = new System.Drawing.Point(195, 25);
            this.cmbSectionTopUpdatingInterval.Name = "cmbSectionTopUpdatingInterval";
            this.cmbSectionTopUpdatingInterval.Size = new System.Drawing.Size(75, 20);
            this.cmbSectionTopUpdatingInterval.TabIndex = 5;
            this.cmbSectionTopUpdatingInterval.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Setion top updating interval";
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContainer.Controls.Add(this.btnClearCache);
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.btnOK);
            this.panelContainer.Controls.Add(this.gpAutoUpdating);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(332, 374);
            this.panelContainer.TabIndex = 6;
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(207, 294);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(98, 23);
            this.btnClearCache.TabIndex = 7;
            this.btnClearCache.TabStop = false;
            this.btnClearCache.Text = "Clear cache";
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbBaseControlLocationMargin);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbBaseControlContainerLocationMargin);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 134);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UI settings";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(4, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "UI settings take effect need restart the App.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "px";
            // 
            // cmbBaseControlLocationMargin
            // 
            this.cmbBaseControlLocationMargin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaseControlLocationMargin.FormattingEnabled = true;
            this.cmbBaseControlLocationMargin.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.cmbBaseControlLocationMargin.Location = new System.Drawing.Point(195, 57);
            this.cmbBaseControlLocationMargin.Name = "cmbBaseControlLocationMargin";
            this.cmbBaseControlLocationMargin.Size = new System.Drawing.Size(75, 20);
            this.cmbBaseControlLocationMargin.TabIndex = 8;
            this.cmbBaseControlLocationMargin.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "Control container margin";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "px";
            // 
            // cmbBaseControlContainerLocationMargin
            // 
            this.cmbBaseControlContainerLocationMargin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaseControlContainerLocationMargin.FormattingEnabled = true;
            this.cmbBaseControlContainerLocationMargin.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.cmbBaseControlContainerLocationMargin.Location = new System.Drawing.Point(195, 25);
            this.cmbBaseControlContainerLocationMargin.Name = "cmbBaseControlContainerLocationMargin";
            this.cmbBaseControlContainerLocationMargin.Size = new System.Drawing.Size(75, 20);
            this.cmbBaseControlContainerLocationMargin.TabIndex = 5;
            this.cmbBaseControlContainerLocationMargin.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Panel container margin";
            // 
            // TabbedBrowserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 374);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TabbedBrowserSettingsForm";
            this.Text = "Settings";
            this.gpAutoUpdating.ResumeLayout(false);
            this.gpAutoUpdating.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.GroupBox gpAutoUpdating;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.ComboBox cmbSectionTopUpdatingInterval;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.ComboBox cmbTop10sLoadingInterval;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label6;
        private System.Windows.Forms.ComboBox cmbNewMailCheckingInterval;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.ComboBox cmbBaseControlLocationMargin;
        private DevExpress.XtraEditors.LabelControl label10;
        private DevExpress.XtraEditors.LabelControl label11;
        private System.Windows.Forms.ComboBox cmbBaseControlContainerLocationMargin;
        private DevExpress.XtraEditors.LabelControl label12;
        private DevExpress.XtraEditors.LabelControl label7;
        private DevExpress.XtraEditors.SimpleButton btnClearCache;
    }
}