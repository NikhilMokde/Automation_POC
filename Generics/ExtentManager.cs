////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ExtentManager.cs
//Description : Refers to functions used to create Extent HTML report at runtime
////////////////////////////////////////////////////////////////////////////////////////////////////////

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using log4net.Appender;
using MFGAutomation.Generics;
using NUnit.Framework;
using System;
using System.IO;

namespace MFG_Automation.Generics
{
    /// <summary>
    /// This class can be created for extend report
    /// </summary>
    public class ExtentManager : CommonProperties
    {

        #region[Variables]
        /// <summary>
        /// Refers to functions to used create Extent HTML report at runtime
        /// </summary>
        private static ExtentReports _extent;
        private static string failedTestReport;
        private static StreamWriter writer;
        #endregion[Variables]

        /// <summary>
        /// This method gets the instance for Extent report generation and sets relevant data regarding execution
        /// </summary>
        /// <returns></returns>
        public static ExtentReports StartReport(string Testcase = "")
        {

            String reportPath = String.Concat(Constants.ReportPath, Testcase, ".html");
            ExtentHtmlReporter reporter = new ExtentHtmlReporter(reportPath);
            
            // make the charts visible on report open
            reporter.Configuration().ChartVisibilityOnOpen = true;

            // report title
            reporter.Configuration().DocumentTitle = Testcase;

            // encoding, default = UTF-8
            reporter.Configuration().Encoding = "UTF-8";

            // protocol (http, https)
            reporter.Configuration().Protocol = Protocol.HTTPS;

            // report or build name
            reporter.Configuration().ReportName = "JHA-Automation Report";

            // chart location - top, bottom
            reporter.Configuration().ChartLocation = ChartLocation.Top;

            // theme - standard, dark
            reporter.Configuration().Theme = Theme.Dark;

            // add custom css
            reporter.Configuration().CSS = "css-string";

            var roller = new RollingFileAppender { AppendToFile = false };
            string location = Constants.Logo;
            string modifiedLocation = location.Replace(":\\", "://");
            string finalURL = modifiedLocation.Replace("\\", "/");
            reporter.Configuration().JS = $"$('.brand-logo').text('').append('<img src={finalURL}>')";

            try
            {
                if (_extent == null)
                {
                    // Creates object of ExtentReports class- This is main class which will create report
                    _extent = new ExtentReports();

                    // attach the reporter which we created in Step 1
                    _extent.AttachReporter(reporter);

                    // Add customized system info
                    OperatingSystem os = Environment.OSVersion;
                    string OS = Convert.ToString(os);
                    _extent.AddSystemInfo("Host Name", "JHA Automation");
                    _extent.AddSystemInfo("Environment", "Production");
                    _extent.AddSystemInfo("User Name", "JHAAUtomation Team");
                    _extent.AddSystemInfo("BrowserType", Browser);
                    _extent.AddSystemInfo("Test Build", TestURL);
                    _extent.AddSystemInfo("Operating System", OS);
                    failedTestReport = $"{Constants.FailedTests}" + Testcase + "_" + CommonActions.GetCurrentDatePlain();
                    ScreenshotFolder = $"{Constants.ReportPath}" + Testcase + "_" + CommonActions.GetCurrentDatePlain();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _extent;
        }

        /// <summary>
        /// Start test case by passing test case name in extent report 
        /// </summary>
        /// <param name="testName"></param>
        public static void CreateTest(string testName)
        {
            string testCaseId = (string)TestContext.CurrentContext.Test.Properties.Get("TestCaseId");
            string description = (string)TestContext.CurrentContext.Test.Properties.Get("Description");
            Test = Extent.CreateTest(testCaseId + " " + testName, description);
            Test.AssignAuthor(((string)TestContext.CurrentContext.Test.Properties.Get("Author")));
            Test.AssignCategory((string)TestContext.CurrentContext.Test.Properties.Get("Category"));
        }
        
        /// <summary>
        /// Write failed test case name in  text file in Result folder> FailedTests
        /// </summary>
        /// <returns></returns>
        public static StreamWriter FailedTest()
        {
            {
                try
                {
                    //Pass the file path and filename to the StreamWriter Constructor
                    writer = File.AppendText(failedTestReport);
                }
                catch (Exception e)
                {
                    Logs.Error($"Unable to write failed test case name in text file {e}");
                    throw e;
                }
                return writer;
            }
        }

        /// <summary>
        /// To get a current date and time
        /// </summary>
        /// <returns>exact current date and time</returns>
        public static String GetTimestamp()
        {
            return DateTime.Now.ToString("dd-MM-yyyyy-HHmmssffff");
        }


        /// <summary>
        /// to write Report
        /// </summary>
        /// <param name="Testcase"></param>
        public static void reportWriting(string Testcase)
        {
            try
            {
                string reportPath = String.Concat(Constants.ReportPath, Testcase, "-", CommonActions.GetCurrentDate() + ".html");
                if (!Directory.Exists(reportPath))
                {
                    Directory.CreateDirectory(reportPath);
                    StreamWriter = ExtentManager.FailedTest();
                    StreamWriter.WriteLine(TestContext.CurrentContext.Test.FullName);
                    StreamWriter.Close();
                    Extent.Flush();
                }
            }
            catch(Exception ex)
            {
                Logs.Error($"Unable to write test case name in text file {ex}");
                throw ex;
            }            
        }
    }
}
