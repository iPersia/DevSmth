namespace Nzl.Smth.Updating
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public partial class CheckUpdateForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 
        /// </summary>
        private WebClient clientDownload = null;

        /// <summary>
        /// 
        /// </summary>
        private string _updateXmlUrl = null;

        /// <summary>
        /// 
        /// </summary>
        private ManualResetEvent evtDownload = null;

        /// <summary>
        /// 
        /// </summary>
        private string _updatingDirectory = "Updating";

        /// <summary>
        /// 
        /// </summary>
        private UpdateInfor _updateInfor = null;

        /// <summary>
        /// 
        /// </summary>
        private string _currentVersion = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public CheckUpdateForm()
        {
            InitializeComponent();

            ///
            this.richtxtReleaseNote.PopupMenuShowing += RichtxtContent_PopupMenuShowing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            /// Load UpdatingXmlUrl.
            System.Configuration.Configuration cfg =
              System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            if (cfg != null)
            {
                if (cfg.AppSettings.Settings["UpdatingXmlUrl"] != null &&
                    cfg.AppSettings.Settings["UpdatingXmlUrl"].Value != null)
                {
                    try
                    {
                        this._updateXmlUrl = cfg.AppSettings.Settings["UpdatingXmlUrl"].Value.ToString();
                    }
                    catch { }
                }
            }

            ///Get current version.
            System.Diagnostics.FileVersionInfo fvi =
                    System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            this._currentVersion = fvi.FileVersion;
            this.lcCurrentVersion.Text = this._currentVersion;
            this.lcLatestVersion.Text = "Unknown!";
            this.lcUrgency.Text = "Unknown!";
            this.lcReleaseDate.Text = "Unknown!";
            this.richtxtReleaseNote.Text = "";
        }

        private void ProcDownloadXml(object o)
        {
            try
            {
                //Download
                clientDownload = new WebClient();

                //Added the function to support proxy
                clientDownload.Proxy = WebRequest.DefaultWebProxy;
                clientDownload.Proxy.Credentials = CredentialCache.DefaultCredentials;
                clientDownload.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //End added

                clientDownload.DownloadFileCompleted += ClientDownload_DownloadFileCompleted;

                ///New file.
                string fileName = this._updateXmlUrl.Substring(this._updateXmlUrl.LastIndexOf("/") + 1);
                if (!string.IsNullOrEmpty(fileName))
                {
                    if (Directory.Exists(this._updatingDirectory) == false)
                    {
                        Directory.CreateDirectory(this._updatingDirectory);
                    }

                    string filePath = this._updatingDirectory + "/" + fileName;
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    clientDownload.DownloadFileAsync(new Uri(this._updateXmlUrl),
                                                     filePath,
                                                     filePath);
                }

                //Wait for the download complete
                evtDownload.WaitOne();
                clientDownload.Dispose();
                clientDownload = null;
            }
            catch (Exception)
            {
                //log the error message,you can use the application's log code
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientDownload_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (this.richtxtReleaseNote.InvokeRequired)
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(delegate ()
                {
                    this.ClientDownload_DownloadFileCompleted(sender, e);
                }));
            }
            else
            {
                try
                {
                    string path = e.UserState as string;
                    if (path != null)
                    {
                        this._updateInfor = UpdateInfor.Load(path);
                        if (this._updateInfor != null)
                        {
                            this.lcUrgency.Text = this._updateInfor.Urgency;
                            this.lcReleaseDate.Text = this._updateInfor.ReleaseDate;
                            this.lcLatestVersion.Text = this._updateInfor.LatestVersion;
                            if (this._updateInfor.Available && new Version(this._currentVersion) < new Version(this._updateInfor.LatestVersion))
                            {
                                this.richtxtReleaseNote.ReadOnly = false;
                                this.richtxtReleaseNote.BeginUpdate();
                                DevExpress.XtraRichEdit.API.Native.Document doc = this.richtxtReleaseNote.Document;
                                doc.BeginUpdate();
                                try
                                {
                                    doc.Text = "";
                                    doc.AppendText("    " + this._updateInfor.ReleaseNote.Prefix);
                                    doc.AppendText(Environment.NewLine);
                                    foreach (ReleaseNoteItem rni in this._updateInfor.ReleaseNote.Items)
                                    {
                                        doc.AppendText("    " + rni.ID + "、" + rni.Content + "。");
                                        doc.AppendText(Environment.NewLine);
                                    }

                                    doc.AppendText("    " + this._updateInfor.ReleaseNote.Suffix);
                                    this.richtxtReleaseNote.DeselectAll();
                                }
                                catch
                                {

                                }
                                finally
                                {
                                    doc.EndUpdate();
                                    this.richtxtReleaseNote.EndUpdate();
                                }

                                this.richtxtReleaseNote.ReadOnly = true;
                            }
                            else
                            {
                                this.richtxtReleaseNote.Text = "Congratulations, the application is latest!";
                            }
                        }
                        else
                        {
                            this.richtxtReleaseNote.Text = "The updating xml file is bad!";
                        }
                    }

                    evtDownload.Set();
                }
                catch (Exception)
                {
                    //log the error message,you can use the application's log code
                }
                finally
                {
                    this.bbiCheck.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ///Download the xml.
            if (this._updateXmlUrl != null)
            {
                evtDownload = new ManualResetEvent(true);
                evtDownload.Reset();
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcDownloadXml));
                this.bbiCheck.Enabled = false;
            }
            else
            {
                this.richtxtReleaseNote.Text = "Cannot find the update config information!";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiDownload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._updateInfor != null && !string.IsNullOrEmpty(this._updateInfor.UpdatingUrl))
            {
                System.Diagnostics.Process.Start(this._updateInfor.UpdatingUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichtxtContent_PopupMenuShowing(object sender, DevExpress.XtraRichEdit.PopupMenuShowingEventArgs e)
        {
            e.Menu = null;
        }
    }
}
