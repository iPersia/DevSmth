namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using Nzl.Web.Util;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class ReplyControl : BaseControl<Reply>
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
        public ReplyControl()
        {
            InitializeComponent();
            this.linklblAuthor.HyperlinkClick += new HyperlinkClickEventHandler(linklblAuthor_LinkClicked);
            this.linklblTitle.HyperlinkClick += new HyperlinkClickEventHandler(linklblTitle_LinkClicked);
        }

        public override void Initialize(Reply refer)
        {
            base.Initialize(refer);
            if (refer != null)
            {
                this.linklblTitle.Text = CommonUtil.ReplaceSpecialChars(refer.Title);
                this.linklblTitle.Text = ControlUtil.GetHyperlinkText(this.linklblTitle.Text, refer.Url);
                this.linklblAuthor.Text = refer.Author;
                this.linklblAuthor.Text = ControlUtil.GetHyperlinkText(this.linklblAuthor.Text, refer.Author);
                this.lblDT.Text = refer.DateTime;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Color ForeColor
        {
            set
            {
                //this.linklblTitle.LinkColor = value;
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
