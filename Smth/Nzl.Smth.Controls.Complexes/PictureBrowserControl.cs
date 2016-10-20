namespace Nzl.Smth.Controls.Complexes
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
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
        private LinkedListNode<PictureTopic> _currentPictureTopicNode = null;

        /// <summary>
        /// 
        /// </summary>
        private int _imageIndex = 0;

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public PictureBrowserControl()
        {
            InitializeComponent();
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
        }

        public void RefreshEx()
        {
            this._imageIndex = 0;
            this.imageSlider.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleCenter;
            if (this._currentPictureTopicNode != null)
            {
                this.labelControl1.Text = this._currentPictureTopicNode.Value.Title;
                this.imageSlider.Images.Clear();
                foreach(string url in this._currentPictureTopicNode.Value.PictureUrls)
                {
                    this.imageSlider.Images.Add(Nzl.Repository.Repository.GetValue<Image>(url));
                }

                //this.picture.Image = Nzl.Repository.Repository.GetValue<Image>(this._currentPictureTopicNode.Value.PictureUrls[_imageIndex]);
            }
            else
            {
                this._currentPictureTopicNode = this._currentPictureTopicNode = PictureTopicLoader.Instance.PictureTopics.First;
            }
            
            this.JudgeImageIndex();
        }

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_SizeChanged(object sender, EventArgs e)
        {
            PanelControl pc = sender as PanelControl;
            if (pc != null)
            {
#if (DEBUG)
                System.Diagnostics.Debug.WriteLine("ImageBrowserControl - panel_SizeChanged - Name " + pc.Name + " - Size " + pc.Size);
#endif

                if (pc.Name == "panelUp" && pc.Height != 50)
                {
                    pc.Height = 50;
                }

                if (pc.Name== "panelDown" && pc.Height != 80)
                {
                    pc.Height = 80;

                    //this.panelDownLeft.Width = pc.Width / 2;
                    //this.panelDownRight.Width = pc.Width / 2;
                }

                if (pc.Name == "panelLeft" && pc.Width != 60)
                {
                    pc.Width = 60;
                }

                if (pc.Name == "panelRigth" && pc.Width != 60)
                {
                    pc.Width = 60;
                }
            }
        }
        #endregion

        private void pictureRight_Click(object sender, EventArgs e)
        {
            _imageIndex++;
            this.JudgeImageIndex();
            if (_imageIndex < this._currentPictureTopicNode.Value.PictureUrls.Count)
            {
                //this.picture.Image = Nzl.Repository.Repository.GetValue<Image>(this._currentPictureTopicNode.Value.PictureUrls[_imageIndex]);
            }
        }

        private void pictureLeft_Click(object sender, EventArgs e)
        {
            _imageIndex--;
            this.JudgeImageIndex();
            if (_imageIndex >= 0)
            {
                //this.picture.Image = Nzl.Repository.Repository.GetValue<Image>(this._currentPictureTopicNode.Value.PictureUrls[_imageIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void JudgeImageIndex()
        {
            _imageIndex = _imageIndex < 0 ? 0 : _imageIndex;
            _imageIndex = _imageIndex > this._currentPictureTopicNode.Value.PictureUrls.Count - 1 ? this._currentPictureTopicNode.Value.PictureUrls.Count - 1 : _imageIndex;


            this.pictureLeft.Visible = _imageIndex != 0;
            this.pictureRight.Visible = _imageIndex != this._currentPictureTopicNode.Value.PictureUrls.Count - 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureDownLeft_Click(object sender, EventArgs e)
        {
            if (this._currentPictureTopicNode.Previous != PictureTopicLoader.Instance.PictureTopics.First)
            {
                this._currentPictureTopicNode = this._currentPictureTopicNode.Previous;
            }

            this.RefreshEx();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureDownRight_Click(object sender, EventArgs e)
        {
            if (this._currentPictureTopicNode != PictureTopicLoader.Instance.PictureTopics.Last)
            {
                this._currentPictureTopicNode = this._currentPictureTopicNode.Next;
            }
            else
            {
                PictureTopicLoader.Instance.LoadNext();
            }

            this.RefreshEx();
        }
    }
}
