namespace Nzl.Smth.Forms
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Web.Util;    
    using Nzl.Web.Page;
    using Nzl.Smth.Datas;
    
    /// <summary>
    /// Class.
    /// </summary>
    public partial class TestForm : BaseForm
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public TestForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;
            this.richEditControl1.ContentChanged += RichEditControl1_ContentChanged;
            this.richEditControl1.HyperlinkClick += RichEditControl1_HyperlinkClick;

            this.richEditControl1.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.richEditControl1.Appearance.Text.Options.UseFont = true;
            this.richEditControl1.Appearance.Text.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

        }

        private void RichEditControl1_HyperlinkClick(object sender, DevExpress.XtraRichEdit.HyperlinkClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hyperlink is " + e.Hyperlink.NavigateUri);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            this.simpleButton1.Enabled = false;

            this.richEditControl1.Dock = DockStyle.None;

            this.richEditControl1.Height = 100;

            this.richEditControl1.HtmlText = "";

            this.richEditControl1.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;

            this.richEditControl1.AutoSizeMode = DevExpress.XtraRichEdit.AutoSizeMode.Vertical;


            //this.richEditControl1.HtmlText = "车买了2个月不到，目前战绩：<br>1，地库停车蹭柱子一次；<br>2，路边停车蹭后车一次，对方没事，自己掉了一条漆，对方没追究；<br>3，地库出口蹭墙一次；<br>4，直行道追尾一次，不严重，发动机盖略变形，给对方赔了400；<br>5，临牌到期，偷懒未挂正式牌被扣12分，实习期所以吊销驾照，后托人花钱撤销了处罚；<br>。。。<br><br>今天早上又左转被直行的出租车把主驾的门撞变形，现在还不知道怎么弄<br><br>真想让把本撕了，唉<br><br>---------<br>直接把图放1楼<br><br><a target=\"_blank\" href=\"http://att.newsmth.net/nForum/att/Picture/1417907/250\"><img title=\"单击此查看原图\" src=\"http://att.newsmth.net/nForum/att/Picture/1417907/250/middle\" class=\"resizeable\" border=\"0\"></a><br>--<br>修改:vooodooo FROM 42.120.74.*<br>FROM 42.120.74.*";

            this.richEditControl1.HtmlText = "车买了2个月不到，目前战绩：<br>1，地库停车蹭柱子一次；<br>2，路边停车蹭后车一次，对方没事，自己掉了一条漆，对方没追究；<br>3，地库出口蹭墙一次；<br>4，直行道追尾一次，不严重，发动机盖略变形，给对方赔了400；<br>5，临牌到期，偷懒未挂正式牌被扣12分，实习期所以吊销驾照，后托人花钱撤销了处罚；<br>。。。<br><br>今天早上又左转被直行的出租车把主驾的门撞变形，现在还不知道怎么弄<br><br>真想让把本撕了，唉<br><br>---------<br>直接把图放1楼<br><br><br>--<br>修改:vooodooo FROM 42.120.74.*<br>FROM 42.120.74.*";

            this.richEditControl1.SelectAll();

            //WebPage wp = WebPageFactory.CreateWebPage("http://m.newsmth.net/article/AutoWorld/1940340089");
            //if (wp != null && wp.IsGood)
            //{
            //    this.richEditControl1.HtmlText = wp.Html;
            //}

            this.richEditControl1.Cursor = Cursors.Hand;

            this.richEditControl1.Enabled = true;
            this.richEditControl1.ReadOnly = true;

            {
                Document doc = this.richEditControl1.Document;
                doc.BeginUpdate();
                CharacterProperties cp = doc.BeginUpdateCharacters(0, doc.HtmlText.Length);
                cp.FontName = "宋体";
                cp.FontSize = 9;
                doc.EndUpdateCharacters(cp);
                doc.EndUpdate();
            }

            this.simpleButton1.Enabled = true;
        }

        private void RichEditControl1_Enter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void RichEditControl1_ContentChanged(object sender, EventArgs e)
        {
            this.richEditControl1.Height = this.richEditControl1.ClientRectangle.Height;

            System.Drawing.Rectangle rect = this.richEditControl1.GetBoundsFromPosition(this.richEditControl1.Document.CaretPosition);

            //rect = this.richEditControl1.GetBoundsFromPosition();

            rect = this.richEditControl1.GetBoundsFromPosition(this.richEditControl1.Document.Range.End);

            System.Diagnostics.Debug.WriteLine("GetBoundsFromPosition is " + rect);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.richEditControl2.Appearance.Text.ForeColor = System.Drawing.Color.Gray;
            this.richEditControl2.Appearance.Text.BackColor = System.Drawing.Color.Gray;

            System.Drawing.Rectangle rect = this.richEditControl1.GetBoundsFromPosition(this.richEditControl1.Document.Range.End);
        }
    }
}
