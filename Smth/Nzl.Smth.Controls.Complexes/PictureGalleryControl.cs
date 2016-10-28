namespace Nzl.Smth.Controls.Complexes
{
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

    /// <summary>
    /// 
    /// </summary>
    public partial class PictureGalleryControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnImageClicked;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Image"></typeparam>
        /// <param name=""></param>
        private IList<Image> _pictures = null;

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
            get
            {
                return this._pictures;
            }

            set
            {
                this._pictures = value;
                if (this._pictures != null)
                {
                    this.ShowEx();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        public void SelectImage(Image image)
        {
            foreach(Control ctl in this.panel.Controls)
            {
                PictureEdit pe = ctl as PictureEdit;
                if (pe!=null && pe.Image == image)
                {
                    pe.Focus();

                    int maxLeft = Configuration.BaseControlLocationMargin;
                    int minLeft = this.panelContainer.Width
                                - this.panel.Width
                                - Configuration.BaseControlContainerLocationMargin;
                    int newYPos = 0 - pe.Left + this.panelContainer.Width / 2;
                    newYPos = newYPos > maxLeft ? maxLeft : newYPos;
                    newYPos = newYPos < minLeft ? minLeft : newYPos;

                    this.panel.Left = newYPos;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowEx()
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
                pe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                int zoomFactor = image.Height / len;
                zoomFactor = zoomFactor > image.Width / len ? zoomFactor : image.Width / len;
                pe.Properties.ZoomPercent = 100 / zoomFactor;

                leftPos += len + Configuration.BaseControlLocationMargin;
                pe.MouseClick += PictureEdit_MouseClick;
                pe.GotFocus += PictureEdit_GotFocus;
                pe.LostFocus += PictureEdit_LostFocus;
                this.panel.Controls.Add(pe);
            }

            this.panel.Width = this.Pictures.Count * len + Configuration.BaseControlLocationMargin * (this.Pictures.Count + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureEdit_LostFocus(object sender, EventArgs e)
        {
            PictureEdit pe = sender as PictureEdit;
            if (pe != null)
            {
                pe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureEdit_GotFocus(object sender, EventArgs e)
        {
            PictureEdit pe = sender as PictureEdit;
            if (pe != null)
            {
                pe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            }
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
