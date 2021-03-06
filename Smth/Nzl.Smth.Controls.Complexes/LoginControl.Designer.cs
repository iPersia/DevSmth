﻿namespace Nzl.Smth.Controls.Complexes
{
    partial class LoginControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogon = new DevExpress.XtraEditors.SimpleButton();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.ckbSave = new DevExpress.XtraEditors.CheckEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.panelUp = new DevExpress.XtraEditors.PanelControl();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).BeginInit();
            this.panelUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelContainer.Controls.Add(this.btnLogout);
            this.panelContainer.Controls.Add(this.btnLogon);
            this.panelContainer.Controls.Add(this.txtUserID);
            this.panelContainer.Controls.Add(this.ckbSave);
            this.panelContainer.Controls.Add(this.txtPassword);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 40);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(309, 263);
            this.panelContainer.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Appearance.Options.UseFont = true;
            this.btnLogout.Location = new System.Drawing.Point(110, 210);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(87, 27);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "Sign out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogon.Appearance.Options.UseFont = true;
            this.btnLogon.Location = new System.Drawing.Point(77, 169);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(149, 27);
            this.btnLogon.TabIndex = 11;
            this.btnLogon.Text = "Sign in";
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(77, 29);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Size = new System.Drawing.Size(149, 18);
            this.txtUserID.TabIndex = 8;
            // 
            // ckbSave
            // 
            this.ckbSave.EditValue = true;
            this.ckbSave.Location = new System.Drawing.Point(119, 127);
            this.ckbSave.Name = "ckbSave";
            this.ckbSave.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSave.Properties.Appearance.Options.UseFont = true;
            this.ckbSave.Properties.Caption = "Save";
            this.ckbSave.Size = new System.Drawing.Size(56, 19);
            this.ckbSave.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(77, 79);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(149, 18);
            this.txtPassword.TabIndex = 9;
            // 
            // panelUp
            // 
            this.panelUp.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.panelUp.Appearance.Options.UseBackColor = true;
            this.panelUp.Controls.Add(this.lblNote);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(309, 40);
            this.panelUp.TabIndex = 0;
            // 
            // lblNote
            // 
            this.lblNote.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNote.Appearance.Options.UseFont = true;
            this.lblNote.Appearance.Options.UseTextOptions = true;
            this.lblNote.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblNote.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblNote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Location = new System.Drawing.Point(2, 2);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(305, 36);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Sign In && Out";
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelUp);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(309, 303);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).EndInit();
            this.panelUp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.PanelControl panelUp;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
        private DevExpress.XtraEditors.SimpleButton btnLogon;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.CheckEdit ckbSave;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblNote;
    }
}
