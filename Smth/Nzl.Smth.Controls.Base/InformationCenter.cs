namespace Nzl.Smth.Controls.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public static class InformationCenter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void ShowInformation(string text)
        {
            try
            {

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(BaseWaitForm));
            }
            catch { }
            finally
            {
            }
        }
    }
}
