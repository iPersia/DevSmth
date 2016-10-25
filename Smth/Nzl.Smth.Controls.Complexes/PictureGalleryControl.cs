using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Nzl.Smth.Configs;

namespace Nzl.Smth.Controls.Complexes
{
    public partial class PictureGalleryControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnImageClicked;

        /// <summary>
        /// 
        /// </summary>
        public PictureGalleryControl()
        {
            InitializeComponent();

            ///
            this.panel.MouseWheel += Panel_MouseWheel;

            ///
            this.panel.Top = Configuration.BaseControlContainerLocationMargin;
            this.panel.Left = Configuration.BaseControlContainerLocationMargin;
            this.panel.Height = this.panelContainer.Height - Configuration.BaseControlContainerLocationMargin * 2;

#if (DEBUG)
            ///For testing.
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
#endif

            ///
            this.SizeChanged += PictureGalleryControl_SizeChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureGalleryControl_SizeChanged(object sender, EventArgs e)
        {
            ///Resizing the panel.
            this.panel.Top = Configuration.BaseControlContainerLocationMargin;
            this.panel.Left = Configuration.BaseControlContainerLocationMargin;
            this.panel.Height = this.panelContainer.Height - Configuration.BaseControlContainerLocationMargin * 2;
            this.panel.Width = this.panelContainer.Width - Configuration.BaseControlContainerLocationMargin * 2;

            ///Resizing the images.
            if (this.Pictures != null)
            {
                int leftPos = Configuration.BaseControlLocationMargin;
                int len = this.panel.Height - Configuration.BaseControlLocationMargin * 2;
                foreach (Control ctl in this.panel.Controls)
                {
                    PictureEdit pe = ctl as PictureEdit;
                    if (pe != null)
                    {
                        pe.Top = Configuration.BaseControlLocationMargin;
                        pe.Left = leftPos;
                        pe.Width = len;
                        pe.Height = len;
                        leftPos += len + Configuration.BaseControlLocationMargin;
                        Image image = pe.Image;
                        if (image != null)
                        {
                            int zoomFactor = image.Height / len;
                            zoomFactor = zoomFactor > image.Width / len ? zoomFactor : image.Width / len;
                            pe.Properties.ZoomPercent = 100 / zoomFactor;
                        }
                    }
                }

                this.panel.Width = this.Pictures.Count * len + Configuration.BaseControlLocationMargin * (this.Pictures.Count + 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            int maxLeft = Configuration.BaseControlLocationMargin;
            int minLeft = this.panelContainer.Width
                        - this.panel.Width
                        - Configuration.BaseControlContainerLocationMargin;
            int newYPos = panel.Location.X + e.Delta;
            newYPos = newYPos > maxLeft ? maxLeft : newYPos;
            newYPos = newYPos < minLeft ? minLeft : newYPos;

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
            this.Clear();
            int leftPos = Configuration.BaseControlLocationMargin;
            int len = this.panel.Height - Configuration.BaseControlLocationMargin * 2;
            foreach (Image image in this.Pictures)
            {
                PictureEdit pe = new PictureEdit();
                pe.Image = image;
                pe.Width = len;
                pe.Height = len;
                pe.Top = Configuration.BaseControlLocationMargin;
                pe.Left = leftPos;
                pe.ReadOnly = true;
                pe.Properties.NullText = "Loading";

                int zoomFactor = image.Height / len;
                zoomFactor = zoomFactor > image.Width / len ? zoomFactor : image.Width / len;
                pe.Properties.ZoomPercent = 100 / zoomFactor;

                leftPos += len + Configuration.BaseControlLocationMargin;
                pe.MouseClick += PictureEdit_MouseClick;
                this.panel.Controls.Add(pe);
            }

            this.panel.Width = this.Pictures.Count * len + Configuration.BaseControlLocationMargin * (this.Pictures.Count + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Clear()
        {
            foreach (Control ctl in this.panel.Controls)
            {
                PictureEdit pe = ctl as PictureEdit;
                if (pe != null)
                {
                    pe.MouseClick -= PictureEdit_MouseClick;
                    pe.Image = null;
                }
            }

            this.panel.Controls.Clear();
            GC.Collect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.OnImageClicked != null)
            {
                this.OnImageClicked(sender, e);
            }
        }
    }
}
