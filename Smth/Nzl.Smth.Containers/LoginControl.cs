﻿namespace Nzl.Smth.Containers
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;
    using Nzl.Smth.Common;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Smth.Logger;
    using Nzl.Web.Page;
    using Nzl.Web.Util;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="flag"></param>
    /// <returns></returns>
    delegate void SetControlEnabledCallback(bool flag);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    delegate void LogPageLoadedCallback(object sender, EventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class LoginControl : UserControl
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnLoginCompleted;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnLogoutCompleted;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> OnLoginFailed;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> OnLogoutFailed;
        #endregion

        #region variable
        /// <summary>
        /// 
        /// </summary>
        private string _filename = "userinfor.dat";
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public LoginControl()
        {
            InitializeComponent();
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
            this.txtUserID.Left = this.panelContainer.Width / 2 - this.txtUserID.Width / 2;
            this.txtPassword.Left = this.panelContainer.Width / 2 - this.txtPassword.Width / 2;
            this.ckbAutoLogon.Left = this.panelContainer.Width / 2 - this.ckbAutoLogon.Width / 2;
            this.btnLogon.Left = this.panelContainer.Width / 2 - this.btnLogon.Width / 2;
            this.btnLogout.Left = this.panelUp.Width / 2 - this.btnLogout.Width / 2;
            this.lblNote.Left = this.panelUp.Width / 2 - this.lblNote.Width / 2;            

            TextBoxUtil.SetWatermark(this.txtUserID, "Input username...");
            TextBoxUtil.SetWatermark(this.txtPassword, "Input password...");

            DeserializeUserInfor();
        }
        #endregion

        #region event handler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserID.Text) == false && string.IsNullOrEmpty(this.txtPassword.Text) == false)
            {
                this.Enabled = false;
                WebPage.RemoveCookie(Configurations.BaseUrl);
                LogIn(this.txtUserID.Text, this.txtPassword.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            WebPage.RemoveCookie(Configurations.BaseUrl);
            LogOut();
        }        
        #endregion

        #region Login & LogOut
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        private void LogIn(string userID, string password)
        {
            PageLoader pl = new PageLoader(Configurations.BaseUrl, Configurations.LoginUrl, @"id=" + userID + "&passwd=" + password + "&save=on");
            pl.PageLoaded += new EventHandler(Login_PageLoaded);
            PageDispatcher.Instance.Add(pl);
            this.SetControlEnabled(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LogOut()
        {
            PageLoader pl = new PageLoader(Configurations.LogoutUrl);
            pl.PageLoaded += new EventHandler(Logout_PageLoaded);
            PageDispatcher.Instance.Add(pl);
            this.SetControlEnabled(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_PageLoaded(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    System.Threading.Thread.Sleep(0);
                    this.Invoke(new LogPageLoadedCallback(Login_PageLoaded), new object[] { sender, e });
                    System.Threading.Thread.Sleep(0);
                }
                else
                {
                    PageLoader pl = sender as PageLoader;
                    if (pl != null)
                    {
                        WebPage wp = pl.GetPage();
                        if (wp != null && wp.IsGood)
                        {
                            LogStatus.Instance.UpdateLoginStatus(wp);
                            if (LogStatus.Instance.IsLogin)
                            {
                                if (this.ckbAutoLogon.Checked)
                                {
                                    SerializeUserInfor();
                                }

                                if (this.OnLoginCompleted != null)
                                {
                                    this.OnLoginCompleted(this, new EventArgs());
                                }
                            }
                            else
                            {
                                if (this.OnLoginFailed != null)
                                {
                                    this.OnLoginFailed(this, new MessageEventArgs(CommonUtil.GetMatch(@"<div class=\Wsp hl f\W>(?'Information'[^<]+)</div>", wp.Html, "Information")));
                                }
                            }
                        }
                    }
                }
            }

            this.SetControlEnabled(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_PageLoaded(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    System.Threading.Thread.Sleep(0);
                    this.Invoke(new LogPageLoadedCallback(Logout_PageLoaded), new object[] { sender, e });
                    System.Threading.Thread.Sleep(0);
                }
                else
                {
                    PageLoader pl = sender as PageLoader;
                    if (pl != null)
                    {
                        WebPage wp = pl.GetPage();
                        if (wp != null && wp.IsGood)
                        {
                            LogStatus.Instance.UpdateLoginStatus(wp);
                            if (LogStatus.Instance.IsLogin == false)
                            {
                                if (this.OnLogoutCompleted != null)
                                {
                                    this.OnLogoutCompleted(this, new EventArgs());
                                }
                            }
                            else
                            {
                                if (this.OnLogoutFailed != null)
                                {
                                    this.OnLogoutFailed(this, new MessageEventArgs(CommonUtil.GetMatch(@"<div class=\Wsp hl f\W>(?'Information'[^<]+)</div>", wp.Html, "Information")));
                                }
                            }
                        }
                    }
                }
            }

            this.SetControlEnabled(true);
        }   
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void SetControlEnabled(bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetControlEnabledCallback(SetControlEnabled), new object[] { flag });
            }
            else
            {
                this.Enabled = flag;
            }
        }
        #endregion

        #region Serialize
        /// <summary>
        /// 
        /// </summary>
        private void SerializeUserInfor()
        {
            try
            {
                UserInformation ui = new UserInformation();
                ui.UserName = Nzl.Util.EncryptUtil.Encrypt(this.txtUserID.Text, this._filename);
                ui.Password = Nzl.Util.EncryptUtil.Encrypt(this.txtPassword.Text, this._filename);
                byte[] datas = BufferHelper.Serialize(ui);
                byte[] eDatas = Nzl.Util.EncryptUtil.Encrypt(datas, System.Text.Encoding.Default.GetBytes(this._filename));
                Stream fStream = new FileStream(this._filename, FileMode.Create, FileAccess.ReadWrite);
                fStream.Write(eDatas, 0, eDatas.Length);
                fStream.Close();
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }
#if (DEBUG)
                Nzl.Web.Util.CommonUtil.ShowMessage(exp.Message);
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeserializeUserInfor()
        {
            try
            {
                if (File.Exists(this._filename))
                {
                    Stream fStream = new FileStream(this._filename, FileMode.Open, FileAccess.ReadWrite);
                    if (fStream != null && fStream.Length > 0)
                    {
                        byte[] edatas = new byte[fStream.Length];
                        fStream.Read(edatas, 0, (int)fStream.Length);
                        byte[] datas = Nzl.Util.EncryptUtil.Decrypt(edatas, System.Text.Encoding.Default.GetBytes(this._filename));
                        UserInformation ui = (UserInformation)BufferHelper.Deserialize(datas, 0);
                        if (ui != null)
                        {
                            this.txtUserID.Text = Nzl.Util.EncryptUtil.Decrypt(ui.UserName, this._filename);
                            this.txtPassword.Text = Nzl.Util.EncryptUtil.Decrypt(ui.Password, this._filename);
                        }
                    }

                    fStream.Close();
                }
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }
#if (DEBUG)
                Nzl.Web.Util.CommonUtil.ShowMessage(exp.Message);
#endif
            }
        }
        #endregion

        #region Serialize helper.
        /// <summary>
        /// 
        /// </summary>
        private class BufferHelper
        {
            public static byte[] Serialize(object obj)
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                bf.Serialize(stream, obj);
                byte[] datas = stream.ToArray();
                stream.Dispose();
                return datas;
            }

            public static object Deserialize(byte[] datas, int index)
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(datas, index, datas.Length - index);
                object obj = bf.Deserialize(stream);
                stream.Dispose();
                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        private class UserInformation
        {
            /// <summary>
            /// 
            /// </summary>
            private string _userID;

            /// <summary>
            /// 
            /// </summary>
            private string _password;

            /// <summary>
            /// 
            /// </summary>
            public string UserName
            {
                get
                {
                    return this._userID;
                }
                set
                {
                    this._userID = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string Password
            {
                get
                {
                    return this._password;
                }

                set
                {
                    this._password = value;
                }
            }
        }
        #endregion
    }
}
