namespace Nzl.Smth.Forms
{
    partial class TopicForm
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
            this.tccTopic = new Nzl.Smth.Controls.Containers.ThreadControlContainer();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tccTopic
            // 
            this.tccTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tccTopic.IsRecycled = false;
            this.tccTopic.Location = new System.Drawing.Point(2, 2);
            this.tccTopic.Name = "tccTopic";
            this.tccTopic.Size = new System.Drawing.Size(752, 565);
            this.tccTopic.Status = Nzl.Recycling.RecycledStatus.Using;
            this.tccTopic.TabIndex = 0;
            this.tccTopic.TargetUserID = null;
            this.tccTopic.Url = null;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tccTopic);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(756, 569);
            this.panel.TabIndex = 1;
            // 
            // TopicForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 569);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "TopicForm";
            this.Text = "Topic";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Containers.ThreadControlContainer tccTopic;
        private DevExpress.XtraEditors.PanelControl panel;
    }
}