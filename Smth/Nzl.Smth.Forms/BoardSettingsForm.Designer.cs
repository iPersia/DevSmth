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
            ((System.ComponentModel.ISupportInitialize)(this.gcBrowseMode)).BeginInit();
            this.gcBrowseMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTopicType)).BeginInit();
            this.gcTopicType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAutoUpdating)).BeginInit();
            this.gcAutoUpdating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAutoUpdating.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(132, 344);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbShowTops
            // 
            this.rbShowTops.AutoSize = true;
            this.rbShowTops.Location = new System.Drawing.Point(21, 39);
            this.rbShowTops.Name = "rbShowTops";
            this.rbShowTops.Size = new System.Drawing.Size(84, 18);
            this.rbShowTops.TabIndex = 0;
            this.rbShowTops.Text = "Show tops";
            this.rbShowTops.UseVisualStyleBackColor = true;
            // 
            // rbNoTops
            // 
            this.rbNoTops.AutoSize = true;
            this.rbNoTops.Location = new System.Drawing.Point(189, 39);
            this.rbNoTops.Name = "rbNoTops";
            this.rbNoTops.Size = new System.Drawing.Size(68, 18);
            this.rbNoTops.TabIndex = 1;
            this.rbNoTops.Text = "No tops";
            this.rbNoTops.UseVisualStyleBackColor = true;
            // 
            // gcBrowseMode
            // 
            this.gcBrowseMode.Controls.Add(this.rbNoTops);
            this.gcBrowseMode.Controls.Add(this.rbShowTops);
            this.gcBrowseMode.Location = new System.Drawing.Point(14, 12);
            this.gcBrowseMode.Name = "gcBrowseMode";
            this.gcBrowseMode.Size = new System.Drawing.Size(325, 78);
            this.gcBrowseMode.TabIndex = 2;
            this.gcBrowseMode.Text = "Browse Mode";
            // 
            // gcTopicType
            // 
            this.gcTopicType.Controls.Add(this.rbReserved);
            this.gcTopicType.Controls.Add(this.rbDigest);
            this.gcTopicType.Controls.Add(this.rbClassic);
            this.gcTopicType.Controls.Add(this.rbSubject);
            this.gcTopicType.Location = new System.Drawing.Point(14, 96);
            this.gcTopicType.Name = "gcTopicType";
            this.gcTopicType.Size = new System.Drawing.Size(325, 100);
            this.gcTopicType.TabIndex = 4;
            this.gcTopicType.Text = "Topic type";
            // 
            // rbReserved
            // 
            this.rbReserved.AutoSize = true;
            this.rbReserved.Location = new System.Drawing.Point(189, 68);
            this.rbReserved.Name = "rbReserved";
            this.rbReserved.Size = new System.Drawing.Size(75, 18);
            this.rbReserved.TabIndex = 7;
            this.rbReserved.Text = "Reserved";
            this.rbReserved.UseVisualStyleBackColor = true;
            // 
            // rbDigest
            // 
            this.rbDigest.AutoSize = true;
            this.rbDigest.Location = new System.Drawing.Point(21, 69);
            this.rbDigest.Name = "rbDigest";
            this.rbDigest.Size = new System.Drawing.Size(59, 18);
            this.rbDigest.TabIndex = 6;
            this.rbDigest.Text = "Digest";
            this.rbDigest.UseVisualStyleBackColor = true;
            // 
            // rbClassic
            // 
            this.rbClassic.AutoSize = true;
            this.rbClassic.Location = new System.Drawing.Point(189, 34);
            this.rbClassic.Name = "rbClassic";
            this.rbClassic.Size = new System.Drawing.Size(58, 18);
            this.rbClassic.TabIndex = 5;
            this.rbClassic.Text = "Classic";
            this.rbClassic.UseVisualStyleBackColor = true;
            // 
            // rbSubject
            // 
            this.rbSubject.AutoSize = true;
            this.rbSubject.Location = new System.Drawing.Point(21, 34);
            this.rbSubject.Name = "rbSubject";
            this.rbSubject.Size = new System.Drawing.Size(67, 18);
            this.rbSubject.TabIndex = 4;
            this.rbSubject.Text = "Subject";
            this.rbSubject.UseVisualStyleBackColor = true;
            // 
            // gcAutoUpdating
            // 
            this.gcAutoUpdating.Controls.Add(this.labelControl1);
            this.gcAutoUpdating.Controls.Add(this.cmbInterval);
            this.gcAutoUpdating.Controls.Add(this.label1);
            this.gcAutoUpdating.Controls.Add(this.ckbAutoUpdating);
            this.gcAutoUpdating.Location = new System.Drawing.Point(14, 202);
            this.gcAutoUpdating.Name = "gcAutoUpdating";
            this.gcAutoUpdating.Size = new System.Drawing.Size(325, 125);
            this.gcAutoUpdating.TabIndex = 6;
            this.gcAutoUpdating.Text = "Auto Updating in Latest Reply";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(175, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(9, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "s.";
            // 
            // cmbInterval
            // 
            this.cmbInterval.Location = new System.Drawing.Point(81, 73);
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
            this.cmbInterval.TabIndex = 8;
            this.cmbInterval.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Interval is";
            // 
            // ckbAutoUpdating
            // 
            this.ckbAutoUpdating.Location = new System.Drawing.Point(21, 38);
            this.ckbAutoUpdating.Name = "ckbAutoUpdating";
            this.ckbAutoUpdating.Properties.Caption = "Auto updating";
            this.ckbAutoUpdating.Size = new System.Drawing.Size(119, 19);
            this.ckbAutoUpdating.TabIndex = 6;
            this.ckbAutoUpdating.TabStop = false;
            // 
            // BoardSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 383);
            this.Controls.Add(this.gcAutoUpdating);
            this.Controls.Add(this.gcTopicType);
            this.Controls.Add(this.gcBrowseMode);
            this.Controls.Add(this.btnOK);
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
    }
}