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
            this.tcc = new Nzl.Smth.Controls.Containers.ThreadControlContainer();
            this.SuspendLayout();
            // 
            // tcc
            // 
            this.tcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcc.IsRecycled = false;
            this.tcc.Location = new System.Drawing.Point(0, 0);
            this.tcc.Name = "tcc";
            this.tcc.Size = new System.Drawing.Size(756, 569);
            this.tcc.Status = Nzl.Recycling.RecycledStatus.Using;
            this.tcc.TabIndex = 0;
            this.tcc.TargetUserID = null;
            this.tcc.Url = null;
            // 
            // TopicForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 569);
            this.Controls.Add(this.tcc);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "TopicForm";
            this.Text = "Topic";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Containers.ThreadControlContainer tcc;
    }
}