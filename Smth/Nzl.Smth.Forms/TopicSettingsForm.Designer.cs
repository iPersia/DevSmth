namespace Nzl.Smth.Forms
{
    partial class TopicSettingsForm
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
            this.rbLatestReply = new System.Windows.Forms.RadioButton();
            this.rbFirstReply = new System.Windows.Forms.RadioButton();
            this.gpBrowseMode = new DevExpress.XtraEditors.GroupControl();
            this.ckbAutoUpdating = new DevExpress.XtraEditors.CheckEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.gpAutoUpdating = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbInterval = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gpBrowseMode)).BeginInit();
            this.gpBrowseMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAutoUpdating.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpAutoUpdating)).BeginInit();
            this.gpAutoUpdating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbLatestReply
            // 
            this.rbLatestReply.AutoSize = true;
            this.rbLatestReply.Location = new System.Drawing.Point(20, 40);
            this.rbLatestReply.Name = "rbLatestReply";
            this.rbLatestReply.Size = new System.Drawing.Size(92, 18);
            this.rbLatestReply.TabIndex = 0;
            this.rbLatestReply.Text = "Latest Reply";
            this.rbLatestReply.UseVisualStyleBackColor = true;
            this.rbLatestReply.CheckedChanged += new System.EventHandler(this.rbLatestReply_CheckedChanged);
            // 
            // rbFirstReply
            // 
            this.rbFirstReply.AutoSize = true;
            this.rbFirstReply.Location = new System.Drawing.Point(188, 40);
            this.rbFirstReply.Name = "rbFirstReply";
            this.rbFirstReply.Size = new System.Drawing.Size(80, 18);
            this.rbFirstReply.TabIndex = 1;
            this.rbFirstReply.Text = "First Reply";
            this.rbFirstReply.UseVisualStyleBackColor = true;
            // 
            // gpBrowseMode
            // 
            this.gpBrowseMode.Controls.Add(this.rbFirstReply);
            this.gpBrowseMode.Controls.Add(this.rbLatestReply);
            this.gpBrowseMode.Location = new System.Drawing.Point(12, 12);
            this.gpBrowseMode.Name = "gpBrowseMode";
            this.gpBrowseMode.Size = new System.Drawing.Size(323, 75);
            this.gpBrowseMode.TabIndex = 2;
            this.gpBrowseMode.Text = "Browse Mode";
            // 
            // ckbAutoUpdating
            // 
            this.ckbAutoUpdating.Location = new System.Drawing.Point(20, 43);
            this.ckbAutoUpdating.Name = "ckbAutoUpdating";
            this.ckbAutoUpdating.Properties.Caption = "Auto updating";
            this.ckbAutoUpdating.Size = new System.Drawing.Size(119, 19);
            this.ckbAutoUpdating.TabIndex = 3;
            this.ckbAutoUpdating.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(135, 258);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpAutoUpdating
            // 
            this.gpAutoUpdating.Controls.Add(this.label2);
            this.gpAutoUpdating.Controls.Add(this.cmbInterval);
            this.gpAutoUpdating.Controls.Add(this.label1);
            this.gpAutoUpdating.Controls.Add(this.ckbAutoUpdating);
            this.gpAutoUpdating.Location = new System.Drawing.Point(12, 93);
            this.gpAutoUpdating.Name = "gpAutoUpdating";
            this.gpAutoUpdating.Size = new System.Drawing.Size(323, 140);
            this.gpAutoUpdating.TabIndex = 5;
            this.gpAutoUpdating.Text = "Auto Updating in Latest Reply";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(202, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "s.";
            // 
            // cmbInterval
            // 
            this.cmbInterval.Location = new System.Drawing.Point(108, 89);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Properties.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300",
            "600"});
            this.cmbInterval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInterval.Size = new System.Drawing.Size(87, 20);
            this.cmbInterval.TabIndex = 5;
            this.cmbInterval.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Interval is";
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.gpBrowseMode);
            this.panelContainer.Controls.Add(this.gpAutoUpdating);
            this.panelContainer.Controls.Add(this.btnOK);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(351, 306);
            this.panelContainer.TabIndex = 6;
            // 
            // TopicSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 306);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TopicSettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.gpBrowseMode)).EndInit();
            this.gpBrowseMode.ResumeLayout(false);
            this.gpBrowseMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAutoUpdating.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpAutoUpdating)).EndInit();
            this.gpAutoUpdating.ResumeLayout(false);
            this.gpAutoUpdating.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLatestReply;
        private System.Windows.Forms.RadioButton rbFirstReply;
        private DevExpress.XtraEditors.GroupControl gpBrowseMode;
        private DevExpress.XtraEditors.CheckEdit ckbAutoUpdating;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl gpAutoUpdating;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInterval;
        private DevExpress.XtraEditors.PanelControl panelContainer;
    }
}