namespace Nzl.Smth.Controls.Containers
{
    partial class SectionControlContainer
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
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.linklblSectionName = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.linklblPrevious = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Appearance.Options.UseBackColor = true;
            this.panelMenu.Controls.Add(this.btnRefresh);
            this.panelMenu.Controls.Add(this.linklblSectionName);
            this.panelMenu.Controls.Add(this.linklblPrevious);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(317, 40);
            this.panelMenu.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(120, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 27);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // linklblSectionName
            // 
            this.linklblSectionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblSectionName.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblSectionName.Appearance.Options.UseFont = true;
            this.linklblSectionName.Appearance.Options.UseTextOptions = true;
            this.linklblSectionName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.linklblSectionName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.linklblSectionName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblSectionName.Location = new System.Drawing.Point(208, 15);
            this.linklblSectionName.Name = "linklblSectionName";
            this.linklblSectionName.Size = new System.Drawing.Size(100, 14);
            this.linklblSectionName.TabIndex = 1;
            this.linklblSectionName.TabStop = true;
            this.linklblSectionName.Text = "Section";
            // 
            // linklblPrevious
            // 
            this.linklblPrevious.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblPrevious.Appearance.Options.UseFont = true;
            this.linklblPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblPrevious.Location = new System.Drawing.Point(9, 15);
            this.linklblPrevious.Name = "linklblPrevious";
            this.linklblPrevious.Size = new System.Drawing.Size(48, 12);
            this.linklblPrevious.TabIndex = 0;
            this.linklblPrevious.TabStop = true;
            this.linklblPrevious.Text = "Previous";
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panel);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 40);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(317, 466);
            this.panelContainer.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(3, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(311, 100);
            this.panel.TabIndex = 0;
            // 
            // SectionControlContainer
            // 
            this.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.Name = "SectionControlContainer";
            this.Size = new System.Drawing.Size(317, 506);
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblPrevious;
        private DevExpress.XtraEditors.HyperlinkLabelControl linklblSectionName;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.PanelControl panel;
    }
}
