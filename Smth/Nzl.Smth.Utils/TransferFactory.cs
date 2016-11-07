namespace Nzl.Smth.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Nzl.Smth.Datas;
    using Nzl.Web.Page;

    /// <summary>
    /// 
    /// </summary>
    public static class TransferFactory
    {
        #region Variables
        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticActionRegex = new Regex(@"<form action=\W[A-Za-z0-9/]*\W method=\Wpost\W>");

        /// <summary>
        /// 
        /// </summary>
        private static Regex _staticUsersRegex = new Regex(@"<option value=\W[a-zA-z][a-zA-Z0-9]{1,11}\W>(?'User'[a-zA-z][a-zA-Z0-9]{1,11})</option>");

        /// <summary>
        /// 
        /// </summary>
        private static string _staticThreadsToken = "<input type=\"checkbox\" name=\"threads\" />";

        /// <summary>
        /// 
        /// </summary>
        private static string _staticNoRefToken = "<input type=\"checkbox\" name=\"noref\" />";

        /// <summary>
        /// 
        /// </summary>
        private static string _staticNoAttToken = "<input type=\"checkbox\" name=\"noatt\" />";
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Transfer GetTransfer(WebPage wp)
        {
            Transfer transfer = new Transfer();
            if (wp != null && wp.IsGood)
            {
                transfer.Url = wp.URL;
                Match match = _staticActionRegex.Match(wp.Html);
                if (match.Success)
                {
                    transfer.Url = match.Value.ToString();
                }

                transfer.Url = wp.URL;

                MatchCollection mtCollection = _staticUsersRegex.Matches(wp.Html);
                if (mtCollection != null)
                {
                    IList<string> users = new List<string>();
                    foreach (Match mt in mtCollection)
                    {
                        users.Add(mt.Groups["User"].Value.ToString());
                    }

                    transfer.Users = users;
                }

                transfer.IsShowThreads = wp.Html.Contains(_staticThreadsToken);
                transfer.IsShowNoRef = wp.Html.Contains(_staticNoRefToken);
                transfer.IsShowNoAtt = wp.Html.Contains(_staticNoAttToken);
            }

            return transfer;
        }
    }
}
