using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Nzl.Smth.Controls.Complexes
{
    public partial class PictureGalleryControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public PictureGalleryControl()
        {
            InitializeComponent();

            ///
            this.panel.MouseWheel += Panel_MouseWheel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            int maxHeight = 1;
            int minHeight = this.panelContainer.Width
                          - this.panel.Width;
            int newYPos = panel.Location.X + e.Delta;
            newYPos = newYPos > maxHeight ? maxHeight : newYPos;
            newYPos = newYPos < minHeight ? minHeight : newYPos;

            this.panel.Left = newYPos;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<Image> Pictures
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowEx()
        {
            int leftPos = 1;
            this.panel.Controls.Clear();
            int len = this.panel.Height - 2;
            foreach (Image image in this.Pictures)
            {
                PictureEdit pe = new PictureEdit();
                pe.Image = image;
                pe.Width = len;
                pe.Height = len;
                pe.Top = 1;
                pe.Left = leftPos;
                pe.ReadOnly = true;
                pe.Properties.NullText = "Loading";

                int zoomFactor = image.Height / len;
                zoomFactor = zoomFactor > image.Width / len ? zoomFactor : image.Width / len;
                pe.Properties.ZoomPercent = 100 / zoomFactor;

                leftPos += len + 1;
                this.panel.Controls.Add(pe);
            }

            this.panel.Width = leftPos + 1;
        }
    }
}
