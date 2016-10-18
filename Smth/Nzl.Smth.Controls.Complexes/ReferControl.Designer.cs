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
            this.btnReadAll = new DevExpress.XtraEditors.SimpleButton();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcRefer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
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
            this.tcRefer.Location = new System.Drawing.Point(2, 2);
            this.tcRefer.Name = "tcRefer";
            this.tcRefer.Size = new System.Drawing.Size(836, 609);
            this.tcRefer.TabIndex = 0;
            // 
            // btnReadAll
            // 
            this.btnReadAll.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadAll.Appearance.Options.UseFont = true;
            this.btnReadAll.Location = new System.Drawing.Point(356, 7);
            this.btnReadAll.Name = "btnReadAll";
            this.btnReadAll.Size = new System.Drawing.Size(87, 27);
            this.btnReadAll.TabIndex = 0;
            this.btnReadAll.Text = "Read all";
            this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnReadAll);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(840, 40);
            this.panelMenu.TabIndex = 2;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.tcRefer);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 40);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(840, 613);
            this.panelContainer.TabIndex = 3;
            // 
            // ReferControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.Name = "ReferControl";
            this.Size = new System.Drawing.Size(840, 653);
            ((System.ComponentModel.ISupportInitialize)(this.tcRefer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcRefer;
        private DevExpress.XtraEditors.SimpleButton btnReadAll;
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.PanelControl panelContainer;
    }
}
