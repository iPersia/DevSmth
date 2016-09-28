namespace Nzl.Smth.Controls.Elements
{
    using System.IO;
    using System.Windows.Forms;
    using DevExpress.Office.Services;
    using Nzl.Web.Util;

    /// <summary>
    /// 
    /// </summary>
    public class ImageStreamProvider : IUriStreamProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private Control _parentControl = null;

        /// <summary>
        /// 
        /// </summary>
        public ImageStreamProvider(Control ctl)
        {
            this._parentControl = ctl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Stream GetStream(string url)
        {
            System.Diagnostics.Debug.WriteLine(this._parentControl.GetHashCode() + "\t ImageStreamProvider - GetStream - " + url);
            return CommonUtil.GetWebImageStream(url);
        }
    }
}
