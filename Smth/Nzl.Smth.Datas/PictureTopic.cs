namespace Nzl.Smth.Datas
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// 
    /// </summary>
    public class PictureTopic : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        private IList<string> _pictureUrls = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<string> PictureUrls
        {
            get
            {
                return this._pictureUrls;
            }
        }
    }
}