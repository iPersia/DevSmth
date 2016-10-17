namespace Nzl.Smth.Controls.Complexes
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraTab;
    using DevExpress.XtraBars;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Containers;

    /// <summary>
    /// 
    /// </summary>
    public partial class MailBoxControl : BaseComplexControl
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnMailLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnDeleteLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event HyperlinkClickEventHandler OnUserLinkClicked;

        /// <summary>
        /// 
        /// </summary>
        public event ItemClickEventHandler OnNewMailClicked;
        #endregion

        #region variable        
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public MailBoxControl()
        {
            InitializeComponent();
            this.Text = "The mail box complex control";

            ///int dWidth = 8;
            ///int dHeight = 29;
            ///Inbox
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = "tpInbox";
                tp.Text = "Inbox";
                this.tcMailBox.TabPages.Add(tp);

                MailControlContainer xbc = new MailControlContainer(MailBoxType.Inbox);
                xbc.Dock = DockStyle.Fill;
                xbc.Url = Configuration.InboxUrl;
                xbc.CreateControl();
                xbc.SetParent(tp);
                xbc.OnMailLinkClicked += Xbc_OnMailLinkClicked;
                xbc.OnUserLinkClicked += Xbc_OnUserLinkClicked;
                xbc.OnDeleteLinkClicked += Xbc_OnDeleteLinkClicked;
                xbc.OnNewMailClicked += Xbc_OnNewMailClicked;

                ///Set the size firstly, then add the MailControlContainer to TabPage.
                ///this.Size = new Size(xbc.Width + dWidth, xbc.Height + dHeight);
                tp.Controls.Add(xbc);
            }

            ///Outbox
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = "tpOutbox";
                tp.Text = "Outbox";
                this.tcMailBox.TabPages.Add(tp);

                MailControlContainer xbc = new MailControlContainer(MailBoxType.Outbox);
                xbc.Dock = DockStyle.Fill;
                xbc.Url = Configuration.OutboxUrl;
                xbc.CreateControl();
                xbc.SetParent(tp);
                xbc.OnMailLinkClicked += Xbc_OnMailLinkClicked;
                xbc.OnUserLinkClicked += Xbc_OnUserLinkClicked;
                xbc.OnDeleteLinkClicked += Xbc_OnDeleteLinkClicked;
                xbc.OnNewMailClicked += Xbc_OnNewMailClicked;
                tp.Controls.Add(xbc);                
            }

            ///Trash
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = "tpTrash";
                tp.Text = "Trash";
                this.tcMailBox.TabPages.Add(tp);

                MailControlContainer xbc = new MailControlContainer(MailBoxType.Trash);
                xbc.Dock = DockStyle.Fill;
                xbc.Url = Configuration.TrashUrl;
                xbc.CreateControl();
                xbc.SetParent(tp);
                xbc.OnMailLinkClicked += Xbc_OnMailLinkClicked;
                xbc.OnUserLinkClicked += Xbc_OnUserLinkClicked;
                xbc.OnDeleteLinkClicked += Xbc_OnDeleteLinkClicked;
                xbc.OnNewMailClicked += Xbc_OnNewMailClicked;
                tp.Controls.Add(xbc);                
            }


            //this._timerLoadingTops.Interval = 8 * 1000;
            //this._timerLoadingTops.Tick += new EventHandler(_timerLoadingTops_Tick);
            //this._timerLoadingTops.Start();
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Xbc_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
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
        private void Xbc_OnMailLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnMailLinkClicked != null)
            {
                this.OnMailLinkClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Xbc_OnNewMailClicked(object sender, ItemClickEventArgs e)
        {
            if (this.OnNewMailClicked != null)
            {
                this.OnNewMailClicked(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Xbc_OnDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (this.OnDeleteLinkClicked != null)
            {
                this.OnDeleteLinkClicked(sender, e);
            }
        }
        #endregion
    }
}
