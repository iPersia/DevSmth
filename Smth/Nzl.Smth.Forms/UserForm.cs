namespace Nzl.Smth.Forms
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Nzl.Smth;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;
    using Nzl.Web.Util;
    using Nzl.Web.Page;

    /// <summary>
    /// 
    /// </summary>
    public partial class UserForm : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        private string _userID;

        /// <summary>
        /// 
        /// </summary>
        public UserForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;

            ///
            this.btnSendMail.Left = (this.panelMenu.Width - this.btnSendMail.Width) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public UserForm(string userID)
            : this()
        {
            this._userID = userID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Text = "Query User - " + this._userID;
            LoadUserInfor();
            this.btnSendMail.Enabled = LogStatus.Instance.IsLogin;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadUserInfor()
        {
            if (string.IsNullOrEmpty(this._userID))
            {
                this.txtUser.Document.AppendText("\n\t没有指定用户ID！");
                return;
            }

            this.bgwFetchPage.DoWork += BgwFetchPage_DoWork;
            this.bgwFetchPage.RunWorkerCompleted += BgwFetchPage_RunWorkerCompleted;
            this.bgwFetchPage.RunWorkerAsync(this._userID);            
        }

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticNewlineRegex = new Regex(@"[\n]", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticHtmlRegex = new Regex("(<[^>]+?>)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwFetchPage_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                WebPage userInforPage = e.Result as WebPage;
                if (userInforPage != null && userInforPage.IsGood)
                {
                    string userInfor = CommonUtil.GetMatch(@"<li>[\w, \W]+</li>", userInforPage.Html);
                    if (string.IsNullOrEmpty(userInfor) == false)
                    {
                        userInfor = userInfor.Replace(@"<li>", "\t");
                        userInfor = _staticNewlineRegex.Replace(userInfor, "");
                        userInfor = userInfor.Replace(@"</li>", "\n\n");
                        userInfor = _staticHtmlRegex.Replace(userInfor, "");
                        userInfor = CommonUtil.ReplaceSpecialChars(userInfor);
                        userInfor.TrimEnd('\n');
                        this.txtUser.Document.AppendText("\n");
                        this.txtUser.Document.AppendText(userInfor);
                        return;
                    }
                }

                this.txtUser.Document.AppendText("\n\t没有查询到用户'" + this._userID + "'的信息！");
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }

                this.txtUser.Document.AppendText("\n\t没有查询到用户'" + this._userID + "'的信息！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwFetchPage_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                e.Result = WebPageFactory.CreateWebPage("http://m.newsmth.net/user/query/" + e.Argument.ToString());
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }

                e.Result = null;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            NewMailForm newMailForm = new NewMailForm(this._userID);
            newMailForm.StartPosition = FormStartPosition.CenterParent;
            if (newMailForm.ShowDialog(this) == DialogResult.OK)
            {
                PostLoader pl = new PostLoader(Configuration.SendMailUrl, newMailForm.GetPostString());
                pl.ErrorAccured += PostLoader_ErrorAccured;
                pl.Succeeded += NewMail_Succeeded;
                pl.Failed += NewMail_Failed;
                pl.Start();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.txtUser.Height + (this.Height - this.panelContainer.Height) + this.txtUser.Top * 2;
        }

        #region NewMail - PageLoaded & PageFailed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostLoader_ErrorAccured(object sender, MessageEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () {
                    this.NewMail_Succeeded(sender, e);
                }));
            }
            else
            {
                if (this.Visible)
                {
                    MessageForm form = new MessageForm("Information", e.Message);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMail_Succeeded(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () {
                    this.NewMail_Succeeded(sender, e);
                }));
            }
            else
            {
                if (this.Visible)
                {
                    MessageForm form = new MessageForm("Information", "Sending mail is completed!");
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMail_Failed(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.NewMail_Failed(sender, e);
                }));
            }
            else
            {
                if (this.Visible)
                {
                    MessageForm form = new MessageForm("Information", "Sending mail failed!");
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog(this);
                }
            }
        }
        #endregion        
    }
}
