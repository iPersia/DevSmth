namespace Nzl.Smth.Loaders
{
    using System.IO;
    using DevExpress.Office.Services;
    using Nzl.Smth.Configs;
    using Nzl.Web.Util;

    /// <summary>
    /// 
    /// </summary>
    public class ImageStreamProvider : IUriStreamProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public ImageStreamProvider()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Stream GetStream(string url)
        {
#if (X)
            System.Diagnostics.Debug.WriteLine(this._parentControl.GetHashCode() + "\t ImageStreamProvider - GetStream - " + url);
#endif
            ///Icon.
            if (url.Contains("http") == false)
            {
                url = Configuration.BaseUrl + url;
            }

            return CommonUtil.GetWebImageStream(url);
        }
    }
}
