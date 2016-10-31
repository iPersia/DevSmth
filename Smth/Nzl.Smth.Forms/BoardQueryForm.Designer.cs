namespace Nzl.Smth.Forms
{
    partial class BoardQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardQueryForm));
            this.bccBoards = new Nzl.Smth.Controls.Containers.BoardControlContainer();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.txtBoard = new DevExpress.XtraEditors.TextEdit();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // bccBoards
            // 
            this.bccBoards.Cursor = System.Windows.Forms.Cursors.Default;
            this.bccBoards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bccBoards.IsRecycled = false;
            this.bccBoards.Location = new System.Drawing.Point(2, 2);
            this.bccBoards.Name = "bccBoards";
            this.bccBoards.Size = new System.Drawing.Size(361, 495);
            this.bccBoards.Status = Nzl.Recycling.RecycledStatus.Using;
            this.bccBoards.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnGo);
            this.panelMenu.Controls.Add(this.txtBoard);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(365, 40);
            this.panelMenu.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(317, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(36, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtBoard
            // 
            this.txtBoard.Location = new System.Drawing.Point(12, 11);
            this.txtBoard.Name = "txtBoard";
            this.txtBoard.Size = new System.Drawing.Size(299, 20);
            this.txtBoard.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.bccBoards);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 40);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(365, 499);
            this.panelContainer.TabIndex = 2;
            // 
            // BoardQueryForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 539);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BoardQueryForm";
            this.Text = "Query board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FavorForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBoard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Containers.BoardControlContainer bccBoards;
        private DevExpress.XtraEditors.PanelControl panelMenu;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private DevExpress.XtraEditors.TextEdit txtBoard;
        private DevExpress.XtraEditors.SimpleButton btnGo;
    }
}