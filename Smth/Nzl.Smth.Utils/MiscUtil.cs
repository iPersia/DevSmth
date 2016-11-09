namespace Nzl.Smth.Utils
{
    using System.Drawing;
    using System.Windows.Forms;
    using Nzl.Smth.Configs;

    public static class MiscUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GetFormattedTitle(Control ctl, string title)
        {
            string srcTitle = title;
            string suffix = "...";
            using (Graphics graphics = ctl.CreateGraphics())
            {
                SizeF sizeF = graphics.MeasureString(title, new Font("宋体", 9));
                SizeF sizeWord = graphics.MeasureString("N", new Font("宋体", 9));
                SizeF sizeSuffix = graphics.MeasureString(suffix, new Font("宋体", 9));
                float targetWidth = sizeWord.Width * Configuration.TitleWordCount * 2;
                if (sizeF.Width > targetWidth)
                {
                    while (sizeF.Width > targetWidth - sizeSuffix.Width)
                    {
                        title = title.Substring(0, title.Length - 1);
                        sizeF = graphics.MeasureString(title, new Font("宋体", 9));
                    }

                    title += suffix;
                }
                else
                {
                    while (sizeF.Width < targetWidth)
                    {
                        title = title + ".";
                        sizeF = graphics.MeasureString(title, new Font("宋体", 9));
                    }

                    title = srcTitle + title.Replace(srcTitle, "").Replace(".", " ");
                }
            }

            return title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hyperlink"></param>
        /// <returns></returns>
        public static string GetHyperlinkText(string text, string hyperlink)
        {
            return "<href=" + hyperlink + ">" + text + "</href>";
        }
    }
}
