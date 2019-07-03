using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true,ConfigFile ="log.config")]
namespace jmILRL.common
{
    public class LogisTrac
    {
        /// <summary>
        /// �����־��Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion


        /// <summary>
        /// ��¼������־
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteError(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        /// <summary>
        /// ��¼��Ϣ��־
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteInfo(Type t, string msg) {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Info(msg);
        }


    }
}
