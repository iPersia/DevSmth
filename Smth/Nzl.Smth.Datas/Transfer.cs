namespace Nzl.Smth.Datas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Transfer : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        public Transfer()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<string> Users
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsShowThreads
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsShowNoRef
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsShowNoAtt
        {
            get;
            set;
        }
    }
}
