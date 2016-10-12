namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Web.Util;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class AtControl : BaseControl<At>
    {
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnReplyLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;

        /// <summary>
        /// Ctor.
        /// </summary>
        public AtControl()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The at control";

            this.linklblAuthor.HyperlinkClick += new HyperlinkClickEventHandler(linklblAuthor_LinkClicked);
            this.linklblTitle.HyperlinkClick += new HyperlinkClickEventHandler(linklblTitle_LinkClicked);
        }

        public override void Initialize(At at)
        {
            base.Initialize(at);
            if (at != null)
            {
                this.linklblTitle.Text = ControlUtil.GetHyperlinkText(CommonUtil.ReplaceSpecialChars(at.Title), at.Url);
                this.linklblAuthor.Text = ControlUtil.GetHyperlinkText(at.Author, at.Author);
                this.lblDT.Text = at.DateTime;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Color ForeColor
        {
            set
            {
                this.linklblTitle.Appearance.LinkColor = value;
                this.linklblTitle.Appearance.Options.UseLinkColor = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblAuthor_LinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void linklblTitle_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnReplyLinkClicked != null)
            {
                this.OnReplyLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblDelete_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnDeleteLinkClicked != null)
            {
                this.OnDeleteLinkClicked(sender, e);
            }
        }
    }
}
