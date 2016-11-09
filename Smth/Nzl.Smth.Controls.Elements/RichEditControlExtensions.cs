namespace Nzl.Smth.Controls.Elements
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.API.Native;
    using Nzl.Smth.Configs;
    using Nzl.Smth.Utils;

    /// <summary>
    /// 
    /// </summary>
    public static class RichEditControlExtensions
    {
        #region Variable
        /// <summary>
        /// 
        /// </summary>
        private static string _staticNewlineToken = "_TOKEN_";

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadContentIPRegex = new Regex(@"(--)?<br />(修改:[a-zA-z][a-zA-Z0-9]{1,11} FROM (\d+\.){3}(\*|\d+)<br />)?FROM (\d+\.){3}(\*|\d+)(<br />)?");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadContentMobileModifyRegex = new Regex(@"※ 修改:·[a-zA-z][a-zA-Z0-9]{1,11} 于 [A-Z][a-z]{2}[^\d]+\d+ \d{2}:\d{2}:\d{2} \d{4} 修改本文·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>※ 来源:·水木社区 <a target=\W_blank\W href=\Whttp://m.newsmth.net\W>http://m.newsmth.net</a>·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadContentForumModifyRegex = new Regex(@"※ 修改:·[a-zA-z][a-zA-Z0-9]{1,11} 于 [A-Z][a-z]{2}[^\d]+\d+ \d{2}:\d{2}:\d{2} \d{4} 修改本文·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>※ 来源:·水木社区 <a target=\W_blank\W href=\Whttp://www.newsmth.net\W>http://www.newsmth.net</a>·\[FROM: (\d+\.){3}(\*|\d+)\]<br/>");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticThreadReplyPattern = new Regex(@"【 在 [a-zA-z][a-zA-Z0-9]{1,11} (\((.+)?\) )?的大作中提到: 】");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticIPRegexForColor = new Regex(_staticNewlineToken + @"\s*--\s*" + _staticNewlineToken + @"\s*(修改:[a-zA-z][a-zA-Z0-9]{1,11} FROM (\d+\.){3}(\*|\d+)\s*" + _staticNewlineToken + @"\s*)?FROM (\d+\.){3}(\*|\d+)");
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="contentHtml"></param>
        public static void ApplyContent(this RichEditControl ctl, string threadContentHtml)
        {
            if (threadContentHtml != null)
            {
                ctl.BeginUpdate();
                Document doc = ctl.Document;
                try
                {
                    ///Trim ip.
                    string contentHtml = threadContentHtml;
                    if (Configuration.ShowIPinTopic == false)
                    {
                        contentHtml = _staticThreadContentIPRegex.Replace(threadContentHtml, "");
                        contentHtml = _staticThreadContentMobileModifyRegex.Replace(contentHtml, "");
                        contentHtml = _staticThreadContentForumModifyRegex.Replace(contentHtml, "");
                    }


                    ctl.HtmlText = contentHtml.Replace("<br>", _staticNewlineToken).Replace("<br />", _staticNewlineToken).Replace("<br/>", _staticNewlineToken);
                    {
                        ///Set default font.                        
                        {
                            doc.BeginUpdate();
                            CharacterProperties cp = doc.BeginUpdateCharacters(0, doc.Length);
                            cp.FontName = "宋体";
                            cp.FontSize = 10.5F;
                            doc.EndUpdateCharacters(cp);
                            doc.EndUpdate();
                        }

                        ///Colored the replied thread content.
                        {
                            doc.BeginUpdate();

                            ///Find the reply head.
                            DocumentRange drReplyHeader = null;
                            {
                                DocumentRange[] drs = doc.FindAll(_staticThreadReplyPattern);
                                foreach (DocumentRange dr in drs)
                                {
                                    CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                                    cp.FontName = "宋体";
                                    cp.FontSize = 9;
                                    cp.ForeColor = Color.FromArgb(96, 96, 96);
                                    doc.EndUpdateCharacters(cp);

                                    drReplyHeader = dr;
                                    break;
                                }
                            }

                            ///Find the reply content.
                            {
                                if (drReplyHeader != null)
                                {
                                    DocumentRange[] drs = doc.FindAll(_staticNewlineToken, SearchOptions.None);
                                    DocumentRange drPrev = drReplyHeader;
                                    foreach (DocumentRange dr in drs)
                                    {
                                        if (dr.Start > drReplyHeader.End)
                                        {
                                            DocumentRange targetRange = doc.CreateRange(drPrev.End, dr.End.ToInt() - drPrev.End.ToInt());
                                            string content = doc.GetText(targetRange);
                                            {
                                                content = content.Replace(_staticNewlineToken, "");
                                                if (content.StartsWith(":"))
                                                {
                                                    CharacterProperties cp = doc.BeginUpdateCharacters(targetRange);
                                                    cp.FontName = "宋体";
                                                    cp.FontSize = 9;
                                                    cp.ForeColor = Color.FromArgb(96, 96, 96);
                                                    doc.EndUpdateCharacters(cp);
                                                }
                                            }
                                        }

                                        drPrev = dr;
                                    }
                                }
                            }

                            doc.EndUpdate();
                        }

                        ///Colored the From IP.
                        if (Configuration.ShowIPinTopic)
                        {
                            doc.BeginUpdate();
                            DocumentRange[] drsa = doc.FindAll(_staticIPRegexForColor);
                            foreach (DocumentRange dr in drsa)
                            {
                                CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                                cp.FontName = "宋体";
                                cp.FontSize = 9;
                                cp.ForeColor = Color.FromArgb(160, 160, 160);
                                doc.EndUpdateCharacters(cp);
                            }

                            doc.EndUpdate();
                        }

                        ///Colored the reply tail.
                        {
                            doc.BeginUpdate();
                            string repleyContent = SmthUtil.GetReplyText().Replace(@"\s+", _staticNewlineToken);
                            DocumentRange[] drs = doc.FindAll(repleyContent, SearchOptions.None);
                            foreach (DocumentRange dr in drs)
                            {
                                CharacterProperties cp = doc.BeginUpdateCharacters(dr);
                                cp.FontName = "宋体";
                                cp.FontSize = 9;
                                doc.EndUpdateCharacters(cp);
                            }

                            doc.EndUpdate();
                        }

                        ///Replace by newline
                        {
                            doc.BeginUpdate();
                            DocumentRange[] drs = doc.FindAll(_staticNewlineToken, SearchOptions.None);
                            for (int i = drs.Length - 1; i >= 0; i--)
                            {
                                doc.Replace(drs[i], Environment.NewLine);
                            }

                            doc.EndUpdate();
                        }

                        ctl.DeselectAll();
                    }
                }
                catch
                {

                }
                finally
                {
                    doc.EndUpdate();
                    ctl.EndUpdate();
                }
            }
        }
    }
}
