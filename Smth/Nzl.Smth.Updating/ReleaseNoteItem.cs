namespace Nzl.Smth.Updating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReleaseNoteItem
    {
        /// <summary>
        /// 
        /// </summary>
        private string _id = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _note = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            get
            {
                return this._id;
            }

            set
            {
                this._id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get
            {
                return this._note;
            }

            set
            {
                this._note = value;
            }
        }

    }
}
