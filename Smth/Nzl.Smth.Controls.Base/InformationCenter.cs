namespace Nzl.Smth.Controls.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Display temp information.
    /// </summary>
    public static class InformationCenter
    {
        #region static
        /// <summary>
        /// 
        /// </summary>
        private static bool _staticIsWaitFormShown = false;

        /// <summary>
        /// 
        /// </summary>
        private static System.Threading.Mutex _staticMutexWaitFormShowing = new System.Threading.Mutex();

        /// <summary>
        /// 
        /// </summary>
        private static Timer _staticWaitFormTimer = new Timer();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        static InformationCenter()
        {
            _staticWaitFormTimer.Interval = 500;
            _staticWaitFormTimer.Tick += WaitFormTimer_Tick;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WaitFormTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _staticWaitFormTimer.Stop();
                _staticMutexWaitFormShowing.WaitOne();
#if (X)
                System.Diagnostics.Debug.WriteLine("WaitFormTimer_Tick - MutexWaitFormShowing.WaitOne!");
#endif
                if (_staticIsWaitFormShown)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                    _staticIsWaitFormShown = false;
                }
            }
            catch { }
            finally
            {
#if (X)
                System.Diagnostics.Debug.WriteLine("WaitFormTimer_Tick - MutexWaitFormShowing.ReleaseMutex!");
#endif
                _staticMutexWaitFormShowing.ReleaseMutex();
            }
        }
    }
}
