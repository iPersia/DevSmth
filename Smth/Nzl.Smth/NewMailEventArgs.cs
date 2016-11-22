namespace Nzl.Smth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class NewMailEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public NewMailEventArgs()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public string SourceContent
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string NewContent
        {
            get;
            set;
        }
    }
}
