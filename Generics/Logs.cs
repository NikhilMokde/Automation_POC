using AventStack.ExtentReports;
using MFG_Atomation.Generics;
using MFGAutomation.Generics;
using NUnit.Framework;
using System;

namespace MFG_Automation.Generics
{
    /// <summary>
    /// Helps to initialize log4j and the invoke a method to get the instance of log4j in each of the other classes
    /// All Log levels are defined in this class to print the details
    /// </summary>
    public class Logs : CommonProperties
    {
        public static log4net.ILog Log;

        /// <summary>
        /// Initialize Log4net at the start of execution
        /// </summary>
        public static void StartLogger(string Testcase ="")
        {
            Log = LoggerConfig.GetLogger(typeof(Logs), Constants.LogFolder, Testcase);
        }

        /// <summary>
        /// Initialize Extent Reports at the start of execution
        /// </summary>
        public static void StartReporting(string Testcase ="")
        {
            Extent = ExtentManager.StartReport(Testcase);
        }

        /// <summary>
        /// Calls to initialize Logger at the start of execution
        /// </summary>
        public static void InitializeLogger()
        {
            CommonActions.GetProjectPath();
            StartLogger();
            PrintInfo("===============================================================================================================");
            PrintInfo("XXXXXXXXXXXXXXXXXXX " + "Execution of MFG Test Cases Started" + "  XXXXXXXXXXXXXXXXXXXXX");
            PrintInfo("===============================================================================================================");
        }

        /// <summary>
        /// Prints the Log info at the End of Execution
        /// </summary>
        public static void EndExecution()
        {
            PrintInfo("===============================================================================================================");
            PrintInfo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX     " + "E.N.D" + "     XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            PrintInfo("===============================================================================================================");
            LoggerConfig.Logger = null;
            LoggerConfig.ConsoleApp = null;
            LoggerConfig.RollingFileAppender = null;
            log4net.LogManager.Shutdown();
        }

        /// <summary>
        /// Prints the log at start of test case
        /// </summary>
        public static void StartTestCase()
        {
            PrintInfo("===============================================================================================================");
            PrintInfo("XXXXXXXXXXXXXXXXXXX  Test Case : " + TestContext.CurrentContext.Test.MethodName + " started XXXXXXXXXXXXXXXXXXXX");
            PrintInfo("===============================================================================================================");
        }

        /// <summary>
        /// Prints the log at end of test case
        /// </summary>
        public static void EndTestCase()
        {
            PrintInfo("===============================================================================================================");
            PrintInfo("====================== End of Test Case : " + TestContext.CurrentContext.Test.MethodName + " ============================");
            PrintInfo("===============================================================================================================");
        }

        /// <summary>
        /// Prints a log message with Info status
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Log.Info(message);
            Test.Log(Status.Pass, message);
        }

        /// <summary>
        /// Prints a log message with Pass status
        /// </summary>
        /// <param name="message">provide Message</param>
        public static void Pass(string message, string testName ="")
        {
            Log.Info(message);
            CommonActions.TakesScreenshot(message);
            Test.Log(Status.Pass, $"{message} {Test.AddScreenCaptureFromPath(ScreenshotPath)}");
        }

        /// <summary>
        /// Prints a log message with Info status
        /// </summary>
        /// <param name="message"></param>
        public static void PrintInfo(string message)
        {
            Log.Info(message);
        }

        /// <summary>
        /// Prints a log message with Fail status
        /// </summary>
        /// <param name="message"></param>
        public static void Fail(string message)
        {
            Log.Error(message);
            Test.Log(Status.Fail, message);
        }


        /// <summary>
        /// Prints a log message with Warning status
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(String message)
        {
            Log.Warn(message);
            Test.Log(Status.Warning, message);
        }

        /// <summary>
        /// Prints a log message with Error status
        /// </summary>
        /// <param name="message"></param>
        public static void Error(String message)
        {
            Log.Error(message);
            Test.Log(Status.Error, message);
        }

        /// <summary>
        /// Prints a log message with Fatal status
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(String message)
        {
            Log.Fatal(message);
            Test.Log(Status.Fatal, message);
        }       
        /// <summary>
        /// Modified exception message to remove duplicate text
        /// </summary>
        /// <param name="exceptionMsg"></param>
        /// <returns></returns>
        public static string ErrorLog(Exception exceptionMsg)
        {
            string trace = exceptionMsg.StackTrace;
            string[] stringSeparators = new string[] { ", or:" };
            string[] error = exceptionMsg.Message.Split(stringSeparators, StringSplitOptions.None);
            string msg = $"{trace}{error[0]}";
            return msg;
        }

    
    }
}
