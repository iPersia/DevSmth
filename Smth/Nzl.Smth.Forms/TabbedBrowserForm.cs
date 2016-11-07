namespace Nzl.Smth.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Reflection;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTab;
    using Nzl.Dispatcher;
    using Nzl.Hook;
    using Nzl.Recycling;
    using Nzl.Web.Page;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Controls.Complexes;
    using Nzl.Smth.Controls.Containers;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;

    /// <summary>
    /// 
    /// </summary>
    public partial class TabbedBrowserForm : BaseForm
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly TabbedBrowserForm Instance = new TabbedBrowserForm();
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, object> _dicWindows = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        private Form _parentForm = null;

        /// <summary>
        /// 
        /// </summary>
        private UserActivityHook _uahKey = new UserActivityHook(false, true);

        /// <summary>
        /// 
        /// </summary>
        private string _entryAssemblyTitle = null;

        /// <summary>
        /// 
        /// </summary>
        private Timer _checkNewInforTimer = new Timer();

        /// <summary>
        /// 
        /// </summary>
        private TransferForm _transferForm = new TransferForm();
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        TabbedBrowserForm()
        {
            InitializeComponent();

            ///
            LogStatus.Instance.OnLoginStatusChanged += LogStatusInstance_OnLoginStatusChanged;
            AtStatus.Instance.OnNewArrived += AtStatusInstance_OnNewArrived;
            MailStatus.Instance.OnNewArrived += MailStatusInstance_OnNewArrived;
            ReplyStatus.Instance.OnNewArrived += ReplyStatusInstance_OnNewArrived;
            Configuration.OnNewMailUpdatingIntervalChanged += Configuration_OnNewMailUpdatingIntervalChanged;
            this._checkNewInforTimer.Tick += CheckNewInforTimer_Tick;
            this._uahKey.KeyUp += new EventHandler<KeyExEventArgs>(Global_KeyUp);
            this._uahKey.Start();
            this.HideWhenDeactivate = false;
        }

        /// <summary>
        /// 
        /// </summary>
        TabbedBrowserForm(Form parent)
            : this()
        {
            this._parentForm = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public void SetParent(Form parent)
        {
            this._parentForm = parent;
        }

        /// <summary>
        /// Clear all tabpages and windows.
        /// </summary>
        public void Clear()
        {
            try
            {
                foreach (XtraTabPage tp in this.xtcBrowser.TabPages)
                {
                    tp.Dispose();
                }

                this.xtcBrowser.TabPages.Clear();
                GC.Collect();
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }
            };

            try
            {
                foreach (Form form in this._dicWindows.Values)
                {
                    form.Dispose();
                }

                this._dicWindows.Clear();
                GC.Collect();
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }
            };

            this._uahKey.Stop();
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Top10sForm.Instance.OnTopLinkClicked += Top10sForm_OnTopLinkClicked;
            Top10sForm.Instance.OnTopBoardLinkClicked += Top10sForm_OnTopBoardLinkClicked;
            BoardNavigatorForm.Instance.OnBoardLinkLableClicked += FavorForm_OnBoardLinkLableClicked;
            BoardQueryForm.Instance.OnBoardLinkLableClicked += FavorForm_OnBoardLinkLableClicked;
            FavorForm.Instance.OnFavorBoardLinkLableClicked += FavorForm_OnBoardLinkLableClicked;
            LoginForm.Instance.OnLoginFailed += LoginForm_OnLoginFailed;
            LoginForm.Instance.OnLogoutFailed += LoginForm_OnLogoutFailed;
            MailBoxForm.Instance.OnTransferLinkClicked += Common_OnThreadTransferLinkClicked;
            this._entryAssemblyTitle = this.GetEntryAssemblyTitle();
            this.Text = Configuration.ApplicationTitle;

            ///
            Nzl.Smth.Controls.Base.InformationCenter.ThreadStart();

#if (DEBUG)
            this.bbiMessage.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
#else
            this.bbiMessage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
#endif

#if (DEBUG)
            ////Just for testing.
            {
            }
#endif
        }
#if (X)
        ////Just for testing.

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.TopicReply_PageLoaded(this, new EventArgs());
        }
#endif
        #endregion

        #region Topic
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void AddTopic(string url, string subject)
        {
            this.Text = subject;
            string key = this.GetXtraTabPageName(url);
            ///Exsits
            {
                XtraTabPage tp = GetTabPage(key);
                if (tp != null)
                {
                    this.xtcBrowser.SelectedTabPage = tp;
                    return;
                }
            }

            ///NOT Exsits
            {
#if (DEBUG)
                Stopwatch sw = new Stopwatch();
                sw.Start();
#endif
                ///Create XtraTabPage
                XtraTabPage tp = new XtraTabPage();
                tp.Name = key;
                tp.Text = subject;
                this.xtcBrowser.TabPages.Add(tp);
                this.xtcBrowser.SelectedTabPage = tp;

                ///Create PanelControl
                PanelControl pc = new PanelControl();
                pc.Dock = DockStyle.Fill;
                tp.Controls.Add(pc);

                ///Create ThreadControlContainer
                ThreadControlContainer tcc = RecycledQueues.GetRecycled<ThreadControlContainer>();
                if (tcc == null)
                {

                    tcc = new ThreadControlContainer();
                }

                tcc.Name = "tcc" + url;
                tcc.Url = url;
                tcc.TargetUserID = null;
                tcc.Dock = DockStyle.Fill;
                tcc.OnThreadDeleteLinkClicked += Common_OnThreadDeleteLinkClicked;
                tcc.OnThreadEditLinkClicked += Common_OnThreadEditLinkClicked;
                tcc.OnThreadMailLinkClicked += Common_OnThreadMailLinkClicked;
                tcc.OnThreadQueryTypeLinkClicked += ThreadControlContainer_OnThreadQueryTypeLinkClicked;
                tcc.OnThreadReplyLinkClicked += Common_OnThreadReplyLinkClicked;
                tcc.OnThreadTransferLinkClicked += Common_OnThreadTransferLinkClicked;
                tcc.OnThreadUserLinkClicked += Common_OnUserLinkClicked;
                tcc.OnTopicReplyLinkClicked += ThreadControlContainer_OnTopicReplyLinkClicked;
                tcc.OnThreadContentLinkClicked += Common_OnRichTextBoxContentLinkClicked;
                tcc.OnBoardLinkClicked += ThreadControlContainer_OnBoardLinkClicked;
                tcc.OnWorkerFailed += Common_OnWorkerFailed;
                tcc.OnWorkerCancelled += Common_OnWorkerCancelled;
                tcc.OnTopicSettingsClicked += ThreadControlContainer_OnTopicSettingsClicked;
                tcc.OnCaptionChanged += ThreadControlContainer_OnCaptionChanged;
                pc.Controls.Add(tcc);
#if (DEBUG)
                sw.Stop();
                System.Diagnostics.Debug.WriteLine(this.GetType().ToString() + " - AddTopic - Create ThreadControlContainer - ElapsedMilliseconds - " + sw.ElapsedMilliseconds);
#endif
                tcc.RefreshingOnSizeChanged(true);
                tcc.Reusing();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControlContainer_OnCaptionChanged(object sender, MessageEventArgs e)
        {
            ThreadControlContainer tcc = sender as ThreadControlContainer;
            if (tcc != null && tcc.Parent != null && tcc.Parent.Parent != null && string.IsNullOrEmpty(e.Message) == false)
            {
                string title = e.Message.Replace("主题:", "").Substring(0, e.Message.LastIndexOf("-"));
                tcc.Parent.Parent.Text = MiscUtil.GetFormattedTitle(tcc, title);
                tcc.Parent.Parent.Tag = e.Message;
                if (this.xtcBrowser.SelectedTabPage == tcc.Parent.Parent as XtraTabPage)
                {
                    this.Text = e.Message;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControlContainer_OnTopicSettingsClicked(object sender, TopicSettingEventArgs e)
        {
            TopicSettingsForm form = new TopicSettingsForm();
            form.Settings.AutoUpdating = e.AutoUpdating;
            form.Settings.BrowserType = e.BrowserType;
            form.Settings.UpdatingInterval = e.UpdatingInterval;
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (e.AutoUpdating != form.Settings.AutoUpdating ||
                    e.BrowserType != form.Settings.BrowserType ||
                    e.UpdatingInterval != form.Settings.UpdatingInterval)
                {
                    e.AutoUpdating = form.Settings.AutoUpdating;
                    e.BrowserType = form.Settings.BrowserType;
                    e.UpdatingInterval = form.Settings.UpdatingInterval;
                    e.Tag = "Updated";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControlContainer_OnBoardLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            DevExpress.XtraBars.BarManager bm = sender as DevExpress.XtraBars.BarManager;
            if (bm != null)
            {
                this.AddBoard(e.Link, TopicBrowserType.Subject, e.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControlContainer_OnTopicReplyLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            DevExpress.XtraBars.BarManager bm = sender as DevExpress.XtraBars.BarManager;
            if (bm != null)
            {
                NewThreadForm threadForm = new NewThreadForm("回复 - " + this.Text,
                                                             "Re: " + this.xtcBrowser.SelectedTabPage.Text);
                threadForm.StartPosition = FormStartPosition.CenterParent;
                if (DialogResult.OK == threadForm.ShowDialog(this))
                {
                    e.Text = threadForm.GetPostString();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadControlContainer_OnThreadQueryTypeLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                string userID = Nzl.Web.Util.CommonUtil.GetMatch(@"au=(?'ID'[a-zA-z][a-zA-Z0-9]{1,11})", e.Link, 1);
                TopicForm topicForm = new TopicForm(Nzl.Web.Util.CommonUtil.GetUrlBase(e.Link), userID);
                topicForm.StartPosition = FormStartPosition.CenterParent;
                topicForm.ShowDialog(this);
                //e.Link.Visited = true;
            }
        }
        #endregion

        #region Board
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public void AddBoard(string boardCode, TopicBrowserType browserType, string title)
        {
            this.Text = CommonUtil.TrimHtml(title);
            string key = this.GetXtraTabPageName(boardCode);
            ///Exsits
            {
                XtraTabPage tp = GetTabPage(key);
                if (tp != null)
                {
                    this.xtcBrowser.SelectedTabPage = tp;
                    return;
                }
            }

            ///NOT Exsits
            {
#if (DEBUG)
                Stopwatch sw = new Stopwatch();
                sw.Start();
#endif
                ///Create XtraTabPage
                XtraTabPage tp = new XtraTabPage();
                tp.Name = key;
                tp.Text = "[ " + title + " ]";
                //tp.ToolTipText = tp.Text;
                this.xtcBrowser.TabPages.Add(tp);
                this.xtcBrowser.SelectedTabPage = tp;

                ///Create PanelControl
                PanelControl pc = new PanelControl();
                pc.Dock = DockStyle.Fill;
                tp.Controls.Add(pc);

                ///Create TopicControlContainer
                TopicControlContainer tcc = RecycledQueues.GetRecycled<TopicControlContainer>();
                if (tcc == null)
                {
                    tcc = new TopicControlContainer();
                }

                tcc.Name = "tcc" + boardCode;
                tcc.Board = boardCode;
                tcc.BrowserType = browserType;
                tcc.OnNewClicked += Common_OnNewClicked;
                tcc.OnTopicLinkClicked += TopicControlContainer_OnTopicLinkClicked;
                tcc.OnPostLinkClicked += TopicControlContainer_OnPostLinkClicked;
                tcc.OnTopicCreateIDLinkClicked += Common_OnUserLinkClicked;
                tcc.OnTopicLastIDLinkClicked += Common_OnUserLinkClicked;
                tcc.OnWorkerFailed += Common_OnWorkerFailed;
                tcc.OnWorkerCancelled += Common_OnWorkerCancelled;
                tcc.OnBoardSettingsClicked += TopicControlContainer_OnBoardSettingsClicked;
                tcc.OnCaptionChanged += TopicControlContainer_OnCaptionChanged;
                tcc.Dock = DockStyle.Fill;
                pc.Controls.Add(tcc);

#if (DEBUG)
                sw.Stop();
                System.Diagnostics.Debug.WriteLine("AddBoard - ElapsedMilliseconds " + sw.ElapsedMilliseconds);
#endif
                ///
                tcc.RefreshingOnSizeChanged(true);
                tcc.Reusing();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControlContainer_OnCaptionChanged(object sender, MessageEventArgs e)
        {
            TopicControlContainer tcc = sender as TopicControlContainer;
            if (tcc != null && tcc.Parent != null && tcc.Parent.Parent != null && string.IsNullOrEmpty(e.Message) == false)
            {
                tcc.Parent.Parent.Text = "【" + e.Message + "】";
                tcc.Parent.Parent.Tag = "版面-" + e.Message;
                if (this.xtcBrowser.SelectedTabPage == tcc.Parent.Parent as XtraTabPage)
                {
                    this.Text = "版面-" + e.Message;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnNewClicked(object sender, HyperlinkClickEventArgs e)
        {
            if (sender != null)
            {
                NewThreadForm threadForm = new NewThreadForm("New post", "");
                threadForm.StartPosition = FormStartPosition.CenterParent;
                if (DialogResult.OK == threadForm.ShowDialog(this))
                {
                    e.Text = threadForm.GetPostString();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControlContainer_OnBoardSettingsClicked(object sender, BoardSettingEventArgs e)
        {
            BoardSettingsForm form = new BoardSettingsForm();
            form.Settings.IsShowTop = e.IsShowTop;
            form.Settings.AutoUpdating = e.AutoUpdating;
            form.Settings.BrowserType = e.BrowserType;
            form.Settings.UpdatingInterval = e.UpdatingInterval;
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (e.IsShowTop != form.Settings.IsShowTop ||
                    e.AutoUpdating != form.Settings.AutoUpdating ||
                    e.BrowserType != form.Settings.BrowserType ||
                    e.UpdatingInterval != form.Settings.UpdatingInterval)
                {
                    e.IsShowTop = form.Settings.IsShowTop;
                    e.AutoUpdating = form.Settings.AutoUpdating;
                    e.BrowserType = form.Settings.BrowserType;
                    e.UpdatingInterval = form.Settings.UpdatingInterval;
                    e.Tag = "Updated";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControlContainer_OnPostLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddPost(e.Link, hlc.PlainText);
                //e.Link.Visited = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicControlContainer_OnTopicLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddTopic(e.Link, hlc.PlainText);
                //e.Link.Visited = true;
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public void AddPost(string url, string title)
        {
            this.Text = title;
            string key = this.GetXtraTabPageName(url);
            ///Exsits
            {
                XtraTabPage tp = GetTabPage(key);
                if (tp != null)
                {
                    this.xtcBrowser.SelectedTabPage = tp;
                    return;
                }
            }

            ///NOT Exsits
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Name = key;
                tp.Text = title;
                this.xtcBrowser.TabPages.Add(tp);
                this.xtcBrowser.SelectedTabPage = tp;

                ///Create PanelControl
                PanelControl pc = new PanelControl();
                pc.Dock = DockStyle.Fill;
                tp.Controls.Add(pc);

                ///Create PostControlContainer
                PostControlContainer pcc = RecycledQueues.GetRecycled<PostControlContainer>();
                if (pcc == null)
                {
                    pcc = new PostControlContainer();
                }

                pcc.Name = "pcc" + url;
                pcc.Url = url;
                pcc.OnBoardClicked += PostControlContainer_OnBoardClicked;
                pcc.OnContentLinkClicked += Common_OnRichTextBoxContentLinkClicked;
                pcc.OnDeleteClicked += Common_OnThreadDeleteLinkClicked;
                pcc.OnEditClicked += Common_OnThreadEditLinkClicked;
                pcc.OnExpandClicked += PostControlContainer_OnExpandClicked;
                pcc.OnMailClicked += Common_OnThreadMailLinkClicked;
                pcc.OnNewClicked += Common_OnNewClicked;
                pcc.OnReplyClicked += Common_OnThreadReplyLinkClicked;
                pcc.OnSubjectExpandClicked += PostControlContainer_OnSubjectExpandClicked;
                pcc.OnTransferClicked += Common_OnThreadTransferLinkClicked;
                pcc.OnUserClicked += Common_OnUserLinkClicked;
                pcc.OnWorkerCancelled += Common_OnWorkerCancelled;
                pcc.OnWorkerFailed += Common_OnWorkerFailed;
                pcc.OnCaptionChanged += PostControlContainer_OnCaptionChanged;
                pcc.Dock = DockStyle.Fill;
                pc.Controls.Add(pcc);

                ///
                pcc.RefreshingOnSizeChanged(true);
                pcc.Reusing();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostControlContainer_OnCaptionChanged(object sender, MessageEventArgs e)
        {
            PostControlContainer pcc = sender as PostControlContainer;
            if (pcc != null && pcc.Parent != null && pcc.Parent.Parent != null && string.IsNullOrEmpty(e.Message) == false)
            {
                string title = e.Message.Replace("主题:", "").Substring(0, e.Message.LastIndexOf("-"));
                pcc.Parent.Parent.Text = MiscUtil.GetFormattedTitle(pcc, title);
                pcc.Parent.Parent.Tag = e.Message;
                if (this.xtcBrowser.SelectedTabPage == pcc.Parent.Parent as XtraTabPage)
                {
                    this.Text = e.Message;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostControlContainer_OnSubjectExpandClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddTopic(e.Link, hlc.Tag.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostControlContainer_OnExpandClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddTopic(e.Link, hlc.Tag.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostControlContainer_OnBoardClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddBoard(e.Link, TopicBrowserType.Classic, hlc.PlainText);
            }
        }
        #endregion

        #region TabPages
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private XtraTabPage GetTabPage(string ctlName)
        {
            lock (this.xtcBrowser)
            {
                foreach (XtraTabPage xtp in this.xtcBrowser.TabPages)
                {
                    if (xtp.Name == ctlName)
                    {
                        return xtp;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtcBrowser_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            this.Text = (this.xtcBrowser.SelectedTabPage == null || this.xtcBrowser.SelectedTabPage.Tag == null) ? Configuration.ApplicationTitle : this.xtcBrowser.SelectedTabPage.Tag.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabbedTopicBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            if (this._parentForm != null)
            {
                this._parentForm.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtcBrowser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.xtcBrowser.SelectedTabPageIndex;
            XtraTabPage tp = this.xtcBrowser.TabPages[index];
            if (index == this.xtcBrowser.TabPages.Count - 1)
            {
                index--;
            }
            else
            {
                index++;
            }

            this.xtcBrowser.SelectedTabPageIndex = index;
            this.DisposeTabPage(tp);
            this.xtcBrowser.TabPages.Remove(tp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tp"></param>
        private void DisposeTabPage(XtraTabPage tp)
        {
            if (tp != null)
            {
                PanelControl pc = tp.Controls[0] as PanelControl;
                if (pc != null)
                {
                    foreach (Control ctl in pc.Controls)
                    {
                        Recycling(ctl as ThreadControlContainer);
                        Recycling(ctl as TopicControlContainer);
                        Recycling(ctl as PostControlContainer);
                    }
                }

                tp.Controls.Clear();
                tp.Dispose();
            }
        }
        #endregion

        #region Event handler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void Global_KeyUp(object sender, KeyExEventArgs e)
        {
            string fwtpName = HookUtil.GetForegroundWindowThreadProcessName();
#if (X)
            System.Diagnostics.Debug.WriteLine("Global_KeyUp - " + fwtpName);
            System.Diagnostics.Debug.WriteLine("Global_KeyUp - " +
                                               "Control.ModifierKeys " + Control.ModifierKeys + "\t" +
                                               "Modifiers " + e.Modifiers + "\t" +
                                               "Alt " + e.Alt + "\t" +
                                               "Control " + e.Control + "\t" +
                                               "Shift " + e.Shift + "\t" +
                                               e.KeyCode + "\t" + e.KeyValue + "\t" + e.KeyData);
            System.Diagnostics.Debug.WriteLine("Global_KeyUp - this._entryAssemblyTitle = " + this._entryAssemblyTitle);
#endif
            if (fwtpName == this._entryAssemblyTitle)
            {
                if ((e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) &&
                     Control.ModifierKeys == Keys.Control
                     && (this.Active || Top10sForm.Instance.Active))
                {
                    ShowTop10s();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FavorForm_OnBoardLinkLableClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                TabbedBrowserForm.Instance.AddBoard(e.Link, TopicBrowserType.Subject, hlc.PlainText);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferFormInstance_OnReferClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddPost(e.Link, hlc.PlainText);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowFormOnCenterParent(LoginForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiTop10s_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowTop10s();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiBoards_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowFormOnCenterParent(BoardNavigatorForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiGo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowFormOnCenterParent(BoardQueryForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiPhotos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PictureBrowserControl pbc = new PictureBrowserControl();
            pbc.OnPictureTopicLinkClicked += PictureBrowserControl_OnPictureTopicLinkClicked;
            pbc.Dock = DockStyle.Fill;
            XtraTabPage xtp = new XtraTabPage();
            xtp.Text = "【照片合集】";
            xtp.Controls.Add(pbc);
            this.xtcBrowser.TabPages.Add(xtp);
            this.xtcBrowser.SelectedTabPage = xtp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBrowserControl_OnPictureTopicLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddTopic(e.Link, e.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowFormOnCenterParent(MessageCenterForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiFavors_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowFormOnCenterParent(FavorForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiMails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MailBoxForm.Instance.SetParent(this);
            this.ShowFormOnCenterParent(MailBoxForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiRefers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReferForm.Instance.OnReferClicked -= ReferFormInstance_OnReferClicked;
            ReferForm.Instance.OnReferClicked += ReferFormInstance_OnReferClicked;
            ReferForm.Instance.SetParent(this);
            this.ShowFormOnCenterParent(ReferForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowFormAsDialog(TabbedBrowserSettingsForm.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<XtraTabPage> list = new List<XtraTabPage>();
            foreach (XtraTabPage tp in this.xtcBrowser.TabPages)
            {
                list.Add(tp);
            }

            this.xtcBrowser.TabPages.Clear();
            foreach (XtraTabPage tp in list)
            {
                this.DisposeTabPage(tp);
            }

            GC.Collect();
            this.Text = Configuration.ApplicationTitle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbc"></param>
        private void Recycling(ThreadControlContainer tcc)
        {
            if (tcc != null)
            {
                tcc.OnThreadDeleteLinkClicked -= Common_OnThreadDeleteLinkClicked;
                tcc.OnThreadEditLinkClicked -= Common_OnThreadEditLinkClicked;
                tcc.OnThreadMailLinkClicked -= Common_OnThreadMailLinkClicked;
                tcc.OnThreadQueryTypeLinkClicked -= ThreadControlContainer_OnThreadQueryTypeLinkClicked;
                tcc.OnThreadReplyLinkClicked -= Common_OnThreadReplyLinkClicked;
                tcc.OnThreadTransferLinkClicked -= Common_OnThreadTransferLinkClicked;
                tcc.OnThreadUserLinkClicked -= Common_OnUserLinkClicked;
                tcc.OnTopicReplyLinkClicked -= ThreadControlContainer_OnTopicReplyLinkClicked;
                tcc.OnThreadContentLinkClicked -= Common_OnRichTextBoxContentLinkClicked;
                tcc.OnBoardLinkClicked -= ThreadControlContainer_OnBoardLinkClicked;
                tcc.OnWorkerFailed -= Common_OnWorkerFailed;
                tcc.OnWorkerCancelled -= Common_OnWorkerCancelled;
                tcc.OnTopicSettingsClicked -= ThreadControlContainer_OnTopicSettingsClicked;
                tcc.OnCaptionChanged -= ThreadControlContainer_OnCaptionChanged;
                RecycledQueues.AddRecycled<ThreadControlContainer>(tcc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbc"></param>
        private void Recycling(TopicControlContainer tcc)
        {
            if (tcc != null)
            {
                tcc.OnNewClicked -= Common_OnNewClicked;
                tcc.OnTopicLinkClicked -= TopicControlContainer_OnTopicLinkClicked;
                tcc.OnPostLinkClicked -= TopicControlContainer_OnPostLinkClicked;
                tcc.OnTopicCreateIDLinkClicked -= Common_OnUserLinkClicked;
                tcc.OnTopicLastIDLinkClicked -= Common_OnUserLinkClicked;
                tcc.OnWorkerFailed -= Common_OnWorkerFailed;
                tcc.OnWorkerCancelled -= Common_OnWorkerCancelled;
                tcc.OnBoardSettingsClicked -= TopicControlContainer_OnBoardSettingsClicked;
                tcc.OnCaptionChanged -= TopicControlContainer_OnCaptionChanged;
                RecycledQueues.AddRecycled<TopicControlContainer>(tcc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbc"></param>
        private void Recycling(PostControlContainer pcc)
        {
            if (pcc != null)
            {
                pcc.OnBoardClicked -= PostControlContainer_OnBoardClicked;
                pcc.OnContentLinkClicked -= Common_OnRichTextBoxContentLinkClicked;
                pcc.OnDeleteClicked -= Common_OnThreadDeleteLinkClicked;
                pcc.OnEditClicked -= Common_OnThreadEditLinkClicked;
                pcc.OnExpandClicked -= PostControlContainer_OnExpandClicked;
                pcc.OnMailClicked -= Common_OnThreadMailLinkClicked;
                pcc.OnNewClicked -= Common_OnNewClicked;
                pcc.OnReplyClicked -= Common_OnThreadReplyLinkClicked;
                pcc.OnSubjectExpandClicked -= PostControlContainer_OnSubjectExpandClicked;
                pcc.OnTransferClicked -= Common_OnThreadTransferLinkClicked;
                pcc.OnUserClicked -= Common_OnUserLinkClicked;
                pcc.OnWorkerCancelled -= Common_OnWorkerCancelled;
                pcc.OnWorkerFailed -= Common_OnWorkerFailed;
                pcc.OnCaptionChanged -= PostControlContainer_OnCaptionChanged;
                RecycledQueues.AddRecycled<PostControlContainer>(pcc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top10sForm_OnTopBoardLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddBoard(e.Link, TopicBrowserType.Subject, hlc.PlainText);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top10sForm_OnTopLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this.AddTopic(e.Link, hlc.PlainText);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_OnLogoutFailed(object sender, MessageEventArgs e)
        {
            LoginControl lc = sender as LoginControl;
            if (lc != null)
            {
                MessageForm form = new MessageForm("Logout Failed", e.Message);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_OnLoginFailed(object sender, MessageEventArgs e)
        {
            LoginControl lc = sender as LoginControl;
            if (lc != null)
            {
                MessageForm form = new MessageForm("Login Failed", e.Message);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNewInforTimer_Tick(object sender, EventArgs e)
        {
            if (LogStatus.Instance.IsLogin)
            {
                ///Check mail.
                {
                    PageLoader pl = new PageLoader(Configuration.InboxUrl);
                    pl.PageLoaded += CheckNewMail_PageLoaded;
                    PageDispatcher.Instance.Add(pl);
                }

                ///Check reply.
                {
                    PageLoader pl = new PageLoader(Configuration.ReplyUrl);
                    pl.PageLoaded += CheckNewReply_PageLoaded;
                    PageDispatcher.Instance.Add(pl);
                }

                ///Check at.
                {
                    PageLoader pl = new PageLoader(Configuration.AtUrl);
                    pl.PageLoaded += CheckNewAt_PageLoaded;
                    PageDispatcher.Instance.Add(pl);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNewMail_PageLoaded(object sender, EventArgs e)
        {
            PageLoader pl = sender as PageLoader;
            if (pl != null)
            {
                LogStatus.Instance.UpdateStatus(pl.GetResult() as WebPage);
                MailStatus.Instance.UpdateStatus(pl.GetResult() as WebPage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNewReply_PageLoaded(object sender, EventArgs e)
        {
            PageLoader pl = sender as PageLoader;
            if (pl != null)
            {
                LogStatus.Instance.UpdateStatus(pl.GetResult() as WebPage);
                ReplyStatus.Instance.UpdateStatus(pl.GetResult() as WebPage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNewAt_PageLoaded(object sender, EventArgs e)
        {
            PageLoader pl = sender as PageLoader;
            if (pl != null)
            {
                LogStatus.Instance.UpdateStatus(pl.GetResult() as WebPage);
                AtStatus.Instance.UpdateStatus(pl.GetResult() as WebPage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AtStatusInstance_OnNewArrived(object sender, AtStatusEventArgs e)
        {
            this.SetNewReferStatus(e.NewArrivedCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailStatusInstance_OnNewArrived(object sender, MailStatusEventArgs e)
        {
            this.SetNewMailStatus(e.NewArrivedCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplyStatusInstance_OnNewArrived(object sender, ReplyStatusEventArgs e)
        {
            this.SetNewReferStatus(e.NewArrivedCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogStatusInstance_OnLoginStatusChanged(object sender, LogStatusEventArgs e)
        {
            SetLogStatus(e.IsLogin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Configuration_OnNewMailUpdatingIntervalChanged(object sender, EventArgs e)
        {
            this._checkNewInforTimer.Stop();
            if (LogStatus.Instance.IsLogin)
            {
                this._checkNewInforTimer.Interval = Configuration.NewMailCheckingInterval;
                this._checkNewInforTimer.Stop();
            }
        }
        #endregion

        #region Common
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnUserLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                UserForm userForm = new UserForm(e.Link);
                userForm.StartPosition = FormStartPosition.CenterParent;
                userForm.ShowDialog(this);
            }
            else
            {
                DevExpress.XtraBars.BarManager bm = sender as DevExpress.XtraBars.BarManager;
                if (bm != null)
                {
                    UserForm userForm = new UserForm(e.Link);
                    userForm.StartPosition = FormStartPosition.CenterParent;
                    userForm.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnRichTextBoxContentLinkClicked(object sender, LinkClickedEventArgs e)
        {
            int index = e.LinkText.LastIndexOf("http:");
            if (index < 0)
            {
                index = e.LinkText.LastIndexOf("https:");
            }

            if (index > 0)
            {
                string url = e.LinkText.Substring(index);
                if (url.Contains(@"att.newsmth.net"))
                {
                    ShowFormOnCenterParent((new WebBrowserForm(url)));
                }
                else
                {
                    CommonUtil.OpenUrl(url);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnWorkerCancelled(object sender, MessageEventArgs e)
        {
            //MessageForm msgForm = new MessageForm("Geting page Cancelled", e.Message);
            //msgForm.StartPosition = FormStartPosition.CenterParent;
            //this.Activate();
            //msgForm.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnWorkerFailed(object sender, MessageEventArgs e)
        {
            //MessageForm msgForm = new MessageForm("Geting page failed", e.Message);
            //msgForm.StartPosition = FormStartPosition.CenterParent;
            //this.Activate();
            //msgForm.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnThreadMailLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null && hlc.Tag != null)
            {
                string replyContent = hlc.Tag.ToString();
                if (replyContent != null)
                {
                    NewMailForm mailForm = new NewMailForm(replyContent.Substring(0, replyContent.IndexOf("<User>")),
                                                           "Re: " + this.xtcBrowser.SelectedTabPage.Text,
                                                           replyContent.Substring(replyContent.IndexOf("<User>") + 6));
                    mailForm.StartPosition = FormStartPosition.CenterParent;
                    if (mailForm.ShowDialog(this) == DialogResult.OK)
                    {
                        hlc.Tag = mailForm.GetPostString();
                        //e.Link.Visited = true;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnThreadEditLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null && hlc.Tag != null)
            {
                string replyContent = hlc.Tag.ToString();
                hlc.Tag = null;
                if (replyContent != null)
                {
                    NewThreadForm threadForm = new NewThreadForm(this.xtcBrowser.SelectedTabPage.Text,
                                                                    "Re: " + this.xtcBrowser.SelectedTabPage.Text,
                                                                    replyContent,
                                                                    false);
                    threadForm.StartPosition = FormStartPosition.CenterParent;
                    if (DialogResult.OK == threadForm.ShowDialog(this))
                    {
                        hlc.Tag = threadForm.GetPostString();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnThreadDeleteLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                MessageForm confirmForm = new MessageForm("提示", "确认删除此信息？");
                confirmForm.StartPosition = FormStartPosition.CenterParent;
                DialogResult dlgResult = confirmForm.ShowDialog(this);
                if (dlgResult == DialogResult.OK)
                {
                    hlc.Tag = "Yes";
                    //e.Link.Visited = true;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnThreadTransferLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null)
            {
                this._transferForm.SetUrl(e.Link);
                this._transferForm.StartPosition = FormStartPosition.CenterParent;
                this._transferForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_OnThreadReplyLinkClicked(object sender, HyperlinkClickEventArgs e)
        {
            HyperlinkLabelControl hlc = sender as HyperlinkLabelControl;
            if (hlc != null && hlc.Tag != null)
            {
                string replyContent = hlc.Tag.ToString();
                hlc.Tag = null;
                if (replyContent != null)
                {
                    NewThreadForm threadForm = new NewThreadForm(this.xtcBrowser.SelectedTabPage.Text,
                                                                    "Re: " + this.xtcBrowser.SelectedTabPage.Text,
                                                                    replyContent,//SmthUtil.GetReplyContent(thread),
                                                                    true);
                    threadForm.StartPosition = FormStartPosition.CenterParent;
                    if (DialogResult.OK == threadForm.ShowDialog(this))
                    {
                        hlc.Tag = threadForm.GetPostString();
                    }
                }
            }
        }
        #endregion

        #region Private
        /// <summary>
        /// 
        /// </summary>
        private void SetLogStatus(bool flag)
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    System.Threading.Thread.Sleep(0);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.SetLogStatus(flag);
                    }));
                    System.Threading.Thread.Sleep(0);
                }
                else
                {
                    lock (this.bsiWelcome)
                    {
                        if (flag)
                        {
#if (X)
                            Nzl.Web.Util.CommonUtil.ShowMessage("this.linklblUserID.Links count:" + this.linklblUserID.Text);
#endif
                            string welcomeStr = "Welcome ";
                            this.bsiWelcome.Caption = welcomeStr + " <href=" + LogStatus.Instance.UserID + ">" + LogStatus.Instance.UserID + "</href>" + "!";
                            this.bsiWelcome.HyperlinkClick -= new HyperlinkClickEventHandler(Common_OnUserLinkClicked);
                            this.bsiWelcome.HyperlinkClick += new HyperlinkClickEventHandler(Common_OnUserLinkClicked);
                            this.bbiLogin.Caption = "Log Out";
                        }
                        else
                        {
                            this.bsiWelcome.Caption = "Welcome!";
                            this.bbiLogin.Caption = "Log In";
                        }

                        this._checkNewInforTimer.Stop();
                        if (flag)
                        {
                            this._checkNewInforTimer.Interval = Configuration.NewMailCheckingInterval;
                            this._checkNewInforTimer.Start();
                        }
                    }

                    this.bbiFavors.Visibility = flag ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    this.bbiMails.Visibility = flag ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    this.bbiRefers.Visibility = flag ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ToolTip _mailToolTip = new ToolTip();

        /// <summary>
        /// 
        /// </summary>
        private void SetNewMailStatus(object obj)
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    System.Threading.Thread.Sleep(0);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.SetNewMailStatus(obj);
                    }));
                    System.Threading.Thread.Sleep(0);
                }
                else
                {
                    lock (this.bbiMails)
                    {
                        int newMailCount = Convert.ToInt32(obj);
                        if (newMailCount > 0)
                        {
                            this.bbiMails.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
                            this.bbiMails.Caption = "New mail!";
                            //this._mailToolTip.ShowAlways = true;
                            //this._mailToolTip.SetToolTip(this.bbiMails, "You have " + newMailCount + " new mail" + (newMailCount == 1 ? "!" : "s!"));
                        }
                        else
                        {
                            this.bbiMails.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
                            this.bbiMails.Caption = "Mails";
                            ///this._mailToolTip.ShowAlways = false;
                            ///this._mailToolTip.SetToolTip(this.bbiMails, "You have no new mail!");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ToolTip _referToolTip = new ToolTip();

        /// <summary>
        /// 
        /// </summary>
        private void SetNewReferStatus(object obj)
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    System.Threading.Thread.Sleep(0);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.SetNewReferStatus(obj);
                    }));
                    System.Threading.Thread.Sleep(0);
                }
                else
                {
                    lock (this.bbiRefers)
                    {
                        int newCount = Convert.ToInt32(obj);
                        if (newCount > 0)
                        {
                            this.bbiRefers.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
                            this.bbiRefers.Caption = "New refer!";
                            ///this._referToolTip.ShowAlways = true;
                            ///this._referToolTip.SetToolTip(this.bbiRefers, "You have " + newCount + " new refer" + (newCount == 1 ? "!" : "s!"));
                        }
                        else
                        {
                            this.bbiRefers.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
                            this.bbiRefers.Caption = "Refers";
                            ///this._referToolTip.ShowAlways = false;
                            ///this._referToolTip.SetToolTip(this.bbiRefers, "You have no new refer!");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowTop10s()
        {
            Form form = Top10sForm.Instance;
            if (form != null && form.IsDisposed == false)
            {
                form.StartPosition = FormStartPosition.Manual;
                int centerX = this.Location.X + this.Size.Width / 2;
                int centerY = this.Location.Y + this.Size.Height / 2;
                form.Location = new System.Drawing.Point(centerX - form.Size.Width / 2, centerY - form.Size.Height / 2);
                form.Visible = !form.Visible;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetEntryAssemblyTitle()
        {
            object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetXtraTabPageName(string url)
        {
            return "tp" + url;
        }
        #endregion
    }
}
