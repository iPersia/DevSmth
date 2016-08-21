﻿namespace Nzl.Smth.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nzl.Web.Page;
    using Nzl.Smth.Utils;

    /// <summary>
    /// 
    /// </summary>
    public class LogStatus
    {
        #region Sington
        /// <summary>
        /// 
        /// </summary>
        public static readonly LogStatus Instance = new LogStatus();
        #endregion

        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LogStatusEventArgs> LoginStatusChanged;
        #endregion

        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private bool _isLogin = false;

        /// <summary>
        /// 
        /// </summary>
        private string _userID = "NOT LOGIN";

        /// <summary>
        /// 
        /// </summary>
        private object _isLoginLocker = new object();
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        LogStatus()
        {
        }
        #endregion

        #region Get login status
        /// <summary>
        /// 
        /// </summary>
        public bool IsLogin
        {
            get
            {
                lock (this._isLoginLocker)
                {
                    return this._isLogin;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            get
            {
                lock (this._userID)
                {
                    return this._userID;
                }
            }
        }
        #endregion

        #region Updating login status
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public void UpdateLoginStatus(WebPage page)
        {
            this.UpdateLoginStatus(page != null ? page.Html : "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public void UpdateLoginStatus(string html)
        {
            lock (_isLoginLocker)
            {
                bool srcLogStatus = this._isLogin;
                this._isLogin = SmthUtil.GetLogInStatus(html);
                if (this._isLogin)
                {
                    this._userID = SmthUtil.GetLogInUserID(html);
                }

                if (srcLogStatus != this._isLogin)
                {
                    this.OnLoginStatusChanged(_isLogin);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogin"></param>
        protected void OnLoginStatusChanged(bool isLogin)
        {
            if (this.LoginStatusChanged != null)
            {
                LogStatusEventArgs e = new LogStatusEventArgs();
                e.IsLogin = isLogin;
                this.LoginStatusChanged(this, e);
            }
        }
        #endregion
    }
}
