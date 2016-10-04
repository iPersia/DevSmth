namespace Nzl.Smth.Forms
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DevExpress.Office;
    using DevExpress.Office.Services;
    using DevExpress.Office.Utils;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;

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
            this.richtxtContent.ContentChanged += RichEditControl1_ContentChanged;
            this.richtxtContent.HyperlinkClick += RichEditControl1_HyperlinkClick;

            this.richtxtContent.Appearance.Text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.richtxtContent.Appearance.Text.Options.UseFont = true;
            this.richtxtContent.Appearance.Text.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;


            ///Used to get image stream.
            IUriStreamService uriStreamService = this.richtxtContent.GetService<IUriStreamService>();
            uriStreamService.RegisterProvider(new ImageStreamProvider());

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

            this.richtxtContent.Dock = DockStyle.None;

            this.richtxtContent.Height = 100;

            this.richtxtContent.HtmlText = "";

            this.richtxtContent.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;

            this.richtxtContent.AutoSizeMode = DevExpress.XtraRichEdit.AutoSizeMode.Vertical;

            //this.richEditControl1.Text = this.richEditControl2.Text;

            //this.richtxtContent.HtmlText = "<br><a target=\"_blank\" href=\"http://att.newsmth.net/nForum/att/Age/16594611/578\"><img title=\"单击此查看原图\" src=\"http://att.newsmth.net/nForum/att/Age/16594611/578/middle\" class=\"resizeable\" border=\"0\"></a><br><a target=\"_blank\" href=\"http://att.newsmth.net/nForum/att/Age/16594611/213953\"><img title=\"单击此查看原图\" src=\"http://att.newsmth.net/nForum/att/Age/16594611/213953/middle\" class=\"resizeable\" border=\"0\"></a><br><a target=\"_blank\" href=\"http://att.newsmth.net/nForum/att/Age/16594611/660368\"><img title=\"单击此查看原图\" src=\"http://att.newsmth.net/nForum/att/Age/16594611/660368/middle\" class=\"resizeable\" border=\"0\"></a><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;已经有两条类似的了，但是总觉着不是这个毛衣料的，还有一个不是套装，最近蠢蠢欲动的又想入手，唉，快成败家姑娘了了………看着好看就想买……哭死……<br>--<br>FROM 112.243.103.*";

            this.richtxtContent.HtmlText = "看着好看就想买……哭死……<br>--<br>FROM 112.243.103.*";

            //this.richEditControl1.HtmlText = "车买了2个月不到，目前战绩：<br>1，地库停车蹭柱子一次；<br>2，路边停车蹭后车一次，对方没事，自己掉了一条漆，对方没追究；<br>3，地库出口蹭墙一次；<br>4，直行道追尾一次，不严重，发动机盖略变形，给对方赔了400；<br>5，临牌到期，偷懒未挂正式牌被扣12分，实习期所以吊销驾照，后托人花钱撤销了处罚；<br>。。。<br><br>今天早上又左转被直行的出租车把主驾的门撞变形，现在还不知道怎么弄<br><br>真想让把本撕了，唉<br><br>---------<br>直接把图放1楼<br><br><a target=\"_blank\" href=\"http://att.newsmth.net/nForum/att/Picture/1417907/250\"><img title=\"单击此查看原图\" src=\"http://att.newsmth.net/nForum/att/Picture/1417907/250/middle\" class=\"resizeable\" border=\"0\"></a><br>--<br>修改:vooodooo FROM 42.120.74.*<br>FROM 42.120.74.*";

            //this.richEditControl1.HtmlText = "车买了2个月不到，目前战绩：<br>1，地库停车蹭柱子一次；<br>2，路边停车蹭后车一次，对方没事，自己掉了一条漆，对方没追究；<br>3，地库出口蹭墙一次；<br>4，直行道追尾一次，不严重，发动机盖略变形，给对方赔了400；<br>5，临牌到期，偷懒未挂正式牌被扣12分，实习期所以吊销驾照，后托人花钱撤销了处罚；<br>。。。<br><br>今天早上又左转被直行的出租车把主驾的门撞变形，现在还不知道怎么弄<br><br>真想让把本撕了，唉<br><br>---------<br>直接把图放1楼<br><br><br>--<br>修改:vooodooo FROM 42.120.74.*<br>FROM 42.120.74.*";

            this.richtxtContent.SelectAll();

            this.test();

            //WebPage wp = WebPageFactory.CreateWebPage("http://m.newsmth.net/article/AutoWorld/1940340089");
            //if (wp != null && wp.IsGood)
            //{
            //    this.richEditControl1.HtmlText = wp.Html;
            //}            

            this.richtxtContent.Cursor = Cursors.Hand;

            this.richtxtContent.Enabled = true;
            this.richtxtContent.ReadOnly = true;

            //{
            //    Document doc = this.richtxtContent.Document;
            //    doc.BeginUpdate();
            //    doc.Images.Append(DocumentImageSource.FromFile(@"E:\QQTemp\All Users\QQ\Misc\CustomHead2\DynamicFrameRes\1.gif"));
            //    CharacterProperties cp = doc.BeginUpdateCharacters(0, doc.HtmlText.Length);
            //    cp.FontName = "宋体";
            //    cp.FontSize = 9;
            //    doc.EndUpdateCharacters(cp);
            //    doc.EndUpdate();
            //}

            this.simpleButton1.Enabled = true;
        }

        private void test()
        {
            Document doc = this.richtxtContent.Document;
            doc.BeginUpdate();
            try
            {
                {
                    ///Set default font.
                    {
                        CharacterProperties cp = doc.BeginUpdateCharacters(0, doc.Length);
                        cp.FontName = "宋体";
                        cp.FontSize = 10.5F;
                        doc.EndUpdateCharacters(cp);
                    }

                    ///Colored the replied thread content.
                    {
                        string replayPattern = @"【 在 [a-zA-z][a-zA-Z0-9]{1,11} (\((.+)?\) )?的大作中提到: 】[^\r^\n]*[\r\n]+(\:.*[\r\n]*)*";
                        DocumentRange[] drs = doc.FindAll(new Regex(replayPattern));
                        foreach (DocumentRange dr in drs)
                        {
                            doc.Selection = dr;
                            CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                            cp.FontName = "宋体";
                            cp.FontSize = 9;
                            cp.ForeColor = Color.Gray;
                            doc.EndUpdateCharacters(cp);
                        }
                    }

                    ///Colored the From IP.
                    {
                        //string ipPattern = @"--[\r\n]+(修改:[a-zA-z][a-zA-Z0-9]{1,11} FROM (\d+\.){3}(\*|\d+)[\r\n]+)?FROM (\d+\.){3}(\*|\d+)";

                        string docText = doc.Text;
                        string docHtmlText = doc.HtmlText;
                        string ipPattern = @"FROM (\d+\.){3}(\*|\d+)";
                        DocumentRange[] drs = doc.FindAll(new Regex(ipPattern));
                        foreach (DocumentRange dr in drs)
                        {
                            doc.Selection = dr;

                            string text = doc.GetText(dr);
                            CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                            cp.FontName = "宋体";
                            cp.FontSize = 9;
                            cp.ForeColor = Color.Gray;
                            doc.EndUpdateCharacters(cp);
                        }
                    }

                    ///Colored the reply tail.
                    {
                        string repleyContent = SmthUtil.GetReplyText();
                        DocumentRange[] drs = doc.FindAll(new Regex(repleyContent));
                        foreach (DocumentRange dr in drs)
                        {
                            doc.Selection = dr;
                            CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                            cp.FontName = "宋体";
                            cp.FontSize = 9;
                            cp.ForeColor = Color.Gray;
                            doc.EndUpdateCharacters(cp);
                        }
                    }

                    this.richtxtContent.DeselectAll();
                }
            }
            catch
            {

            }
            finally
            {
                doc.EndUpdate();
                this.richtxtContent.EndUpdate();
            }
        }

        private void RichEditControl1_Enter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void RichEditControl1_ContentChanged(object sender, EventArgs e)
        {
            this.richtxtContent.Height = this.richtxtContent.ClientRectangle.Height;

            System.Drawing.Rectangle rect = this.richtxtContent.GetBoundsFromPosition(this.richtxtContent.Document.CaretPosition);

            //rect = this.richEditControl1.GetBoundsFromPosition();

            rect = this.richtxtContent.GetBoundsFromPosition(this.richtxtContent.Document.Range.End);

            System.Diagnostics.Debug.WriteLine("GetBoundsFromPosition is " + rect);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            this.richEditControl2.Enabled = true;
            this.richEditControl2.ReadOnly = false;
            this.richEditControl2.Appearance.Text.ForeColor = System.Drawing.Color.Gray;
            this.richEditControl2.Appearance.Text.BackColor = System.Drawing.Color.Gray;

            this.richtxtContent.Height = 100;

            System.Drawing.Rectangle rect = this.richtxtContent.GetBoundsFromPosition(this.richtxtContent.Document.Range.End);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImageStreamProvider : IUriStreamProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public ImageStreamProvider()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Stream GetStream(string url)
        {
            MemoryStream memoryStream = new MemoryStream();
            Image image = Nzl.Repository.Repository.GetValue<Image>(url);
            if (image != null)
            {                
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                image = Image.FromFile(@"E:\Desktop\Desktop\Latest\ZXing\zxing\core\test\data\blackbox\ean13-5\02.png");
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            }

            return memoryStream;
        }
    }
}
