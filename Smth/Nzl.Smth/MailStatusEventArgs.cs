namespace Nzl.Smth
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class MailStatusEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public bool HasNewArrived
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int NewArrivedCount
        {
            get;
            set;
        }
    }
}
