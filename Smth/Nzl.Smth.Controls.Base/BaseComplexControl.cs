namespace Nzl.Smth.Controls.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseComplexControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public BaseComplexControl()
            : base()
        {
        }
        #endregion

        #region override
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Text;
        }
        #endregion
    }
}
