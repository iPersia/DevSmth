﻿namespace Nzl.Smth.Datas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class Section : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Section()
        {
            this.IsBoard = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBoard
        {
            get;
            set;
        }
    }
}
