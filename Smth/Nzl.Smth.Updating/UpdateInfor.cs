namespace Nzl.Smth.Updating
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    public class UpdateInfor
    {
        #region The private fields
        /// <summary>
        /// 
        /// </summary>
        private bool _available = false;

        /// <summary>
        /// 
        /// </summary>
        private string _urgency = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _latestVersion = null;

        /// <summary>
        /// 
        /// </summary>
        private string _updatingUrl = null;

        /// <summary>
        /// 
        /// </summary>
        private string _releaseDate = null;

        /// <summary>
        /// 
        /// </summary>
        private ReleaseNote _releaseNote = null;
        #endregion

        #region The public property
        /// <summary>
        /// 
        /// </summary>
        public bool Available
        {
            get
            {
                return this._available;
            }

            set
            {
                this._available = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Urgency
        {
            get
            {
                return this._urgency;
            }

            set
            {
                this._urgency = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UpdatingUrl
        {
            get
            {
                return this._updatingUrl;
            }

            set
            {
                this._updatingUrl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LatestVersion
        {
            get
            {
                return this._latestVersion;
            }

            set
            {
                this._latestVersion = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ReleaseDate
        {
            get
            {
                return this._releaseDate;
            }

            set
            {
                this._releaseDate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ReleaseNote ReleaseNote
        {
            get
            {
                return this._releaseNote;
            }

            set
            {
                this._releaseNote = value;
            }
        }
        #endregion

        #region The public method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static UpdateInfor Load(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpdateInfor));
            StreamReader sr = new StreamReader(file, Encoding.GetEncoding("gb2312"));
            UpdateInfor xml = xs.Deserialize(sr) as UpdateInfor;
            sr.Close();
            return xml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public void Save(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpdateInfor));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();
        }
        #endregion
    }
}
