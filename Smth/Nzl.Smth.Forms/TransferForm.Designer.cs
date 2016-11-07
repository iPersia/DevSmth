namespace Nzl.Smth.Forms
{
    partial class TransferForm
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
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.tccContainer = new Nzl.Smth.Controls.Containers.TransferControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tccContainer);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(469, 260);
            this.panel.TabIndex = 0;
            // 
            // tccContainer
            // 
            this.tccContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tccContainer.IsRecycled = false;
            this.tccContainer.Location = new System.Drawing.Point(2, 2);
            this.tccContainer.Name = "tccContainer";
            this.tccContainer.Size = new System.Drawing.Size(465, 256);
            this.tccContainer.Status = Nzl.Recycling.RecycledStatus.Using;
            this.tccContainer.TabIndex = 0;
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 260);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TransferForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Transfer";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.PanelControl panel;
        private Controls.Containers.TransferControlContainer tccContainer;

        #endregion

        ///private System.Windows.Forms.RichTextBox richTextBoxEx1;
    }
}