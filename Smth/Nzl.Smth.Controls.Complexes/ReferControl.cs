namespace Nzl.Smth.Controls.Complexes
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraTab;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Containers;
    using Nzl.Smth.Loaders;
    using Nzl.Web.Page;

    /// <summary>
    /// 
    /// </summary>
    public partial class ReferControl : UserControl
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReferLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private AtControlContainer _atControlContainer = null;

        /// <summary>
        /// 
        /// </summary>
        private ReplyControlContainer _replyControlContainer = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public ReferControl()
        {
            InitializeComponent();
            this.SizeChanged += ReferControl_SizeChanged;
            ///At
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = "tpAt";
                tp.Text = "@me";
                this.tcRefer.TabPages.Add(tp);

                this._atControlContainer = new AtControlContainer();
                this._atControlContainer.Dock = DockStyle.Fill;
                this._atControlContainer.CreateControl();
                this._atControlContainer.SetParent(tp);
                this._atControlContainer.OnDeleteLinkClicked += ReplyControlContainer_OnDeleteLinkClicked;
                this._atControlContainer.OnReplyLinkClicked += ReplyControlContainer_OnReplyLinkClicked;
                this._atControlContainer.OnUserLinkClicked += ReplyControlContainer_OnUserLinkClicked;
                tp.Controls.Add(this._atControlContainer);
            }

            ///Refer
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = "tpRefer";
                tp.Text = "Refer";
                this.tcRefer.TabPages.Add(tp);

                this._replyControlContainer = new ReplyControlContainer();
                this._replyControlContainer.Dock = DockStyle.Fill;
                this._replyControlContainer.CreateControl();
                this._replyControlContainer.SetParent(tp);
                this._replyControlContainer.OnDeleteLinkClicked += ReplyControlContainer_OnDeleteLinkClicked;
                this._replyControlContainer.OnReplyLinkClicked += ReplyControlContainer_OnReplyLinkClicked;
                this._replyControlContainer.OnUserLinkClicked += ReplyControlContainer_OnUserLinkClicked;
                tp.Controls.Add(this._replyControlContainer);
            }
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyControlContainer_OnDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnDeleteLinkClicked != null)
            {
                this.OnDeleteLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyControlContainer_OnReplyLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnReferLinkClicked != null)
            {
                this.OnReferLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyControlContainer_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnUserLinkClicked != null)
            {
                this.OnUserLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferControl_SizeChanged(object sender, EventArgs e)
        {
            this.btnReadAll.Left = (this.panelMenu.Width - this.btnReadAll.Width) / 2;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadAll_Click(object sender, EventArgs e)
        {
            PageLoader pl = new PageLoader(Configuration.ReadAllReferUrl);
            pl.PageLoaded += ReadAll_Succeeded;
            pl.PageFailed += ReadAll_Failed;
            PageDispatcher.Instance.Add(pl);
        }

        #region ReadAll - PageLoaded & PageFailed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadAll_Succeeded(object sender, EventArgs e)
        {
            PageLoader pl = sender as PageLoader;
            if (pl != null)
            {
                WebPage wp = pl.GetResult() as WebPage;
                if (wp != null && wp.IsGood && wp.Html.Contains("class=\"top\"") == false)
                {
                    this._atControlContainer.Reload();
                    this._replyControlContainer.Reload();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadAll_Failed(object sender, EventArgs e)
        {
            ///Do nothing...
        }
        #endregion
    }
}
