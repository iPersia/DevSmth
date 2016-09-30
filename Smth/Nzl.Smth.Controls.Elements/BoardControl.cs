﻿namespace Nzl.Smth.Controls.Elements
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
    public partial class BoardControl : BaseControl<Board>
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
                this.linklblBoard.HyperlinkClick -= new DevExpress.Utils.HyperlinkClickEventHandler(linklblBoard_HyperlinkClick);
                this.linklblBoard.Text = ControlUtil.GetHyperlinkText(board.Name, board.Code);
                this.linklblBoard.Tag = "Board";
                //this.linklblBoard.HyperlinkClick += new HyperlinkClickEventHandler(linklblBorS_LinkClicked);
                //this.linklblBoard.Text = board.Name;
                //LinkLabel.Link link = new LinkLabel.Link(0, this.linklblBoard.Text.Length, board.Code);
                //link.Tag = "Board";
                //this.linklblBoard.Links.Clear();
                //this.linklblBoard.Links.Add(link);
            }
        }

        private  void linklblBoard_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnBoardClicked != null)
            {
                this.OnBoardClicked(sender, e);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void linklblBorS_LinkClicked(object sender, HyperlinkClickEventArgs e)
        //{
        //    if (this.OnLinkClicked != null)
        //    {
        //        this.OnLinkClicked(sender, e);
        //    }
        //}
    }
}
