using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;

namespace MFG_Atomation.Generics
{
    class LoggerConfig
    {
        #region [Field]
        public static ILog Logger;
        public static ConsoleAppender ConsoleApp;
        private static FileAppender FileAppender;
        public static RollingFileAppender RollingFileAppender;
        private static string layout = "%-25d:: %-5p :: [%c{1}]  :: %m. %n";
        #endregion

        #region [Property]
        public static string Layout
        {
            set { layout = value; }
        }
        #endregion [Field]

        #region [Private]
        /// <summary>
        /// this method used for GetPatternLayout
        /// </summary>
        /// <returns></returns>
        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }  
             
        /// <summary>
        /// this method is used for GetConsoleAppender
        /// </summary>
        /// <returns></returns>
        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "Console Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        /// <summary>
        /// this method is used for Get File Appender
        /// </summary>
        /// <returns></returns>
        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "File Appender",
                Layout = GetPatternLayout(),
                AppendToFile = true,
                Threshold = Level.All,
                File = "FileLogger.log",

            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        /// <summary>
        /// this method is used for GetRollingFileAppender
        /// </summary>
        /// <param name="logFolder"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        private static RollingFileAppender GetRollingFileAppender(string logFolder, string className)
        {
            string path = String.Concat(logFolder, className);
            var rollingFileAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                Layout = GetPatternLayout(),
                AppendToFile = false,
                Threshold = Level.All,
                File = path + ".log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = -1, 
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true,
            };
            rollingFileAppender.ActivateOptions();
            return rollingFileAppender;
        }

        #endregion [Private]

        #region [Public]
        /// <summary>
        ///this method is used for get logs
        /// </summary>
        /// <param name="type"></param>
        /// <param name="logFolder"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static ILog GetLogger(Type type, string logFolder, string className)
        {
            if (ConsoleApp == null)
                ConsoleApp = GetConsoleAppender();
            if (FileAppender == null)
                FileAppender = GetFileAppender();
            if (RollingFileAppender == null)
                RollingFileAppender = GetRollingFileAppender(logFolder, className);
            if (Logger != null)
                return Logger;
            BasicConfigurator.Configure(ConsoleApp, RollingFileAppender);
            Logger = LogManager.GetLogger(type);
            return Logger;
        }
        #endregion  [Public]
    }
}
