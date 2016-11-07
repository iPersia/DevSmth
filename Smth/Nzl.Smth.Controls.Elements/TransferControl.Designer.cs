namespace Nzl.Smth.Controls.Elements
{
    partial class TransferControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUsers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.ckbThreads = new DevExpress.XtraEditors.CheckEdit();
            this.ckbNoRef = new DevExpress.XtraEditors.CheckEdit();
            this.ckbNoAtt = new DevExpress.XtraEditors.CheckEdit();
            this.linklblTransfer = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbThreads.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbNoRef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbNoAtt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "User";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(171, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Select friend";
            // 
            // cmbUsers
            // 
            this.cmbUsers.Location = new System.Drawing.Point(246, 23);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUsers.Size = new System.Drawing.Size(100, 20);
            this.cmbUsers.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(57, 23);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 3;
            // 
            // ckbThreads
            // 
            this.ckbThreads.Location = new System.Drawing.Point(27, 62);
            this.ckbThreads.Name = "ckbThreads";
            this.ckbThreads.Properties.Caption = "All threads";
            this.ckbThreads.Size = new System.Drawing.Size(130, 19);
            this.ckbThreads.TabIndex = 4;
            this.ckbThreads.CheckedChanged += new System.EventHandler(this.ckbThreads_CheckedChanged);
            // 
            // ckbNoRef
            // 
            this.ckbNoRef.Location = new System.Drawing.Point(171, 62);
            this.ckbNoRef.Name = "ckbNoRef";
            this.ckbNoRef.Properties.Caption = "No references";
            this.ckbNoRef.Size = new System.Drawing.Size(175, 19);
            this.ckbNoRef.TabIndex = 5;
            // 
            // ckbNoAtt
            // 
            this.ckbNoAtt.Location = new System.Drawing.Point(27, 99);
            this.ckbNoAtt.Name = "ckbNoAtt";
            this.ckbNoAtt.Properties.Caption = "No attachments";
            this.ckbNoAtt.Size = new System.Drawing.Size(130, 19);
            this.ckbNoAtt.TabIndex = 6;
            // 
            // linklblTransfer
            // 
            this.linklblTransfer.Appearance.Options.UseTextOptions = true;
            this.linklblTransfer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.linklblTransfer.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.linklblTransfer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.linklblTransfer.Cursor = System.Windows.Forms.Cursors.Default;
            this.linklblTransfer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linklblTransfer.Location = new System.Drawing.Point(2, 135);
            this.linklblTransfer.Name = "linklblTransfer";
            this.linklblTransfer.Size = new System.Drawing.Size(371, 41);
            this.linklblTransfer.TabIndex = 7;
            this.linklblTransfer.Text = "Transfer";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.labelControl1);
            this.panel.Controls.Add(this.linklblTransfer);
            this.panel.Controls.Add(this.labelControl2);
            this.panel.Controls.Add(this.cmbUsers);
            this.panel.Controls.Add(this.ckbNoAtt);
            this.panel.Controls.Add(this.txtUser);
            this.panel.Controls.Add(this.ckbNoRef);
            this.panel.Controls.Add(this.ckbThreads);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(375, 178);
            this.panel.TabIndex = 8;
            // 
            // TransferControl
            // 
            this.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "TransferControl";
            this.Size = new System.Drawing.Size(375, 178);
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbThreads.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbNoRef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbNoAtt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUsers;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.CheckEdit ckbThreads;
        private DevExpress.XtraEditors.CheckEdit ckbNoRef;
        private DevExpress.XtraEditors.CheckEdit ckbNoAtt;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblTransfer;
        private DevExpress.XtraEditors.PanelControl panel;
    }
}
