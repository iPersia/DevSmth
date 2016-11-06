namespace Nzl.Smth.Controls.Containers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Datas;
    using Nzl.Web.Page;
    using Nzl.Smth.Utils;

    /// <summary>
    /// 
    /// </summary>
    public partial class BoardControlContainer : BaseElementControlContainer<BoardControl, Board>
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnBoardLinkClicked;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private string _url = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public BoardControlContainer()
        {
            InitializeComponent();
            ///For ToString.
            this.Text = "The board container";
            
            ///
            ///this.SetBaseUrl(@"http://m.newsmth.net/favor");
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [DXBrowsable]
        public string Url
        {
            get
            {
                return this._url;
            }

            set
            {
                this._url = value;
                this.SetBaseUrl(this._url);
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// 
        /// </summary>
        public void Refetch()
        {
            this.SetUrlInfo(false);
            this.FetchPage();
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
        protected override string GetUrl(UrlInfo<BoardControl, Board> info)
        {
            return info.BaseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected override IList<Board> GetItems(WebPage wp)
        {
            IList<Board> boards = SectionUtil.GetFavorBoards(wp);

            ///In search mode, we need to find the direct loading.
            if (boards != null && 
                boards.Count == 0 && 
                wp != null && 
                wp.IsGood)
            {
                string boardName = SmthUtil.GetBoard(wp);
                if (string.IsNullOrEmpty(boardName) == false)
                {
                    Board board = new Board();
                    board.Name = boardName.Substring(0, boardName.IndexOf("("));
                    board.Code = boardName.Replace(board.Name, "").Replace("(", "").Replace(")", "");
                    boards.Add(board);
                }
            }

            return boards;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="item"></param>
        protected override void InitializeControl(BoardControl ctl, Board item)
        {
            base.InitializeControl(ctl, item);
            if (ctl != null && item != null)
            {
                ctl.Name = "bc" + item.Code;
                ctl.OnBoardClicked += Bc_OnLinkClicked;
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
        protected override void RecylingControl(BoardControl ctl)
        {
            base.RecylingControl(ctl);
            if (ctl != null)
            {
                ctl.OnBoardClicked -= Bc_OnLinkClicked;
            }
        }
        #endregion

        #region eventhandler
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
        #endregion

        #region private
        #endregion
    }
}
