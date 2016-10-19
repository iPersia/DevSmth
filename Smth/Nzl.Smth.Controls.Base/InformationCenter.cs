namespace Nzl.Smth.Controls.Base
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Display temp information.
    /// </summary>
    public static class InformationCenter
    {
        #region static
        /// <summary>
        /// 
        /// </summary>
        private static Queue<string> _staticMsgQueue = new Queue<string>();

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
        private static bool _staticIsRunning = true;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        static InformationCenter()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ThreadStart()
        {
            (new Thread(Run)).Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ThreadStop()
        {
            _staticIsRunning = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void ShowInformation(string text)
        {
            try
            {
                _staticMsgQueue.Enqueue(text);
            }
            catch { }
            finally
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {
            while (_staticIsRunning)
            {
                try
                {
                    if (_staticMsgQueue.Count > 0)
                    {
                        if (_staticIsWaitFormShown == false)
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(BaseWaitForm));
                            _staticIsWaitFormShown = true;
                        }

                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription(_staticMsgQueue.Dequeue());
                    }
                    else
                    {
                        if (_staticIsWaitFormShown)
                        {
                            Thread.Sleep(1000);
                            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                            _staticIsWaitFormShown = false;
                        }
                    }

                    Thread.Sleep(100);
                }
                catch
                {
                }
            }
        }
    }
}
