using MFG_Automation.Generics;
using MFGAutomation.Configurations;
using System;
using WH = SeleniumExtras.WaitHelpers;
using System.IO;
using AventStack.ExtentReports;

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace MFGAutomation.Generics
{
    class CommonActions : CommonProperties
    {
        /// <summary>
        /// Info in the LoginInfo.XML directory and the Module to scan for elements.
        /// </summary>
        /// <param name="module"></param>
        public static void ScanPage(string module)
        {
            try
            {
                //Pass in the LoginInfo.XML directory and the Module to scan for elements.
                ConfigReader.Readxml(Constants.TestDataXMLPath, module);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads config.xml file to setup configuration details for execution
        /// </summary>
        public static void SetUpConfigDetails()
        {
            try
            {
                string getProjectpath = GetProjectPath();
                string configFilePath = Constants.ConfigXMLFile;
                ConfigReader.Readxml(configFilePath, "EnvironmentSetUp");
                ConfigReader.Readxml(configFilePath, "EnvironmentSetUpVision");
                ConfigReader.Readxml(configFilePath, "BuyerData");
                ConfigReader.Readxml(configFilePath, "ManufacturerData");
                ConfigReader.Readxml(configFilePath, "VisionData");
                Logs.PrintInfo("Test configuration details are retrieved.");
            }
            catch (Exception ex)
            {
                Logs.Error($"Test configuration details are not retrieve {ex}");
                throw ex;
            }
        }

        /// <summary>
        /// Fetches the path of current working solution
        /// </summary>
        public static string GetProjectPath()
        {
            try
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                ProjectPath = new Uri(actualPath).LocalPath;
                return ProjectPath;
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to fetch Project location {ex}");
                throw ex;
            }
        }

        /// <summary>
        /// Performs action to get the current date and time details
        /// </summary>
        /// <returns>formattedTime</returns>
        public static String GetCurrentDate()
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("yyyy-MM-dd hh-mm-ss");
            return formattedTime;
        }

        /// <summary>
        /// /// Performs action to get the current date and time details as per defined format
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentDatePlain()
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("yyyyMMddhhmmss");
            return formattedTime;
        }

        /// <summary>
        ///  Performs action to get the current date and time for Append
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentDateToAppend()
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("MMddhhmmssff");
            return formattedTime;
        }

        /// <summary>
        /// Wait till visibility of loader which takes time to display at the time of data loading 
        /// </summary>
        public static void WaitTillVisibilityOfLoader()
        {
            try
            {
                By loader = By.XPath("//div[@class='loader animation-start']/span[8]");
                OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                wait.PollingInterval = TimeSpan.FromMilliseconds(5);
                wait.Until(WH.ExpectedConditions.InvisibilityOfElementLocated(loader));
            }
            catch (Exception ex)
            {
                Logs.Error($"element not visible  {ex}");
                throw;
            }
        }

        /// <summary>
        /// Method to check whether element is Click able or not.
        /// </summary>
        /// <param name="element">element to be checked</param>
        /// <param name="time">Time until which it has to check</param>
        /// <returns></returns>
        public static IWebElement ElementWait(OpenQA.Selenium.IWebElement element, int time)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(time));
                return wait.Until(WH.ExpectedConditions.ElementToBeClickable(element));
            }
           catch (Exception ex)
            {
                Logs.Error($"element not loaded  {ex}");
                throw;
            }
        }

        /// <summary>
        /// Captures screen shot of the screen for the failed step
        /// </summary>
        /// <param name="testName"></param>
        public static void TakesScreenshot(String testName)
        {
            try
            {
                if (!Directory.Exists(ScreenshotFolder))
                {
                    Directory.CreateDirectory(ScreenshotFolder);
                }
                ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
                Screenshot screenCapture = screenshotDriver.GetScreenshot();
                ScreenshotPath = $"{ ScreenshotFolder}\\{testName}-{ GetCurrentDatePlain()} .png";
                screenCapture.SaveAsFile(ScreenshotPath);
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to capture screen shot {ex}");
                throw;
            }
        }

        /// <summary>
        /// Write log in extent report for failed test case also write complete name of failed test case in text file
        /// </summary>
        /// <param name="testName"></param>
        /// <param name="e"></param>
        public static void TestFailed(String testName, Exception e)
        {
            try
            {
                TakesScreenshot(testName);
                Test.Fail(e + "Screen shot :", MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotPath).Build());
                StreamWriter = ExtentManager.FailedTest();
               // StreamWriter.WriteLine(TestContext.CurrentContext.Test.FullName);
                StreamWriter.Close();
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to capture screen shot {ex}");
                throw;
            }
        }

        
       
    }
}

