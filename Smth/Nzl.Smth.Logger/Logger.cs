#if (RELEASE)
[assembly: Nzl.Log4Net.Config.XmlConfigurator(Watch = false)]
#else
[assembly: Nzl.Log4Net.Config.XmlConfigurator(Watch = true)]
#endif
namespace Nzl.Smth.Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class Logger
    {
#if (RELEASE)
        /// <summary>
        /// 
        /// </summary>
        private static bool _loggerEnabled = false;
#else
        /// <summary>
        /// 
        /// </summary>
        private static bool _loggerEnabled = true;
#endif

        /// <summary>
        /// 
        /// </summary>
        private static Nzl.Log4Net.ILog _logger = Nzl.Log4Net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        public static bool Enabled
        {
            get
            {
                return _loggerEnabled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Nzl.Log4Net.ILog Instance
        {
            get
            {
                return _logger;
            }
        }
    }
}
