namespace Nzl.Web.Main
{
    using System;
    using System.Configuration;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.CompilerServices;
    using DevExpress.Utils;
    using Nzl.Messaging;
    using Nzl.Smth.Forms;
    using Nzl.Smth.Logger;

    /// <summary>
    /// 
    /// </summary>
    static class Program
    {        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ///皮肤
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");  // 设置皮肤样式                

                ////应用程序的主入口点
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //设置应用程序处理异常方式：ThreadException处理 
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                ////处理UI线程异常 
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                ////处理非UI线程异常 
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                ////应用程序的主入口点
                #region 设置DevExpress默认字体、日期格式、汉化
                DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("宋体", 9);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");//使用DEV汉化资源文件
                                                                                                                        //设置程序区域语言设置中日期格式
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("zh-CHS");
                System.Globalization.DateTimeFormatInfo di = (System.Globalization.DateTimeFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.Clone();
                di.DateSeparator = "-";
                di.ShortDatePattern = "yyyy-MM-dd";
                di.LongDatePattern = "yyyy'年'M'月'd'日'";
                di.ShortTimePattern = "H:mm:ss";
                di.LongTimePattern = "H'时'mm'分'ss'秒'";
                ci.DateTimeFormat = di;
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                #endregion
#if (DEBUG)
                Application.Run(new MainForm());
                //Application.Run(new TestForm());
#else
                bool createNew;
                using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
                {
                    if (createNew)
                    {
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        MessageForm msg = new MessageForm("Information", "The application is already running!");
                        msg.StartPosition = FormStartPosition.CenterScreen;
                        msg.ShowDialog();
                        System.Threading.Thread.Sleep(1000);
                        System.Environment.Exit(1);
                    }
                }
#endif
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }

                MessageBox.Show(GetExceptionMsg(exp, exp.ToString()), "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (Logger.Enabled)
            {
                Logger.Instance.Error(e.Exception.Message + "\n" + e.Exception.StackTrace);
            }

            MessageBox.Show(GetExceptionMsg(e.Exception, e.ToString()),
                            "System Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exp = e.ExceptionObject as Exception;
            if (exp != null)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }

                MessageBox.Show(GetExceptionMsg(exp, e.ToString()),
                                "System Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                RuntimeWrappedException rwe = e.ExceptionObject as RuntimeWrappedException;
                if (rwe != null)
                {
                    if (Logger.Enabled)
                    {
                        Logger.Instance.Error(rwe.InnerException.Message + "\n" + rwe.InnerException.StackTrace);
                    }

                    MessageBox.Show(GetExceptionMsg(rwe.InnerException, e.ToString()),
                                    "System Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    if (Logger.Enabled)
                    {
                        Logger.Instance.Error(e.ToString());
                    }

                    MessageBox.Show(GetExceptionMsg(null, e.ToString()),
                                    "System Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            MessageQueue.Enqueue(MessageFactory.CreateMessage(exp));
        }

        /// <summary> 
        /// 生成自定义异常消息 
        /// </summary> 
        /// <param name="ex">异常对象</param> 
        /// <param name="backStr">备用异常消息：当ex为null时有效</param> 
        /// <returns>异常字符串文本</returns> 
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************Exception****************************");
            sb.AppendLine("[Time]\t" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("[Exception Type]\t" + ex.GetType().Name);
                sb.AppendLine("[Exception Message]\t" + ex.Message);
                sb.AppendLine("[Stack information]\t" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("[Unhandled exception]\t" + backStr);
            }
            sb.AppendLine("*****************************************************************");
            return sb.ToString();
        }

        ///<summary> 
        ///返回＊.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }

            return null;
        }
    }
}
