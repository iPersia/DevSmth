namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Nzl.Controls;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Web.Util;

    /// <summary>
    /// 
    /// </summary>
    public static class ControlUtil
    {                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hyperlink"></param>
        /// <returns></returns>
        public static string GetHyperlinkText(string text, string hyperlink)
        {
            return "<href=" + hyperlink  + ">" + text + "</href>";
        }
    }
}
