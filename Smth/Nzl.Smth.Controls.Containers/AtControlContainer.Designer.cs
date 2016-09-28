namespace Nzl.Smth.Controls.Containers
{
    partial class AtControlContainer
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
            this.scContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenInBrower = new DevExpress.XtraEditors.SimpleButton();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.txtGoTo = new DevExpress.XtraEditors.TextEdit();
            this.lblPage = new DevExpress.XtraEditors.LabelControl();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.scContainer)).BeginInit();
            this.scContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.SuspendLayout();
            // 
            // scContainer
            // 
            this.scContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContainer.Horizontal = false;
            this.scContainer.IsSplitterFixed = true;
            this.scContainer.Location = new System.Drawing.Point(0, 0);
            this.scContainer.Name = "scContainer";
            this.scContainer.Panel1.Controls.Add(this.panelMenu);
            this.scContainer.Panel2.Controls.Add(this.panelContainer);
            this.scContainer.Size = new System.Drawing.Size(840, 635);
            this.scContainer.SplitterPosition = 25;
            this.scContainer.TabIndex = 3;
            // 
            // panelMenu
            // 
            this.panelMenu.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Appearance.Options.UseBackColor = true;
            this.panelMenu.Controls.Add(this.btnRefresh);
            this.panelMenu.Controls.Add(this.btnOpenInBrower);
            this.panelMenu.Controls.Add(this.btnGo);
            this.panelMenu.Controls.Add(this.txtGoTo);
            this.panelMenu.Controls.Add(this.lblPage);
            this.panelMenu.Controls.Add(this.btnLast);
            this.panelMenu.Controls.Add(this.btnFirst);
            this.panelMenu.Controls.Add(this.btnNext);
            this.panelMenu.Controls.Add(this.btnPrev);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(840, 29);
            this.panelMenu.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(318, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 27);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenInBrower
            // 
            this.btnOpenInBrower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenInBrower.Location = new System.Drawing.Point(721, 2);
            this.btnOpenInBrower.Name = "btnOpenInBrower";
            this.btnOpenInBrower.Size = new System.Drawing.Size(37, 27);
            this.btnOpenInBrower.TabIndex = 16;
            this.btnOpenInBrower.TabStop = false;
            this.btnOpenInBrower.Text = "OiB";
            this.btnOpenInBrower.Click += new System.EventHandler(this.btnOpenInBrower_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(799, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(35, 27);
            this.btnGo.TabIndex = 10;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtGoTo
            // 
            this.txtGoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoTo.Location = new System.Drawing.Point(764, 5);
            this.txtGoTo.Name = "txtGoTo";
            this.txtGoTo.Size = new System.Drawing.Size(29, 20);
            this.txtGoTo.TabIndex = 9;
            this.txtGoTo.TabStop = false;
            // 
            // lblPage
            // 
            this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPage.Location = new System.Drawing.Point(135, 8);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(47, 14);
            this.lblPage.TabIndex = 8;
            this.lblPage.Text = "001/100";
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(261, 1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(52, 27);
            this.btnLast.TabIndex = 7;
            this.btnLast.TabStop = false;
            this.btnLast.Text = "Last";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(13, 1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(52, 27);
            this.btnFirst.TabIndex = 6;
            this.btnFirst.TabStop = false;
            this.btnFirst.Text = "First";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(202, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(52, 27);
            this.btnNext.TabIndex = 3;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(71, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(52, 27);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.TabStop = false;
            this.btnPrev.Text = "Prev";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panel);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(840, 601);
            this.panelContainer.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Location = new System.Drawing.Point(5, 5);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(829, 117);
            this.panel.TabIndex = 0;
            // 
            // AtControlContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scContainer);
            this.Name = "AtControlContainer";
            this.Size = new System.Drawing.Size(840, 635);
            ((System.ComponentModel.ISupportInitialize)(this.scContainer)).EndInit();
            this.scContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOpenInBrower;
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.SimpleButton btnGo;
        private DevExpress.XtraEditors.TextEdit txtGoTo;
        private DevExpress.XtraEditors.LabelControl lblPage;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SplitContainerControl scContainer;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
