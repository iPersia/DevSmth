namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;
    using Nzl.Smth.Utils;    
    using Nzl.Web.Page;
    using Nzl.Web.Util;
    
    /// <summary>
    /// Class.
    /// </summary>
    public partial class TransferControlContainer : BaseElementControlContainer<TransferControl, Transfer>
    {
        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTransferClikced;
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private Control _parentControl = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// Ctor.
        /// </summary>
        public TransferControlContainer()
        {
            InitializeComponent();

            ///For ToString.
            this.Text = "The at container";
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set
            {
                this.SetBaseUrl(value);
            }
        }
        #endregion

        #region override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ///Dock fill
            this.GetPanel().Dock = DockStyle.Fill;
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
        /// <returns></returns>
        protected override string GetUrl(UrlInfo<TransferControl, Transfer> info)
        {
            string url = this.GetCurrentUrl();
            int paramIndex = url.LastIndexOf("?");
            if (paramIndex > 0)
            {
                url = url.Substring(0, paramIndex);
            }

            return url;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        protected override void SetControlEnabled(bool flag)
        {
            base.SetControlEnabled(flag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected override IList<Transfer> GetItems(WebPage wp)
        {
            IList<Transfer> list = new List<Transfer>();
            list.Add(TransferFactory.GetTransfer(wp));
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(TransferControl ctl, Transfer item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "transfer" + item.Url;
                ctl.OnTransferClikced += TransferControl_OnTransferClikced;
                ctl.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferControl_OnTransferClikced(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (this.OnTransferClikced != null && hlc != null)
            {
                hlc.Tag = null;
                this.OnTransferClikced(sender, e);
                if (hlc.Tag != null && hlc.Tag.ToString() == "Yes")
                {
                    PostLoader pl = new PostLoader(e.Link, e.Text);
                    pl.ErrorAccured += PostLoader_ErrorAccured;
                    pl.Succeeded += Transfer_Succeeded;
                    pl.Failed += Transfer_Failed;
                    pl.Start();
                }
            }
        }

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
        private void Transfer_Succeeded(object sender, EventArgs e)
        {
            this.ShowInformation("Transferring is completed!");
            this.SetUrlInfo(false);
            this.FetchLastPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Transfer_Failed(object sender, EventArgs e)
        {
            this.ShowInformation("Transferring failed!");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ctl"></param>
        protected override void RecylingControl(TransferControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnTransferClikced -= TransferControl_OnTransferClikced;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void WorkCompleted(UrlInfo<TransferControl, Transfer> info)
        {
            base.WorkCompleted(info);
        }
        #endregion
    }
}
