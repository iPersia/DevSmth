namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public partial class NavigatorControl : UserControl
    {
        #region event
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnFirstClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnPrevClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnNextClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnLastClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnSettingClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnRefreshClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnOpenInBrowserClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnGoClick;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnNewClick;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public NavigatorControl()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
