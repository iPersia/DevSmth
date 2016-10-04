namespace Nzl.Smth.Controls.Complexes
{
    partial class ReferControl
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
            this.tcRefer = new DevExpress.XtraTab.XtraTabControl();
            this.scContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnReadAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tcRefer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scContainer)).BeginInit();
            this.scContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcRefer
            // 
            this.tcRefer.AppearancePage.Header.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcRefer.AppearancePage.Header.Options.UseFont = true;
            this.tcRefer.AppearancePage.HeaderActive.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcRefer.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tcRefer.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcRefer.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tcRefer.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcRefer.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tcRefer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRefer.Location = new System.Drawing.Point(0, 0);
            this.tcRefer.Name = "tcRefer";
            this.tcRefer.Size = new System.Drawing.Size(720, 530);
            this.tcRefer.TabIndex = 0;
            // 
            // scContainer
            // 
            this.scContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContainer.Horizontal = false;
            this.scContainer.IsSplitterFixed = true;
            this.scContainer.Location = new System.Drawing.Point(0, 0);
            this.scContainer.Name = "scContainer";
            this.scContainer.Panel1.Controls.Add(this.panelMenu);
            this.scContainer.Panel2.Controls.Add(this.tcRefer);
            this.scContainer.Size = new System.Drawing.Size(720, 560);
            this.scContainer.SplitterPosition = 25;
            this.scContainer.TabIndex = 1;
            // 
            // panelMenu
            // 
            this.panelMenu.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Appearance.Options.UseBackColor = true;
            this.panelMenu.Controls.Add(this.btnReadAll);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(720, 25);
            this.panelMenu.TabIndex = 0;
            // 
            // btnReadAll
            // 
            this.btnReadAll.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadAll.Appearance.Options.UseFont = true;
            this.btnReadAll.Location = new System.Drawing.Point(304, 1);
            this.btnReadAll.Name = "btnReadAll";
            this.btnReadAll.Size = new System.Drawing.Size(75, 23);
            this.btnReadAll.TabIndex = 0;
            this.btnReadAll.Text = "Read all";
            this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
            // 
            // ReferControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scContainer);
            this.Name = "ReferControl";
            this.Size = new System.Drawing.Size(720, 560);
            ((System.ComponentModel.ISupportInitialize)(this.tcRefer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scContainer)).EndInit();
            this.scContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcRefer;
        private DevExpress.XtraEditors.SplitContainerControl scContainer;
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.SimpleButton btnReadAll;
    }
}
