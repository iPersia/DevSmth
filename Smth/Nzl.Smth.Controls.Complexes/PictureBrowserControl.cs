namespace Nzl.Smth.Controls.Complexes
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using Nzl.Repository;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Utils;

    /// <summary>
    /// 
    /// </summary>
    public partial class PictureBrowserControl : BaseComplexControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnPictureTopicLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        private LinkedListNode<PictureTopic> _currentPictureTopicNode = null;

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public PictureBrowserControl()
        {
            InitializeComponent();

            ///
            this.imageSlider.MouseWheel += ImageSlider_MouseWheel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageSlider_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                this.imageSlider.SlideNext();
            }
            else
            {
                this.imageSlider.SlidePrev();
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                ///
                this._currentPictureTopicNode = PictureTopicLoader.Instance.PictureTopics.First;

                ///
                this.RefreshEx();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshEx()
        {
            this.RefreshPictures();

            if (this._currentPictureTopicNode == null)
            {
                this._currentPictureTopicNode = this._currentPictureTopicNode = PictureTopicLoader.Instance.PictureTopics.First;
            }

            if (this._currentPictureTopicNode != null)
            {
                this.Set(this._currentPictureTopicNode.Value);
            }

            this.pictureLeft.Visible = this._currentPictureTopicNode != PictureTopicLoader.Instance.PictureTopics.First;
            this.pictureRight.Visible = this._currentPictureTopicNode != PictureTopicLoader.Instance.PictureTopics.Last;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Set(PictureTopic pt)
        {
            if (pt != null)
            {
                this.lcTitle.Text = "<href=" + pt.Url + ">" + pt.Title + "</href>";
                this.imageSlider.Images.Clear();
                foreach (string url in pt.PictureUrls)
                {
                    Image image = Repository.GetValue<Image>(url);
                    if (image!=null)
                    {
                        this.imageSlider.Images.Add(image);
                    }                    
                }
            }
        }

        #region eventhandler        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picture_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureRight_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this._currentPictureTopicNode != null)
                {
                    if (this._currentPictureTopicNode != PictureTopicLoader.Instance.PictureTopics.Last)
                    {
                        this._currentPictureTopicNode = this._currentPictureTopicNode.Next;
                    }
                }

                this.RefreshEx();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this._currentPictureTopicNode != null)
                {
                    if (this._currentPictureTopicNode.Previous != null)
                    {
                        this._currentPictureTopicNode = this._currentPictureTopicNode.Previous;
                    }
                }

                this.RefreshEx();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageSliderDown_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ImageSlider slider = sender as ImageSlider;
                if (slider != null && slider.Tag != null)
                {
                    LinkedListNode<PictureTopic> ptNode = slider.Tag as LinkedListNode<PictureTopic>;
                    if (ptNode != null)
                    {
                        this._currentPictureTopicNode = ptNode;
                    }
                }

                this.RefreshEx();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcTitle_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnPictureTopicLinkClicked != null)
            {
                this.OnPictureTopicLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBrowserControl_SizeChanged(object sender, EventArgs e)
        {
            this.panelUp.Height = 50;
            this.panelDown.Height = 80;
            this.panelLeft.Width = 60;
            this.panelRight.Width = 60;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        private void RefreshPictures()
        {
            IList<Image> images = new List<Image>();
            LinkedListNode<PictureTopic> node = PictureTopicLoader.Instance.PictureTopics.First;
            while(node != null)
            {
                string url = node.Value.PictureUrls[0];
                Image image = Repository.GetValue<Image>(url);
                if (image != null)
                {
                    image.Tag = node;
                }

                images.Add(image);
                node = node.Next;
            }

            this.pgcGallery.Pictures = images;
        }
    }
}
