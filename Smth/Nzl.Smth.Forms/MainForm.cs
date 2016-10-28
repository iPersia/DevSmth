namespace Nzl.Smth.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using DevExpress.XtraSplashScreen;
    using Nzl.Smth.Configs;    
    using Nzl.Smth.Datas;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Controls.Complexes;
    using Nzl.Smth.Controls.Containers;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;
    using DevExpress.XtraRichEdit;

    public partial class MainForm : BaseForm
    {
        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private string _closeFlag = null;
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ///
            SplashScreenManager.ShowForm(typeof(SplashScreenForm));

            ///DevExpress default setting.
            SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "default application settings");
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("宋体", 9);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");//使用DEV汉化资源文件
                                                                                                                    //设置程序区域语言设置中日期格式
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("zh-CHS");
            System.Globalization.DateTimeFormatInfo di = (System.Globalization.DateTimeFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.Clone();
            di.DateSeparator = "-";
            di.ShortDatePattern = "yyyy-MM-dd";
            di.LongDatePattern = "yyyy'年'M'月'd'日'";
            di.ShortTimePattern = "H:mm:ss";
            di.LongTimePattern = "H'时'mm'分'ss'秒'";
            ci.DateTimeFormat = di;
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;

            ///
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initializing()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.Initializing();
                }));
            }
            else
            {
                /////Loading the board components
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "board navigator");
                //BoardNavigatorForm.Instance.Validate();

                /////Loading the favor components
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "favor components");
                //FavorForm.Instance.CreateControl();

                /////Loading the login components
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "login components");
                //LoginForm.Instance.CreateControl();

                /////Loading the mailbox components
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "mailbox components");
                //MailBoxForm.Instance.CreateControl();

                /////Loading the refer components
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "refer components");
                //ReferForm.Instance.CreateControl();

                ///Loading the main browser
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "main browser");
                //TabbedBrowserForm.Instance.CreateControl();

                /////Loading the settings components
                //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "settings components");
                //TabbedBrowserSettingsForm.Instance.CreateControl();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /// Loading the main browser
            SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "main browser");
            System.Threading.Thread.Sleep(0);
            TabbedBrowserForm.Instance.CreateControl();
            System.Threading.Thread.Sleep(0);

            ///Loading the settings components
            SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "settings components");
            System.Threading.Thread.Sleep(0);
            TabbedBrowserSettingsForm.Instance.CreateControl();
            System.Threading.Thread.Sleep(0);

            /////Loading the photo components
            //SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, "photo components");
            //System.Threading.Thread.Sleep(0);
            //int count = PictureTopicLoader.Instance.PictureTopics.Count;
            //System.Threading.Thread.Sleep(0);

            ///Initializing is completed.
            SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loaded, null);
            System.Threading.Thread.Sleep(1000);

            ///Load board's infor.
            //Boards.Instance.Initilize();

            TabbedBrowserForm.Instance.SetParent(this);
            TabbedBrowserForm.Instance.StartPosition = FormStartPosition.CenterScreen;
            TabbedBrowserForm.Instance.Show();
            TabbedBrowserForm.Instance.Activate();
            TabbedBrowserForm.Instance.Focus();

            ///Close the splash screen.
            SplashScreenManager.CloseForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ///Initializing the controls.
                this.AddControls(this.GetInitializingControls());

                ///Initializing the forms.
                this.Initializing();

                ///Load the photos.
                //int x = Nzl.Smth.Loaders.PictureTopicLoader.Instance.PictureTopics.Count;
            }
            catch
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Control> GetInitializingControls()
        {
            if (this.InvokeRequired)
            {
                IList<Control> list = null;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    list = this.GetInitializingControls();
                }));
                return list;
            }
            else
            {
                IList<Control> list = new List<Control>();
                list.Add(new AtControl());
                list.Add(new AtControlContainer());
                list.Add(new BoardControl());
                list.Add(new BoardControlContainer());
                list.Add(new MailControl());
                list.Add(new MailControlContainer(MailBoxType.Inbox));
                list.Add(new MailDetailControl());
                list.Add(new MailDetailControlContainer());
                list.Add(new PostControl());
                list.Add(new PostControlContainer());
                list.Add(new ReplyControl());
                list.Add(new ReplyControlContainer());
                list.Add(new SectionControl());
                list.Add(new SectionControlContainer());
                list.Add(new ThreadControl());
                list.Add(new ThreadControlContainer());
                list.Add(new TopControl());
                list.Add(new TopControlContainer("http://m.newsmth.net/hot"));
                list.Add(new TopicControl());
                list.Add(new TopicControlContainer());
                return list;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        private void AddControls(IList<Control> ctls)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.AddControls(ctls);
                }));
            }
            else
            {
                foreach (Control ctl in ctls)
                {
                    SplashScreenManager.Default.SendCommand(SplashScreenForm.SplashScreenCommand.Loading, ctl.ToString());
                    System.Threading.Thread.Sleep(0);
                    this.Controls.Add(ctl);
                    ctl.CreateControl();
                    if (ctl is ThreadControl)
                    {
                        Thread thread = new Thread();
                        thread.DeleteUrl = "DeleteUrl";
                        thread.Floor = "1";
                        thread.User = "User";
                        thread.ContentHtml = "<form action=\"/user/login\" method=\"post\"><ul class=\"sec slist\"><li class=\"f\">当前用户:Nesus</li><li>等级:用户</li><li>发帖数:1433</li></ul></form><ul class=\"slist sec\"><li class=\"f\">十大热门话题</li><li>1|<a href=\"/article/Age/16604805\">(更新)遇到咖啡托儿，被其同伙揍差点屎了，刚刚才录完口供(<span style=\"color:red\">272</span>)</a></li><li>2|<a href=\"/article/OurEstate/1893295\">女方死活不同意离婚规避怎么办(<span style=\"color:red\">144</span>)</a></li><li>3|<a href=\"/article/FamilyLife/1758620823\">婆婆说“你们的孩子应该你们养，不要指望我来带”，请教将来养(<span style=\"color:red\">126</span>)</a></li><li>4|<a href=\"/article/RealEstate/5477605\">简单解读一下9.30新政，纠正一下错误认识(<span style=\"color:red\">102</span>)</a></li><li>5|<a href=\"/article/Picture/1421968\">浙江大学打造全球最大，最豪华大学校门！！！(<span style=\"color:red\">99</span>)</a></li><li>6|<a href=\"/article/ShangHaiEstate/135154\">上海户口重要吗？(<span style=\"color:red\">78</span>)</a></li><li>7|<a href=\"/article/Love/6059199\">女友和ex发生过关系(<span style=\"color:red\">77</span>)</a></li><li>8|<a href=\"/article/AutoWorld/1940353861\">汉兰达跑长途太舒服了(<span style=\"color:red\">61</span>)</a></li><li>9|<a href=\"/article/Stock/6723683\">人民日报今天又对房价又说话了。(<span style=\"color:red\">58</span>)</a></li><li>10|<a href=\"/article/Sichuan/577271\">粗大事了(<span style=\"color:red\">47</span>)</a></li></ul>	<div class=\"sec sp\"><form action=\"/go\" method=\"get\"><span class=\"f\">选择讨论区</span><br><input name=\"name\" type=\"text\">&nbsp;<input value=\"GO\" class=\"btn\" type=\"submit\"></form></div>";
                        (ctl as ThreadControl).Initialize(thread);
                    }
                }
            }
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

            ///Hide the main form.
            this.Hide();
            this.ShowInTaskbar = false;
            this.nfiMain.Visible = true;

            ///Should excute before loading of TabbedBrowserForm.Instance.
            TabbedBrowserSettingsForm.Instance.LoadSettings();

            ///Set the skin.
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Configuration.SkinName);
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._closeFlag != "NotifyIcon")
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
                this.nfiMain.Visible = true;
                return;
            }

            MessageForm form = new MessageForm("Warning", "There exists some window active, do you want close the form?");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.TopMost = true;
            e.Cancel = form.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel;

            if (e.Cancel)
            {
                return;
            }

            try
            {
                Nzl.Smth.Controls.Base.InformationCenter.ThreadStop();

                TabbedBrowserForm.Instance.Hide();
                TabbedBrowserForm.Instance.Clear();
                TabbedBrowserForm.Instance.Dispose();
                GC.Collect();

                LoginForm.Instance.Hide();
                LoginForm.Instance.Dispose();
                GC.Collect();

                Top10sForm.Instance.Hide();
                Top10sForm.Instance.Dispose();
                GC.Collect();

                BoardNavigatorForm.Instance.Hide();
                BoardNavigatorForm.Instance.Dispose();
                GC.Collect();

                MessageCenterForm.Instance.Hide();
                MessageCenterForm.Instance.Dispose();
                GC.Collect();

                MailBoxForm.Instance.Hide();
                MailBoxForm.Instance.Dispose();
                GC.Collect();

                FavorForm.Instance.Hide();
                FavorForm.Instance.Dispose();
                GC.Collect();
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nfiMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabbedBrowserForm.Instance.Visible = !TabbedBrowserForm.Instance.Visible;
            if (TabbedBrowserForm.Instance.Visible)
            {
                TabbedBrowserForm.Instance.Show();
                TabbedBrowserForm.Instance.Activate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this._closeFlag = "NotifyIcon";
            this.Close();
        }
        #endregion        
    }
}
