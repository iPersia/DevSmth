﻿namespace Nzl.Smth.Forms
{
    using System;
    using System.Windows.Forms;
    using Nzl.Smth;

    /// <summary>
    /// 
    /// </summary>
    public partial class TopicSettingsForm : BaseForm
    {
        #region variable
        /// <summary>
        /// 
        /// </summary>
        private TopicSettingEventArgs _topicSetting = new TopicSettingEventArgs();
        #endregion

        #region Ctor.
        /// <summary>
        /// 
        /// </summary>
        public TopicSettingsForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;
            this.btnOK.Left = (this.panelContainer.Width - this.btnOK.Width) / 2;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public TopicSettingEventArgs Settings
        {
            get
            {
                return _topicSetting;
            }
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.rbLatestReply.Checked = this.Settings.BrowserType == ThreadBrowserType.LastReply;
            this.rbFirstReply.Checked = this.Settings.BrowserType == ThreadBrowserType.FirstReply;
            this.ckbAutoUpdating.Checked = this.Settings.AutoUpdating;
            this.cmbInterval.Text = this.Settings.UpdatingInterval.ToString();
            this.gpAutoUpdating.Enabled = this.rbLatestReply.Checked;
        }
        #endregion

        #region eventhandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this._topicSetting.AutoUpdating = this.ckbAutoUpdating.Checked;
            this._topicSetting.BrowserType = this.rbLatestReply.Checked ? ThreadBrowserType.LastReply : ThreadBrowserType.FirstReply;
            this._topicSetting.UpdatingInterval = Convert.ToInt32(this.cmbInterval.Text);
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbLatestReply_CheckedChanged(object sender, EventArgs e)
        {
            this.gpAutoUpdating.Enabled = this.rbLatestReply.Checked;
        }
        #endregion
    }
}
