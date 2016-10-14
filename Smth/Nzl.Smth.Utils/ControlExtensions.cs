namespace Nzl.Smth.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraBars;

    /// <summary>
    /// 
    /// </summary>
    public static class ControlExtensions
    {
        public static void Initialize(this HyperlinkLabelControl ctl)
        {
            ctl.Appearance.LinkColor = System.Drawing.Color.Blue;
            ctl.Appearance.PressedColor = System.Drawing.Color.Red;
            ctl.Appearance.VisitedColor = System.Drawing.Color.Green;
            ctl.Appearance.Options.UseFont = true;
            ctl.Appearance.Options.UseLinkColor = true;
            ctl.Appearance.Options.UsePressedColor = true;
            ctl.Appearance.Options.UseVisitedColor = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bar"></param>
        public static void Initialize(this BarManager bm)
        {
            foreach(BarItem bi in bm.Items)
            {
                BarButtonItem bbi = bi as BarButtonItem;
                if (bbi != null)
                {
                    bbi.Size = new System.Drawing.Size(60, 0);
                    bbi.ContentHorizontalAlignment = BarItemContentAlignment.Center;
                }
            }
        }
    }
}
