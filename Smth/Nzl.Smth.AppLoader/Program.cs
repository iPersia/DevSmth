using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Nzl.Smth.AppLoader
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Run();    
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {
            System.Configuration.Configuration cfg =
              System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            if (cfg != null)
            {
                string appLocation = null;
                if (cfg.AppSettings.Settings["AppStartFolder"] != null &&
                    cfg.AppSettings.Settings["AppStartFolder"].Value != null)
                {
                    try
                    {
                        appLocation += cfg.AppSettings.Settings["AppStartFolder"].Value.ToString();
                    }
                    catch { }
                }

                if (cfg.AppSettings.Settings["AppExecutable"] != null &&
                    cfg.AppSettings.Settings["AppExecutable"].Value != null)
                {
                    try
                    {
                        appLocation += "/" + cfg.AppSettings.Settings["AppExecutable"].Value.ToString();
                    }
                    catch { }
                }

                if (appLocation != null)
                {
                    try
                    {
                        Process.Start(System.Environment.CurrentDirectory + "\\" +　appLocation);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
