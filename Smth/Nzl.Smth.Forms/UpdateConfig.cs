namespace Nzl.Smth.Forms
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
    public class UpdateConfig
    {
        #region The private fields
        /// <summary>
        /// 
        /// </summary>
        private bool _enabled = false;

        /// <summary>
        /// 
        /// </summary>
        private string _latestVersion = null;

        /// <summary>
        /// 
        /// </summary>
        private string _serverUrl = null;
        #endregion

        #region The public property
        /// <summary>
        /// 
        /// </summary>
        public bool Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ServerUrl
        {
            get { return this._serverUrl; }
            set { this._serverUrl = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LatestVersion
        {
            get { return this._latestVersion; }
            set { this._latestVersion = value; }
        }
        #endregion

        #region The public method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static UpdateConfig Load(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpdateConfig));
            StreamReader sr = new StreamReader(file);
            UpdateConfig xml = xs.Deserialize(sr) as UpdateConfig;
            sr.Close();

            return xml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public void Save(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpdateConfig));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();
        }
        #endregion
    }

}
