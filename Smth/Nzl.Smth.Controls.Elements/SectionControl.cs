namespace Nzl.Smth.Controls.Elements
{
    using System.Windows.Forms;
    using DevExpress.Utils;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;

    /// <summary>
    /// Class.
    /// </summary>
    public partial class SectionControl : BaseControl<Section>
    {
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnLinkClicked;

        /// <summary>
        /// Ctor.
        /// </summary>
        public SectionControl()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The section control";

            this.linklblSection.HyperlinkClick += new HyperlinkClickEventHandler(linklblBorS_LinkClicked);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void PrepareControls()
        {
            base.PrepareControls();

            ///
            this.HyperlinkLabelControls.Add(this.linklblSection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        public override void Initialize(Section section)
        {
            base.Initialize(section);
            if (section != null)
            {                
                this.linklblSection.Text = section.Name;
                if (section.IsBoard)
                {
                    this.lblType.ForeColor = System.Drawing.Color.Black;
                    this.lblType.Text = "版面";
                    this.Tag = "Board";
                }
                else
                {
                    this.lblType.ForeColor = System.Drawing.Color.Red;
                    this.lblType.Text = "目录";
                    this.Tag = "Section";
                }

                this.linklblSection.AllowHtmlString = true;
                this.linklblSection.Text = ControlUtil.GetHyperlinkText(section.Name, section.Code);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblBorS_LinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnLinkClicked != null)
            {
                this.OnLinkClicked(sender, e);
            }
        }
    }
}
