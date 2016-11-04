namespace Nzl.Smth.Controls.Complexes
{
    partial class MailBoxControl
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
            this.tcMailBox = new DevExpress.XtraTab.XtraTabControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcMailBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMailBox
            // 
            this.tcMailBox.AppearancePage.Header.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMailBox.AppearancePage.Header.Options.UseFont = true;
            this.tcMailBox.AppearancePage.HeaderActive.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMailBox.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tcMailBox.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcMailBox.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tcMailBox.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMailBox.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tcMailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMailBox.Location = new System.Drawing.Point(2, 2);
            this.tcMailBox.Name = "tcMailBox";
            this.tcMailBox.Size = new System.Drawing.Size(929, 548);
            this.tcMailBox.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tcMailBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(933, 552);
            this.panel.TabIndex = 0;
            // 
            // MailBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "MailBoxControl";
            this.Size = new System.Drawing.Size(933, 552);
            ((System.ComponentModel.ISupportInitialize)(this.tcMailBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMailBox;
        private DevExpress.XtraEditors.PanelControl panel;
    }
}
