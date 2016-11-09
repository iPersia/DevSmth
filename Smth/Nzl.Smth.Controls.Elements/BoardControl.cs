namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    

    /// <summary>
    /// Class.
    /// </summary>
    public partial class BoardControl : BaseElementControl<Board>
    {
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardClicked;

        /// <summary>
        /// Ctor.
        /// </summary>
        public BoardControl()
        {
            InitializeComponent();

            ///For ToString.
            this.Text = "The board control";

            ///
            this.linklblBoard.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(linklblBoard_HyperlinkClick);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void PrepareControls()
        {
            base.PrepareControls();

            ///
            this.HyperlinkLabelControls.Add(this.linklblBoard);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Initialize(Board board)
        {
            base.Initialize(board);
            if (board != null)
            {
                this.InitializeLinkLabel(this.linklblBoard, board.Name, board.Code);
                this.linklblBoard.Tag = "Board";
            }
        }

        private  void linklblBoard_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnBoardClicked != null)
            {
                this.OnBoardClicked(sender, e);
            }
        }
    }
}
