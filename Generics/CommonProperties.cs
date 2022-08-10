////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: CommonProperties.cs
//Description : Collects all common variables defined with get-set methods
////////////////////////////////////////////////////////////////////////////////////////////////////////

using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.IO;

namespace MFGAutomation.Generics
{
    /// <summary>
    /// Contains all the common variables defined with get-set method those used in the framework
    /// </summary>
    
    public class CommonProperties
    {
        #region[Common]
        public static IWebDriver Driver { get; set; }
        public static string ProjectPath { get; set; }
        public static string ScreenshotFolder { get; set; }
        public static string ScreenshotPath { get; set; }
        #endregion[Common]

        #region[EnvironmentSetUp]
        public static string TestURL { get; set; }
        public static string Browser { get; set; }
        public static ExtentReports Extent { get; set; }
        public static ExtentTest Test { get; set; }
        public static StreamWriter StreamWriter { get; set; }
        #endregion[EnvironmentSetUp]

        #region[EnvironmentSetUpVision]
        public static string VisionURL { get; set; }
        #endregion[EnvironmentSetUpVision]

        #region[BuyerData]
        public static string BuyerUserName { get; set; }
        public static string BuyerPassword { get; set; }
        #endregion[BuyerData]

        #region[ManufacturerData]
        public static string ManufacturerUserName { get; set; }
        public static string ManufacturerPassword { get; set; }
        #endregion[ManufacturerData]

        #region[VisionData]
        public static string VisionUserName { get; set; }
        public static string VisionPassword { get; set; }
        #endregion[VisionData]

        #region[LoginId]
        public static string UserName { get; set; }
        public static string Password { get; set; }
        #endregion[LoginId]

        #region[ExcelConstants]
        public static int RowCount { get; set; }
        public static int NumberOfCols { get; set; }
        #endregion[ExcelConstants]
    }
}
