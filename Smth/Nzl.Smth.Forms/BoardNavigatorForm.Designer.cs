﻿namespace Nzl.Smth.Forms
{
    partial class BoardNavigatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardNavigatorForm));
            this.sncSection = new Nzl.Smth.Controls.Containers.SectionControlContainer();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sncSection
            // 
            this.sncSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sncSection.IsRecycled = false;
            this.sncSection.Location = new System.Drawing.Point(2, 2);
            this.sncSection.Name = "sncSection";
            this.sncSection.Size = new System.Drawing.Size(300, 457);
            this.sncSection.Status = Nzl.Recycling.RecycledStatus.Using;
            this.sncSection.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.sncSection);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(304, 461);
            this.panel.TabIndex = 1;
            // 
            // BoardNavigatorForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 461);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BoardNavigatorForm";
            this.Text = "Board Navigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BoardNavigatorForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Containers.SectionControlContainer sncSection;
        private DevExpress.XtraEditors.PanelControl panel;
    }
}