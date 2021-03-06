﻿namespace Nzl.Smth.Controls.Complexes
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTab;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Containers;

    /// <summary>
    /// 
    /// </summary>
    public partial class Top10sBrowserControl : BaseComplexControl
    {
        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTopLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnTopBoardLinkClicked;
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private Timer _timerLoadingTops = new Timer();

        /// <summary>
        /// 
        /// </summary>
        private int _sectionIndex = 1;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Top10sBrowserControl()
        {
            InitializeComponent();
            this.Text = "The top 10s complex control";

            Configuration.OnTop10sLoadingIntervalChanged += Configuration_OnTop10sLoadingIntervalChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = "tpHot";
                this.tcTop10s.TabPages.Add(tp);

                TopControlContainer tbc = new TopControlContainer("http://m.newsmth.net/hot");
                tbc.Location = new Point(0, 0);
                tbc.Name = "tbcHot";
                tbc.SetParent(tp);
                tbc.CreateControl();
                tbc.OnTopBoardLinkClicked += SectionTopsControl_OnTopBoardLinkClicked;
                tbc.OnTopLinkClicked += SectionTopsControl_OnTopLinkClicked;

                /// Set the size firstly, then add the MailControlContainer to TabPage.
                /// The width margin is 10 and
                /// the height margin is 29,
                /// both number is not acurate actually.
                this.Size = new Size(tbc.Width + 10, tbc.Height + 29 + this.panelContainer.Location.Y);
                tp.Controls.Add(tbc);
            }

            this._timerLoadingTops.Interval = Configuration.Top10sLoadingInterval;
            this._timerLoadingTops.Tick += new EventHandler(_timerLoadingTops_Tick);
            this._timerLoadingTops.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Configuration_OnTop10sLoadingIntervalChanged(object sender, EventArgs e)
        {
            this._timerLoadingTops.Stop();
            this._timerLoadingTops.Interval = Configuration.Top10sLoadingInterval;
            this._timerLoadingTops.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timerLoadingTops_Tick(object sender, EventArgs e)
        {
            if (this._sectionIndex > Configuration.SectionCount)
            {
                this._timerLoadingTops.Stop();
                return;
            }

            XtraTabPage tp = new XtraTabPage();
            tp.Name = "tbcHot" + this._sectionIndex;
            TopControlContainer tbc = new TopControlContainer("http://m.newsmth.net/hot/" + this._sectionIndex);
            tbc.Location = new Point(0, 0);
            tbc.Name = "tbcHot" + this._sectionIndex++;
            tbc.SetParent(tp);
            tbc.CreateControl();
            tbc.OnTopBoardLinkClicked += SectionTopsControl_OnTopBoardLinkClicked;
            tbc.OnTopLinkClicked += SectionTopsControl_OnTopLinkClicked;
            tp.Controls.Add(tbc);
            this.tcTop10s.TabPages.Add(tp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionTopsControl_OnTopLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc= sender as HyperlinkLabelControl;
            if (hlc != null && this.OnTopLinkClicked != null)
            {
                this.OnTopLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionTopsControl_OnTopBoardLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc= sender as HyperlinkLabelControl;
            if (hlc != null && this.OnTopBoardLinkClicked != null)
            {
                this.OnTopBoardLinkClicked(sender, e);
            }
        }
    }
}
