namespace Nzl.Smth.Forms
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.btnSendMail = new DevExpress.XtraEditors.SimpleButton();
            this.txtUser = new DevExpress.XtraRichEdit.RichEditControl();
            this.bgwFetchPage = new System.ComponentModel.BackgroundWorker();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendMail
            // 
            this.btnSendMail.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.Appearance.Options.UseFont = true;
            this.btnSendMail.Location = new System.Drawing.Point(155, 7);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(100, 27);
            this.btnSendMail.TabIndex = 0;
            this.btnSendMail.Text = "Send Mail";
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // txtUser
            // 
            this.txtUser.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtUser.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Appearance.Text.Options.UseFont = true;
            this.txtUser.AutoSizeMode = DevExpress.XtraRichEdit.AutoSizeMode.Vertical;
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(2, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtUser.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtUser.Size = new System.Drawing.Size(426, 23);
            this.txtUser.TabIndex = 0;
            this.txtUser.SizeChanged += new System.EventHandler(this.txtUser_SizeChanged);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnSendMail);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(430, 40);
            this.panelMenu.TabIndex = 1;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.txtUser);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 40);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(430, 352);
            this.panelContainer.TabIndex = 0;
            // 
            // UserForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 392);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.Text = "User";
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraRichEdit.RichEditControl txtUser;
        private DevExpress.XtraEditors.SimpleButton btnSendMail;
        private System.ComponentModel.BackgroundWorker bgwFetchPage;
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.PanelControl panelContainer;
    }
}