namespace Nzl.Smth.Controls.Complexes
{
    partial class PictureBrowserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureBrowserControl));
            this.panelUp = new DevExpress.XtraEditors.PanelControl();
            this.lcTitle = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panelDown = new DevExpress.XtraEditors.PanelControl();
            this.pgcGallery = new Nzl.Smth.Controls.Complexes.PictureGalleryControl();
            this.panelMiddle = new DevExpress.XtraEditors.PanelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.imageSlider = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.cmsImageSlider = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.pictureRight = new DevExpress.XtraEditors.PictureEdit();
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.pictureLeft = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).BeginInit();
            this.panelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).BeginInit();
            this.panelDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider)).BeginInit();
            this.cmsImageSlider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.Controls.Add(this.lcTitle);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(891, 58);
            this.panelUp.TabIndex = 0;
            // 
            // lcTitle
            // 
            this.lcTitle.Appearance.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lcTitle.Appearance.Options.UseFont = true;
            this.lcTitle.Appearance.Options.UseTextOptions = true;
            this.lcTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lcTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcTitle.Location = new System.Drawing.Point(2, 2);
            this.lcTitle.Name = "lcTitle";
            this.lcTitle.Size = new System.Drawing.Size(887, 54);
            this.lcTitle.TabIndex = 0;
            this.lcTitle.Text = "主题";
            this.lcTitle.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.lcTitle_HyperlinkClick);
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.pgcGallery);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 444);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(891, 86);
            this.panelDown.TabIndex = 0;
            // 
            // pgcGallery
            // 
            this.pgcGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcGallery.Location = new System.Drawing.Point(2, 2);
            this.pgcGallery.Name = "pgcGallery";
            this.pgcGallery.Pictures = null;
            this.pgcGallery.Size = new System.Drawing.Size(887, 82);
            this.pgcGallery.TabIndex = 0;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panelContainer);
            this.panelMiddle.Controls.Add(this.panelRight);
            this.panelMiddle.Controls.Add(this.panelLeft);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 58);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(891, 386);
            this.panelMiddle.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.imageSlider);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(62, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(767, 382);
            this.panelContainer.TabIndex = 0;
            // 
            // imageSlider
            // 
            this.imageSlider.Appearance.BackColor = System.Drawing.Color.White;
            this.imageSlider.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageSlider.Appearance.Options.UseBackColor = true;
            this.imageSlider.Appearance.Options.UseFont = true;
            this.imageSlider.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageSlider.ContextMenuStrip = this.cmsImageSlider;
            this.imageSlider.CurrentImageIndex = -1;
            this.imageSlider.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSlider.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Squeeze;
            this.imageSlider.Location = new System.Drawing.Point(2, 2);
            this.imageSlider.Name = "imageSlider";
            this.imageSlider.Size = new System.Drawing.Size(763, 378);
            this.imageSlider.TabIndex = 0;
            this.imageSlider.Text = "Image slider";
            this.imageSlider.UseDisabledStatePainter = true;
            // 
            // cmsImageSlider
            // 
            this.cmsImageSlider.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmsImageSlider.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.cmsImageSlider.Name = "cmsImageSlider";
            this.cmsImageSlider.Size = new System.Drawing.Size(153, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.pictureRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(829, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(60, 382);
            this.panelRight.TabIndex = 2;
            // 
            // pictureRight
            // 
            this.pictureRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureRight.EditValue = ((object)(resources.GetObject("pictureRight.EditValue")));
            this.pictureRight.Location = new System.Drawing.Point(2, 2);
            this.pictureRight.Name = "pictureRight";
            this.pictureRight.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureRight.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureRight.Properties.Appearance.Options.UseBackColor = true;
            this.pictureRight.Properties.Appearance.Options.UseFont = true;
            this.pictureRight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureRight.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureRight.Properties.ZoomAccelerationFactor = 1D;
            this.pictureRight.Size = new System.Drawing.Size(56, 378);
            this.pictureRight.TabIndex = 1;
            this.pictureRight.PopupMenuShowing += new DevExpress.XtraEditors.Events.PopupMenuShowingEventHandler(this.picture_PopupMenuShowing);
            this.pictureRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureRight_MouseClick);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.pictureLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(60, 382);
            this.panelLeft.TabIndex = 1;
            // 
            // pictureLeft
            // 
            this.pictureLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureLeft.EditValue = ((object)(resources.GetObject("pictureLeft.EditValue")));
            this.pictureLeft.Location = new System.Drawing.Point(2, 2);
            this.pictureLeft.Name = "pictureLeft";
            this.pictureLeft.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureLeft.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureLeft.Properties.Appearance.Options.UseBackColor = true;
            this.pictureLeft.Properties.Appearance.Options.UseFont = true;
            this.pictureLeft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureLeft.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureLeft.Properties.ZoomAccelerationFactor = 1D;
            this.pictureLeft.Size = new System.Drawing.Size(56, 378);
            this.pictureLeft.TabIndex = 1;
            this.pictureLeft.PopupMenuShowing += new DevExpress.XtraEditors.Events.PopupMenuShowingEventHandler(this.picture_PopupMenuShowing);
            this.pictureLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureLeft_MouseClick);
            // 
            // PictureBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Name = "PictureBrowserControl";
            this.Size = new System.Drawing.Size(891, 530);
            this.SizeChanged += new System.EventHandler(this.PictureBrowserControl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).EndInit();
            this.panelUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).EndInit();
            this.panelDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider)).EndInit();
            this.cmsImageSlider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelUp;
        private DevExpress.XtraEditors.PanelControl panelDown;
        private DevExpress.XtraEditors.PanelControl panelMiddle;
        private DevExpress.XtraEditors.HyperlinkLabelControl lcTitle;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.PictureEdit pictureRight;
        private DevExpress.XtraEditors.PictureEdit pictureLeft;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider;
        private System.Windows.Forms.ContextMenuStrip cmsImageSlider;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private PictureGalleryControl pgcGallery;
    }
}
