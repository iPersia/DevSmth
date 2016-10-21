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

        /// <summary>
        /// 
        /// </summary>
        private IList<ImageSlider> _thumbImageSliders = new List<ImageSlider>();

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public PictureBrowserControl()
        {
            InitializeComponent();

            ///
            _thumbImageSliders.Add(this.imageSliderDown1);
            _thumbImageSliders.Add(this.imageSliderDown2);
            _thumbImageSliders.Add(this.imageSliderDown3);
            _thumbImageSliders.Add(this.imageSliderDown4);
            _thumbImageSliders.Add(this.imageSliderDown5);

            ///
            this.imageSlider.MouseWheel += ImageSlider_MouseWheel;
        }

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

            ///
            this._currentPictureTopicNode = PictureTopicLoader.Instance.PictureTopics.First;

            ///
            this.RefreshEx();

            ///
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshEx()
        {
            if (this._currentPictureTopicNode == null)
            {
                this._currentPictureTopicNode = this._currentPictureTopicNode = PictureTopicLoader.Instance.PictureTopics.First;
            }

            if (this._currentPictureTopicNode != null)
            {
                this.Set(this._currentPictureTopicNode.Value);
            }

            ///
            foreach(ImageSlider slider in this._thumbImageSliders)
            {
                slider.Images.Clear();
                slider.Tag = null;
            }

            this.pictureLeft.Visible = this._currentPictureTopicNode != PictureTopicLoader.Instance.PictureTopics.First;
            this.pictureRight.Visible = this._currentPictureTopicNode != PictureTopicLoader.Instance.PictureTopics.Last;

            ///Set thumb image
            {
                LinkedListNode<PictureTopic> sttNode = this._currentPictureTopicNode;
                LinkedListNode<PictureTopic> prevNode = sttNode.Previous;
                LinkedListNode<PictureTopic> nextNode = sttNode.Next;
                this._thumbImageSliders[2].Images.Add(Repository.GetValue<Image>(sttNode.Value.PictureUrls[0]));
                this._thumbImageSliders[2].Tag = sttNode;
                for (int i = 1; i < 3; i++)
                {
                    if (prevNode != null)
                    {
                        this._thumbImageSliders[2 - i].Images.Add(Repository.GetValue<Image>(prevNode.Value.PictureUrls[0]));
                        this._thumbImageSliders[2 - i].Tag = prevNode;
                        prevNode = prevNode.Previous;
                    }

                    if (nextNode != null)
                    {
                        this._thumbImageSliders[2 + i].Images.Add(Repository.GetValue<Image>(nextNode.Value.PictureUrls[0]));
                        this._thumbImageSliders[2 + i].Tag = nextNode;
                        nextNode = nextNode.Next;
                    }
                }
            }
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
                    this.imageSlider.Images.Add(Repository.GetValue<Image>(url));
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
            this.panelDown1.Width = this.panelDown.Width / 5;
            this.panelDown2.Width = this.panelDown.Width / 5;
            this.panelDown3.Width = this.panelDown.Width / 5;
            this.panelDown4.Width = this.panelDown.Width / 5;
        }
        #endregion        
    }
}
