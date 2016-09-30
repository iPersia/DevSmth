namespace Nzl.Smth.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;

    /// <summary>
    /// 
    /// </summary>
    public static class HyperlinkLabelControlExtensions
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
    }
}
