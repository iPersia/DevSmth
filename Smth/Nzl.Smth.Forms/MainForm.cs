namespace Nzl.Smth.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.ComponentModel;
    using DevExpress.XtraSplashScreen;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Logger;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Controls.Base;
    using Nzl.Smth.Controls.Elements;
    using Nzl.Smth.Controls.Complexes;
    using Nzl.Smth.Controls.Containers;
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

            SplashScreenManager.ShowForm(typeof(SplashScreenForm));

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ///
            SplashScreenManager.CloseForm();

            ///Load board's infor.
            //Boards.Instance.Initilize();

            TabbedBrowserForm.Instance.SetParent(this);
            TabbedBrowserForm.Instance.StartPosition = FormStartPosition.CenterScreen;
            TabbedBrowserForm.Instance.Show();
            TabbedBrowserForm.Instance.Activate();
            TabbedBrowserForm.Instance.Focus();
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
                this.AddControls(this.GetInitializingControls());
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
                list.Add(new TopControlContainer("1"));
                list.Add(new TopControl());
                list.Add(new ThreadControl());
                list.Add(new ThreadControlContainer());
                list.Add(new ThreadControl());
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

            e.Cancel = MessageBox.Show(this,
                                      "There exists some window active, do you want close the form?",
                                      "Warning",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes;

            if (e.Cancel == true)
            {
                return;
            }

            try
            {
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
