namespace Nzl.Smth.Forms
{
    partial class BoardSettingsForm
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
            this.rbShowTops = new System.Windows.Forms.RadioButton();
            this.rbNoTops = new System.Windows.Forms.RadioButton();
            this.gcBrowseMode = new DevExpress.XtraEditors.GroupControl();
            this.gcTopicType = new DevExpress.XtraEditors.GroupControl();
            this.rbReserved = new System.Windows.Forms.RadioButton();
            this.rbDigest = new System.Windows.Forms.RadioButton();
            this.rbClassic = new System.Windows.Forms.RadioButton();
            this.rbSubject = new System.Windows.Forms.RadioButton();
            this.gcAutoUpdating = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbInterval = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.ckbAutoUpdating = new DevExpress.XtraEditors.CheckEdit();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcBrowseMode)).BeginInit();
            this.gcBrowseMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTopicType)).BeginInit();
            this.gcTopicType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAutoUpdating)).BeginInit();
            this.gcAutoUpdating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAutoUpdating.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(111, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbShowTops
            // 
            this.rbShowTops.AutoSize = true;
            this.rbShowTops.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbShowTops.Location = new System.Drawing.Point(18, 33);
            this.rbShowTops.Name = "rbShowTops";
            this.rbShowTops.Size = new System.Drawing.Size(77, 16);
            this.rbShowTops.TabIndex = 0;
            this.rbShowTops.Text = "Show tops";
            this.rbShowTops.UseVisualStyleBackColor = true;
            // 
            // rbNoTops
            // 
            this.rbNoTops.AutoSize = true;
            this.rbNoTops.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbNoTops.Location = new System.Drawing.Point(162, 33);
            this.rbNoTops.Name = "rbNoTops";
            this.rbNoTops.Size = new System.Drawing.Size(65, 16);
            this.rbNoTops.TabIndex = 1;
            this.rbNoTops.Text = "No tops";
            this.rbNoTops.UseVisualStyleBackColor = true;
            // 
            // gcBrowseMode
            // 
            this.gcBrowseMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBrowseMode.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcBrowseMode.Appearance.Options.UseFont = true;
            this.gcBrowseMode.AppearanceCaption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcBrowseMode.AppearanceCaption.Options.UseFont = true;
            this.gcBrowseMode.Controls.Add(this.rbNoTops);
            this.gcBrowseMode.Controls.Add(this.rbShowTops);
            this.gcBrowseMode.Location = new System.Drawing.Point(10, 10);
            this.gcBrowseMode.Name = "gcBrowseMode";
            this.gcBrowseMode.Size = new System.Drawing.Size(279, 67);
            this.gcBrowseMode.TabIndex = 2;
            this.gcBrowseMode.Text = "Browse Mode";
            // 
            // gcTopicType
            // 
            this.gcTopicType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTopicType.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcTopicType.Appearance.Options.UseFont = true;
            this.gcTopicType.AppearanceCaption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcTopicType.AppearanceCaption.Options.UseFont = true;
            this.gcTopicType.Controls.Add(this.rbReserved);
            this.gcTopicType.Controls.Add(this.rbDigest);
            this.gcTopicType.Controls.Add(this.rbClassic);
            this.gcTopicType.Controls.Add(this.rbSubject);
            this.gcTopicType.Location = new System.Drawing.Point(10, 82);
            this.gcTopicType.Name = "gcTopicType";
            this.gcTopicType.Size = new System.Drawing.Size(279, 86);
            this.gcTopicType.TabIndex = 4;
            this.gcTopicType.Text = "Topic type";
            // 
            // rbReserved
            // 
            this.rbReserved.AutoSize = true;
            this.rbReserved.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbReserved.Location = new System.Drawing.Point(162, 57);
            this.rbReserved.Name = "rbReserved";
            this.rbReserved.Size = new System.Drawing.Size(71, 16);
            this.rbReserved.TabIndex = 7;
            this.rbReserved.Text = "Reserved";
            this.rbReserved.UseVisualStyleBackColor = true;
            // 
            // rbDigest
            // 
            this.rbDigest.AutoSize = true;
            this.rbDigest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbDigest.Location = new System.Drawing.Point(18, 58);
            this.rbDigest.Name = "rbDigest";
            this.rbDigest.Size = new System.Drawing.Size(59, 16);
            this.rbDigest.TabIndex = 6;
            this.rbDigest.Text = "Digest";
            this.rbDigest.UseVisualStyleBackColor = true;
            // 
            // rbClassic
            // 
            this.rbClassic.AutoSize = true;
            this.rbClassic.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbClassic.Location = new System.Drawing.Point(162, 28);
            this.rbClassic.Name = "rbClassic";
            this.rbClassic.Size = new System.Drawing.Size(65, 16);
            this.rbClassic.TabIndex = 5;
            this.rbClassic.Text = "Classic";
            this.rbClassic.UseVisualStyleBackColor = true;
            // 
            // rbSubject
            // 
            this.rbSubject.AutoSize = true;
            this.rbSubject.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSubject.Location = new System.Drawing.Point(18, 28);
            this.rbSubject.Name = "rbSubject";
            this.rbSubject.Size = new System.Drawing.Size(65, 16);
            this.rbSubject.TabIndex = 4;
            this.rbSubject.Text = "Subject";
            this.rbSubject.UseVisualStyleBackColor = true;
            // 
            // gcAutoUpdating
            // 
            this.gcAutoUpdating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcAutoUpdating.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcAutoUpdating.Appearance.Options.UseFont = true;
            this.gcAutoUpdating.AppearanceCaption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcAutoUpdating.AppearanceCaption.Options.UseFont = true;
            this.gcAutoUpdating.Controls.Add(this.labelControl1);
            this.gcAutoUpdating.Controls.Add(this.cmbInterval);
            this.gcAutoUpdating.Controls.Add(this.label1);
            this.gcAutoUpdating.Controls.Add(this.ckbAutoUpdating);
            this.gcAutoUpdating.Location = new System.Drawing.Point(10, 173);
            this.gcAutoUpdating.Name = "gcAutoUpdating";
            this.gcAutoUpdating.Size = new System.Drawing.Size(279, 107);
            this.gcAutoUpdating.TabIndex = 6;
            this.gcAutoUpdating.Text = "Auto Updating in Latest Reply";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(176, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 12);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "s.";
            // 
            // cmbInterval
            // 
            this.cmbInterval.Location = new System.Drawing.Point(92, 61);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInterval.Properties.Appearance.Options.UseFont = true;
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
            this.cmbInterval.Size = new System.Drawing.Size(75, 18);
            this.cmbInterval.TabIndex = 8;
            this.cmbInterval.TabStop = false;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Interval is";
            // 
            // ckbAutoUpdating
            // 
            this.ckbAutoUpdating.Location = new System.Drawing.Point(18, 33);
            this.ckbAutoUpdating.Name = "ckbAutoUpdating";
            this.ckbAutoUpdating.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbAutoUpdating.Properties.Appearance.Options.UseFont = true;
            this.ckbAutoUpdating.Properties.Caption = "Auto updating";
            this.ckbAutoUpdating.Size = new System.Drawing.Size(102, 19);
            this.ckbAutoUpdating.TabIndex = 6;
            this.ckbAutoUpdating.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.gcBrowseMode);
            this.panelContainer.Controls.Add(this.gcAutoUpdating);
            this.panelContainer.Controls.Add(this.btnOK);
            this.panelContainer.Controls.Add(this.gcTopicType);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(301, 328);
            this.panelContainer.TabIndex = 7;
            // 
            // BoardSettingsForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 328);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BoardSettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.gcBrowseMode)).EndInit();
            this.gcBrowseMode.ResumeLayout(false);
            this.gcBrowseMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTopicType)).EndInit();
            this.gcTopicType.ResumeLayout(false);
            this.gcTopicType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAutoUpdating)).EndInit();
            this.gcAutoUpdating.ResumeLayout(false);
            this.gcAutoUpdating.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAutoUpdating.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.RadioButton rbNoTops;
        private System.Windows.Forms.RadioButton rbShowTops;
        private DevExpress.XtraEditors.GroupControl gcBrowseMode;
        private DevExpress.XtraEditors.GroupControl gcTopicType;
        private System.Windows.Forms.RadioButton rbReserved;
        private System.Windows.Forms.RadioButton rbDigest;
        private System.Windows.Forms.RadioButton rbClassic;
        private System.Windows.Forms.RadioButton rbSubject;
        private DevExpress.XtraEditors.GroupControl gcAutoUpdating;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInterval;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.CheckEdit ckbAutoUpdating;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelContainer;
    }
}