namespace Nzl.Smth.Forms
{
    using System;
    using System.Net;
    using System.Windows.Forms;
    using System.Xml;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Updating;
    using DevExpress.XtraBars.Helpers;

    /// <summary>
    /// 
    /// </summary>
    public partial class TabbedBrowserSettingsForm : BaseForm
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly TabbedBrowserSettingsForm Instance = new TabbedBrowserSettingsForm();
        #endregion

        #region variable
        #endregion

        /// <summary>
        /// 
        /// </summary>
        TabbedBrowserSettingsForm()
        {
            InitializeComponent();
            this.HideWhenDeactivate = false;
            this.btnOK.Left = (this.panelContainer.Width - this.btnOK.Width) / 2;
            SkinHelper.InitSkinGallery(gcSkins, true);

            ///
            this.galleryControlClient1.Gallery.ItemClick += Gallery_ItemClick;

            ///
            this.panelMenu.SizeChanged += PanelMenu_SizeChanged;
        }

        private void PanelMenu_SizeChanged(object sender, EventArgs e)
        {
            if (this.panelMenu.Height != 36)
            {
                int dHeight = 36 - this.panelMenu.Height;
                this.panelXtc.Height = this.panelXtc.Height - dHeight;
                this.btnOK.Top = (this.panelMenu.Height - this.btnOK.Height) / 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.cmbNewMailCheckingInterval.Text = (Configuration.NewMailCheckingInterval / 1000).ToString();
            this.cmbSectionTopUpdatingInterval.Text = (Configuration.SectionTopsUpdatingInterval / 1000).ToString();
            this.cmbTop10sLoadingInterval.Text = (Configuration.Top10sLoadingInterval / 1000).ToString();
            this.ckbShowIPinTopic.Checked = Configuration.ShowIPinTopic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ///Set NewMailCheckingInterval
            if (string.IsNullOrEmpty(this.cmbNewMailCheckingInterval.Text) == false)
            {
                Configuration.SetNewMailCheckingInterval(Convert.ToInt32(this.cmbNewMailCheckingInterval.Text) * 1000);
            }

            ///Set SectionTopUpdatingInterval
            if (string.IsNullOrEmpty(this.cmbSectionTopUpdatingInterval.Text) == false)
            {
                Configuration.SetSectionTopsUpdatingInterval(Convert.ToInt32(this.cmbSectionTopUpdatingInterval.Text) * 1000);
            }

            ///Set Top10sLoadingInterval
            if (string.IsNullOrEmpty(this.cmbTop10sLoadingInterval.Text) == false)
            {
                Configuration.SetTop10sLoadingInterval(Convert.ToInt32(this.cmbTop10sLoadingInterval.Text) * 1000);
            }

            ///Set ShowIPinTopic
            Configuration.SetShowIPinTopic(this.ckbShowIPinTopic.Checked);

            ///Save settings to app.config file.
            this.SaveSettings();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckNewVersion_Click(object sender, EventArgs e)
        {
            CheckUpdateForm form = new CheckUpdateForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        #region private
        /// <summary>
        /// 
        /// </summary>
        public void LoadSettings()
        {
            System.Configuration.Configuration cfg = 
              System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            if (cfg != null)
            {
                if (cfg.AppSettings.Settings["SectionTopsUpdatingInterval"] != null &&
                    cfg.AppSettings.Settings["SectionTopsUpdatingInterval"].Value != null)
                {
                    try
                    {
                        Configuration.SetSectionTopsUpdatingInterval(1000 * Convert.ToInt32(cfg.AppSettings.Settings["SectionTopsUpdatingInterval"].Value));
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["Top10sLoadingInterval"] != null &&
                    cfg.AppSettings.Settings["Top10sLoadingInterval"].Value != null)
                {
                    try
                    {
                        Configuration.SetTop10sLoadingInterval(1000 * Convert.ToInt32(cfg.AppSettings.Settings["Top10sLoadingInterval"].Value));
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["NewMailCheckingInterval"] != null &&
                    cfg.AppSettings.Settings["NewMailCheckingInterval"].Value != null)
                {
                    try
                    {
                        Configuration.SetNewMailCheckingInterval(1000 * Convert.ToInt32(cfg.AppSettings.Settings["NewMailCheckingInterval"].Value));
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["BaseControlContainerLocationMargin"] != null &&
                    cfg.AppSettings.Settings["BaseControlContainerLocationMargin"].Value != null &&
                    cfg.AppSettings.Settings["BaseControlLocationMargin"] != null &&
                    cfg.AppSettings.Settings["BaseControlLocationMargin"].Value != null)
                {
                    try
                    {
                        Configuration.SetLocationMargin(Convert.ToInt32(cfg.AppSettings.Settings["BaseControlContainerLocationMargin"].Value),
                                                        Convert.ToInt32(cfg.AppSettings.Settings["BaseControlLocationMargin"].Value));


                        this.cmbBaseControlContainerLocationMargin.Text = cfg.AppSettings.Settings["BaseControlContainerLocationMargin"].Value;
                        this.cmbBaseControlLocationMargin.Text = cfg.AppSettings.Settings["BaseControlLocationMargin"].Value;
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["SkinName"] != null &&
                   cfg.AppSettings.Settings["SkinName"].Value != null)
                {
                    try
                    {
                        Configuration.SetSkinName(cfg.AppSettings.Settings["SkinName"].Value);
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["UpdatingXmlUrl"] != null &&
                    cfg.AppSettings.Settings["UpdatingXmlUrl"].Value != null)
                {
                    try
                    {
                        Configuration.SetUpdatingXmlUrl(cfg.AppSettings.Settings["UpdatingXmlUrl"].Value);
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["ShowIPinTopic"] != null &&
                    cfg.AppSettings.Settings["ShowIPinTopic"].Value != null)
                {
                    try
                    {
                        Configuration.SetShowIPinTopic(cfg.AppSettings.Settings["ShowIPinTopic"].Value.ToString() == "Yes");
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveSettings()
        {
            System.Configuration.Configuration cfg = 
                System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            if (cfg != null)
            {
                if (cfg.AppSettings.Settings["SectionTopsUpdatingInterval"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["SectionTopsUpdatingInterval"].Value =
                            (Configuration.SectionTopsUpdatingInterval / 1000).ToString();
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["Top10sLoadingInterval"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["Top10sLoadingInterval"].Value =
                            (Configuration.Top10sLoadingInterval / 1000).ToString();
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["NewMailCheckingInterval"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["NewMailCheckingInterval"].Value =
                            (Configuration.NewMailCheckingInterval / 1000).ToString();
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["BaseControlContainerLocationMargin"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["BaseControlContainerLocationMargin"].Value = 
                            this.cmbBaseControlContainerLocationMargin.Text;
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["BaseControlLocationMargin"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["BaseControlLocationMargin"].Value =
                            this.cmbBaseControlLocationMargin.Text;
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["ShowIPinTopic"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["ShowIPinTopic"].Value = 
                            this.ckbShowIPinTopic.Checked ? "Yes" : "No";
                    }
                    catch { }
                }

                cfg.Save();
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCache_Click(object sender, EventArgs e)
        {
            Nzl.Repository.Repository.Clear();
            Nzl.Smth.Loaders.PageDispatcher.Instance.Reset();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            System.Configuration.Configuration cfg =
                System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            if (cfg != null)
            {
                if (cfg.AppSettings.Settings["SkinName"] != null)
                {
                    try
                    {
                        cfg.AppSettings.Settings["SkinName"].Value = e.Item.Caption;
                    }
                    catch { }
                }

                cfg.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelControl3_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link);
        }

        private void rbLatestReply_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}