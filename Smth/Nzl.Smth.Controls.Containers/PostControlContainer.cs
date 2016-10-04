﻿//#define DESIGNMODE
namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Recycling;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Utils;
    using Nzl.Web.Page;
    /// <summary>
    /// 
    /// </summary>
#if (DESIGNMODE)
    public partial class ReferDetailControlContainer : UserControl
#else
    public partial class PostControlContainer : BaseControlContainer<PostControl, Post>
#endif
    {
#if (DESIGNMODE)
#else
        #region events
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnExpandClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnSubjectExpandClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnEditClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReplyClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnNewClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnMailClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserClicked;

        /// <summary>
        /// 
        /// </summary>
        public event LinkClickedEventHandler OnContentLinkClicked;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private Control _parentControl = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public PostControlContainer()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The post container";

            this.SetUrlInfo(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public void SetParentControl(Control ctl)
        {
            this._parentControl = ctl;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public string Url
        {
            set
            {
                this.SetBaseUrl(value);
            }
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override string GetUrl(UrlInfo<PostControl, Post> info)
        {
            return info.BaseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected override IList<Post> GetItems(WebPage wp)
        {
            return PostFactory.CreatePosts(wp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override PanelControl GetPanel()
        {
            return this.panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override PanelControl GetPanelContainer()
        {
            return this.panelContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(PostControl ctl, Post item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "rdc";
                ctl.OnBoardClicked += ReferDetailControl_OnBoardClicked;
                ctl.OnDeleteClicked += ReferDetailControl_OnDeleteClicked;
                ctl.OnEditClicked += ReferDetailControl_OnEditClicked;
                ctl.OnExpandClicked += ReferDetailControl_OnExpandClicked;
                ctl.OnHostClicked += ReferDetailControl_OnHostClicked;
                ctl.OnLastClicked += ReferDetailControl_OnLastClicked;
                ctl.OnMailClicked += ReferDetailControl_OnMailClicked;
                ctl.OnNewClicked += ReferDetailControl_OnNewClicked;
                ctl.OnNextClicked += ReferDetailControl_OnNextClicked;
                ctl.OnReplyClicked += ReferDetailControl_OnReplyClicked;
                ctl.OnSourceClicked += ReferDetailControl_OnSourceClicked;
                ctl.OnSubjectExpandClicked += ReferDetailControl_OnSubjectExpandClicked;
                ctl.OnSubjectLastClicked += ReferDetailControl_OnSubjectLastClicked;
                ctl.OnSubjectNextClicked += ReferDetailControl_OnSubjectNextClicked;
                ctl.OnTextBoxLinkClicked += ReferDetailControl_OnTextBoxLinkClicked;
                ctl.OnTextBoxMouseWheel += this.Container_MouseWheel;
                ctl.OnTransferClicked += ReferDetailControl_OnTransferClicked;
                ctl.OnUserClicked += ReferDetailControl_OnUserClicked;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(PostControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnBoardClicked -= ReferDetailControl_OnBoardClicked;
                ctl.OnExpandClicked -= ReferDetailControl_OnExpandClicked;
                ctl.OnHostClicked -= ReferDetailControl_OnHostClicked;
                ctl.OnLastClicked -= ReferDetailControl_OnLastClicked;
                ctl.OnMailClicked -= ReferDetailControl_OnMailClicked;
                ctl.OnNewClicked -= ReferDetailControl_OnNewClicked;
                ctl.OnNextClicked -= ReferDetailControl_OnNextClicked;
                ctl.OnReplyClicked -= ReferDetailControl_OnReplyClicked;
                ctl.OnSourceClicked -= ReferDetailControl_OnSourceClicked;
                ctl.OnSubjectExpandClicked -= ReferDetailControl_OnSubjectExpandClicked;
                ctl.OnSubjectLastClicked -= ReferDetailControl_OnSubjectLastClicked;
                ctl.OnSubjectNextClicked -= ReferDetailControl_OnSubjectNextClicked;
                ctl.OnTextBoxLinkClicked -= ReferDetailControl_OnTextBoxLinkClicked;
                ctl.OnTextBoxMouseWheel -= this.Container_MouseWheel;
                ctl.OnTransferClicked -= ReferDetailControl_OnTransferClicked;
                ctl.OnUserClicked -= ReferDetailControl_OnUserClicked;
            }
        }

        protected override void RecyclingItem(Post data)
        {
            base.RecyclingItem(data);
            if (data != null && data.Data != null)
            {
                RecycledQueues.AddRecycled<Thread>(data.Data);
                data.Data = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected override void WorkCompleted(UrlInfo<PostControl, Post> info)
        {
            base.WorkCompleted(info);
            if (this._parentControl != null)
            {
                if (info.Status == PageStatus.Normal && info.Result != null && info.Result.Count > 0)
                {
                    this._parentControl.Text = (info.Result[0] as Post).Subject;
                }
            }
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostLoader_ErrorAccured(object sender, MessageEventArgs e)
        {
            this.ShowInformation(e.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnEditClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnEditClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnEditClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string postString = hlc.Tag.ToString();
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(e.Link, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadEdit_Succeeded;
                        pl.Failed += ThreadEdit_Failed;
                        pl.Start();
                    }
                }

                hlc.Tag = null;
            }
        }

        #region ThreadEdit - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadEdit_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Editting the thread is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchLastPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadEdit_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Editting the thread failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnDeleteClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnDeleteClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnDeleteClicked(sender, e);
                if (hlc.Tag != null && hlc.Tag.ToString() == "Yes")
                {
                    PostLoader pl = new PostLoader(e.Link);
                    pl.ErrorAccured += PostLoader_ErrorAccured;
                    pl.Succeeded += ThreadDelete_Succeeded;
                    pl.Failed += ThreadDelete_Failed;
                    pl.Start();
                }

                hlc.Tag = null;
            }
        }

        #region ThreadDelete - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadDelete_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Deleting the thread is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadDelete_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Deleting the thread failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnUserClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnUserClicked != null)
            {
                this.OnUserClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnTransferClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnTransferClicked != null)
            {
                this.OnTransferClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (this.OnContentLinkClicked != null)
            {
                this.OnContentLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnSubjectNextClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.SetBaseUrl(e.Link);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnSubjectLastClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.SetBaseUrl(e.Link);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnSubjectExpandClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnSubjectExpandClicked != null)
            {
                this.OnSubjectExpandClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnSourceClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.SetBaseUrl(e.Link);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnReplyClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnReplyClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnReplyClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string postString = hlc.Tag.ToString();
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(e.Link, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadReply_Succeeded;
                        pl.Failed += ThreadReply_Failed;
                        pl.Start();
                    }
                }

                hlc.Tag = null;
            }
        }

        #region ThreadReply - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadReply_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Replying the thread is completed, the page will be refreshed!");
            this.SetUrlInfo(false);
            this.FetchLastPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadReply_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Replying the thread failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnNextClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.SetBaseUrl(e.Link);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnNewClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnNewClicked != null && hlc != null)
            {
                e.Text = null;
                this.OnNewClicked(sender, e);
                if (e.Text != null)
                {
                    string postString = e.Text;
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(e.Link, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += New_Succeeded;
                        pl.Failed += New_Failed;
                        pl.Start();
                    }
                }
            }
        }

        #region New - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Creating new post is completed!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Creating new post failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnMailClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnMailClicked != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnMailClicked(sender, e);
                if (hlc.Tag != null)
                {
                    string postString = hlc.Tag as string;
                    if (string.IsNullOrEmpty(postString) == false)
                    {
                        PostLoader pl = new PostLoader(Configuration.SendMailUrl, postString);
                        pl.ErrorAccured += PostLoader_ErrorAccured;
                        pl.Succeeded += ThreadMail_Succeeded;
                        pl.Failed += ThreadMail_Failed;
                        pl.Start();
                    }
                }

                hlc.Tag = null;
            }
        }

        #region ThreadMail - Succeeded & Failed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadMail_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Sending mail is completed!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadMail_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Sending mail failed!");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnLastClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.SetBaseUrl(e.Link);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnHostClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            this.SetBaseUrl(e.Link);
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnExpandClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnExpandClicked != null)
            {
                this.OnExpandClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferDetailControl_OnBoardClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnBoardClicked != null)
            {
                this.OnBoardClicked(sender, e);
            }
        }
        #endregion
#endif
    }
}