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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureBrowserControl));
            this.panelUp = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelDown = new DevExpress.XtraEditors.PanelControl();
            this.panelMiddle = new DevExpress.XtraEditors.PanelControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.pictureRight = new DevExpress.XtraEditors.PictureEdit();
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.pictureLeft = new DevExpress.XtraEditors.PictureEdit();
            this.imageSlider = new DevExpress.XtraEditors.Controls.ImageSlider();
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).BeginInit();
            this.panelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.Controls.Add(this.labelControl1);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(891, 58);
            this.panelUp.TabIndex = 0;
            this.panelUp.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(887, 54);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "主题：这个天气来坝上草原，那叫一个凉爽~";
            // 
            // panelDown
            // 
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 450);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(891, 80);
            this.panelDown.TabIndex = 0;
            this.panelDown.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panelContainer);
            this.panelMiddle.Controls.Add(this.panelRight);
            this.panelMiddle.Controls.Add(this.panelLeft);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 58);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(891, 392);
            this.panelMiddle.TabIndex = 0;
            this.panelMiddle.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.imageSlider);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(62, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(767, 388);
            this.panelContainer.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.pictureRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(829, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(60, 388);
            this.panelRight.TabIndex = 2;
            this.panelRight.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
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
            this.pictureRight.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureRight.Properties.ZoomAccelerationFactor = 1D;
            this.pictureRight.Size = new System.Drawing.Size(56, 384);
            this.pictureRight.TabIndex = 1;
            this.pictureRight.Click += new System.EventHandler(this.pictureRight_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.pictureLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(60, 388);
            this.panelLeft.TabIndex = 1;
            this.panelLeft.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
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
            this.pictureLeft.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureLeft.Properties.ZoomAccelerationFactor = 1D;
            this.pictureLeft.Size = new System.Drawing.Size(56, 384);
            this.pictureLeft.TabIndex = 1;
            this.pictureLeft.Click += new System.EventHandler(this.pictureLeft_Click);
            // 
            // imageSlider
            // 
            this.imageSlider.CurrentImageIndex = -1;
            this.imageSlider.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSlider.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider.Location = new System.Drawing.Point(2, 2);
            this.imageSlider.Name = "imageSlider";
            this.imageSlider.Size = new System.Drawing.Size(763, 384);
            this.imageSlider.TabIndex = 0;
            this.imageSlider.Text = "imageSlider1";
            this.imageSlider.UseDisabledStatePainter = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.panelUp)).EndInit();
            this.panelUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelUp;
        private DevExpress.XtraEditors.PanelControl panelDown;
        private DevExpress.XtraEditors.PanelControl panelMiddle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.PictureEdit pictureRight;
        private DevExpress.XtraEditors.PictureEdit pictureLeft;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider;
    }
}
