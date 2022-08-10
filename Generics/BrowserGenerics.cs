////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BrowserGenerics.cs
//Description : Maintains functions to invoke the browser defined in config.xml
////////////////////////////////////////////////////////////////////////////////////////////////////////

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using MFG_Automation.Generics;

namespace MFGAutomation.Generics
{
    /// <summary>
    /// Maintains functions to invoke the browser defined in config.xml
    /// </summary> 
    class BrowserGenerics : CommonProperties
    {
        /// <summary>
        /// Invokes the browser defined in config.xml for execution
        /// </summary>
        /// <returns>driver</returns>
        public static IWebDriver LaunchBrowser()
        {
            try
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-mazimized");
                chromeOptions.AddArguments("enable-automation");
                chromeOptions.AddArguments("--disable-infobars");
                chromeOptions.AddArguments("--disable-popup-blocking");
                chromeOptions.AddArguments("--disable-default-apps");
                chromeOptions.AddArguments("--incognito");
                Driver = new ChromeDriver(chromeOptions);
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(TestURL);
                Logs.PrintInfo("Chrome Browser is launched successfully.");
                Logs.PrintInfo($"{Browser} is launched successfully for execution.");
                Helper.ImplicitWait(10);
                Logs.PrintInfo($"Navigated to URL - {TestURL}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Driver;
        }

        /// <summary>
        /// Closes all Browser Windows associated with the driver and safely ends the session
        /// </summary>
        public static void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
