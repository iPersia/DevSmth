namespace Nzl.Smth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class ControlCenter
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<string, int> _staticVisitedUrls = new Dictionary<string, int>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public static void AddVisitedUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url) == false)
                {
                    if (_staticVisitedUrls.ContainsKey(url) == false)
                    {
                        _staticVisitedUrls.Add(url, 1);
                    }
                    else
                    {
                        _staticVisitedUrls[url]++;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public static bool IsVisitedUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url) == false)
                {
                    return _staticVisitedUrls.ContainsKey(url);
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
