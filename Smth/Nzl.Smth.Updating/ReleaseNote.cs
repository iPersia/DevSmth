namespace Nzl.Smth.Updating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReleaseNote
    {
        /// <summary>
        /// 
        /// </summary>
        private string _prefix = null;

        /// <summary>
        /// 
        /// </summary>
        private string _suffix = null;

        /// <summary>
        /// 
        /// </summary>
        private ReleaseNoteItems _items = new ReleaseNoteItems();

        /// <summary>
        /// 
        /// </summary>
        public string Prefix
        {
            get
            {
                return this._prefix;
            }

            set
            {
                this._prefix = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Suffix
        {
            get
            {
                return this._suffix;
            }

            set
            {
                this._suffix = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ReleaseNoteItems Items
        {
            get
            {
                return this._items;
            }

            set
            {
                this._items = value;
            }
        }
    }
}
