namespace Nzl.Smth.Loaders
{
    using System;
    
    /// <summary>
    /// 
    /// </summary>
    public class ImageDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnDownloaded;

        /// <summary>
        /// 
        /// </summary>
        private string _imageUrl = null;

        /// <summary>
        /// 
        /// </summary>
        ImageDownloader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public ImageDownloader(string url)
            : this()
        {
            this._imageUrl = url;

            System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (this.OnDownloaded !=null)
            {
                this.OnDownloaded(this, new EventArgs());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Nzl.Web.Util.CommonUtil.GetWebImage(this._imageUrl);
            }
            catch
            {
                e.Result = null;
            }
        }
    }
}
