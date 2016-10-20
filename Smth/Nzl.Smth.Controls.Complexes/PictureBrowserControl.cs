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

        /// <summary>
        /// 
        /// </summary>
        public void RefreshEx()
        {
            if (this._currentPictureTopicNode != null)
            {
                this.Set(this._currentPictureTopicNode.Value);
            }
            else
            {
                this._currentPictureTopicNode = this._currentPictureTopicNode = PictureTopicLoader.Instance.PictureTopics.First;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Set(PictureTopic pt)
        {
            if (pt != null)
            {
                this.labelControl1.Text = pt.Title;
                this.imageSlider.Images.Clear();
                foreach (string url in pt.PictureUrls)
                {
                    this.imageSlider.Images.Add(Nzl.Repository.Repository.GetValue<Image>(url));
                }
            }
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

                if (pc.Name == "panelDown" && pc.Height != 80)
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
                    else
                    {
                        PictureTopicLoader.Instance.LoadNext();
                    }
                }

                this.RefreshEx();
            }
        }

        private void pictureLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this._currentPictureTopicNode != null)
                {
                    if (this._currentPictureTopicNode.Previous != PictureTopicLoader.Instance.PictureTopics.First)
                    {
                        this._currentPictureTopicNode = this._currentPictureTopicNode.Previous;
                    }
                }

                this.RefreshEx();
            }
        }
    }
}
