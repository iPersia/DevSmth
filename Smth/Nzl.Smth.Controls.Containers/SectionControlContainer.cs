﻿namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraLayout;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Datas;
    using Nzl.Web.Page;
    using Nzl.Web.Util;
    using Nzl.Smth.Utils;
    using Nzl.Smth.Logger;

    /// <summary>
    /// NOTE:
    /// When clear the linklabel's links, the linklabel will lose focus.
    /// This causes the SectionNavigationControl lost focus, and the 
    /// SectionNavigationControl's contaier will deactive.
    /// So when the linklabel lose focus, the SectionNavigationControl must
    /// be focused.
    /// </summary>
    public partial class SectionControlContainer : BaseControlContainer<SectionControl,Section>
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnSectionLinkClicked;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private int _margin = 4;

        /// <summary>
        /// 
        /// </summary>
        private Control _parentControl = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public SectionControlContainer()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The section container";

            this.btnRefresh.Left = this.panelMenu.Width / 2 - this.btnRefresh.Width / 2;
            this.linklblPrevious.HyperlinkClick += LinklblPrevious_LinkClicked;
            this.linklblPrevious.LostFocus += LinklblPrevious_LostFocus;
            this.SetBaseUrl(@"http://m.newsmth.net/section");

            this.linklblPrevious.Initialize();
            this.linklblSectionName.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public void SetParent(Control ctl)
        {
            this._parentControl = ctl;
        }
        #endregion
        
        #region override
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
        /// <param name="info"></param>
        /// <returns></returns>
        protected override string GetUrl(UrlInfo<SectionControl, Section> info)
        {
            return info.BaseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected override IList<Section> GetItems(WebPage wp)
        {
            return SectionUtil.GetSections(wp);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(SectionControl ctl, Section item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                if (ctl.Tag.ToString() == "Board")
                {
                    ctl.OnLinkClicked += Bc_OnLinkClicked;
                }

                if (ctl.Tag.ToString() == "Section")
                {
                    ctl.OnLinkClicked += Sc_OnLinkClicked;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void FetchPageOnMouseWheel()
        {
            //Do nothing.
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(SectionControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                if (ctl.Tag.ToString() == "Board")
                {
                    ctl.OnLinkClicked -= Bc_OnLinkClicked;
                }

                if (ctl.Tag.ToString() == "Section")
                {
                    ctl.OnLinkClicked -= Sc_OnLinkClicked;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected override void WorkCompleted(UrlInfo<SectionControl, Section> info)
        {
            base.WorkCompleted(info);
            this.GetInfors(info.WebPage);
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// When clear the linklabel's links, the linklabel will lose focus.
        /// This causes the SectionNavigationControl lost focus, and the 
        /// SectionNavigationControl's contaier will deactive.
        /// So when the linklabel lose focus, the SectionNavigationControl must
        /// be focused.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblPrevious_LostFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sc_OnLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetBaseUrl(SmthUtil.GetSectionUrl(e.Link));
            this.SetUrlInfo(false);            
            this.FetchPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bc_OnLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnBoardLinkClicked != null)
            {
                this.OnBoardLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinklblPrevious_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            this.SetUrlInfo(false);
            if (string.IsNullOrEmpty(e.Link) == false)
            {
                this.SetBaseUrl(e.Link);
                this.FetchPage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.SetUrlInfo(false);
            this.FetchPage();
        }
        #endregion

        #region private
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        private void GetInfors(WebPage wp)
        {
            if (wp != null && wp.IsGood)
            {
                ///Previous
                string url = CommonUtil.GetMatch(@"<div class=\Wsec sp\W><a href=\W(?'SectionUrl'.+)\W>上一层</a>", wp.Html, "SectionUrl");
                this.linklblPrevious.Text = "Previous";
                if (string.IsNullOrEmpty(url) == false)
                {
                    this.linklblPrevious.Text = ControlUtil.GetHyperlinkText(this.linklblPrevious.Text, Configuration.BaseUrl + url);
                }

                ///Section name.
                this.linklblSectionName.Text = CommonUtil.GetMatch(@"<div class=\Wmenu sp\W><a [^>]+>首页</a>\|(?'SectionName'[^<]+)</div>", wp.Html, "SectionName");
                if (this._parentControl != null)
                {
                    this._parentControl.Text = this.linklblSectionName.Text;
                }
            }
        }
        #endregion        
    }
}
