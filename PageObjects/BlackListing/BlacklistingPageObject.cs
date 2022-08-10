using MFG_Atomation.Generics;
using MFG_Automation.Generics;
using MFGAutomation.Generics;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace MFG_Atomation.PageObjects.BlackListing
{
    class BlacklistingPageObject : CommonProperties
    {
        #region[Variables]               
        public LeftNavigation leftNavigation;
        public ReadExcelFile readExcelFile;
        Random ran = new Random();
        public Helper helper =new Helper();

        #endregion[Variables]

        public BlacklistingPageObject()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(20)));
        }

        #region[Page Object]
        #region[discover manufacture]
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Blacklist Manufacturer')]")]
        public IWebElement LinkBlackListManufacture { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[contains(text(),'Cancel')]/following-sibling::button)[2]")]
        public IWebElement ButtonBlackList { get; set; }
        #endregion[discover manufacture]

        #region[My Contact]
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Blacklisted')]")]
        public IWebElement MyContactBlackListButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@class='pointerCursor text-truncate']")]
        public IWebElement HeadingCompanyName { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Contact List')]")]
        public IWebElement ContactlistButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'MFG Contacts')]")]
        public IWebElement MyContactButton { get; set; }
        #endregion[My Contact]

        #region[Profile Page]
        [FindsBy(How = How.XPath, Using = "//img[@ngbtooltip='Blacklist Buyer']")]
        public IWebElement BlacklistButtonOnProfilePage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Blacklist')]")]
        public IWebElement BlackListButton { get; set; }
        #endregion[Profile Page]
        #endregion[Page Object]

        #region[Methods]
        /// <summary>
        /// Blacklist to supplier
        /// </summary>
        /// <param name="sheetName">provide sheetname</param>
        public void BlackListToSupplier(string sheetName, bool isBlackListSupplierDisplay = false)
        {
            //fetch data from Excel to create a new RFQ
            readExcelFile = new ReadExcelFile(Constants.LoginRegTestDataFile);
            Logs.Info("==========BlackListToSupplier==========");
            try
            {
                //object creation
                leftNavigation = new LeftNavigation();
               
                //Select Discover Manufacturer from left navigation
               
                Logs.Info("Select Discover Manufacturer from left navigation");


                //click on link blacklist manufacture
                Helper.ClickElement(LinkBlackListManufacture);
                Logs.PrintInfo("click on link blacklist manufacture");

                //click on blacklist button
                CommonActions.ElementWait(ButtonBlackList, 10);
                Helper.ClickElement(ButtonBlackList);
                Logs.Info("click on blacklist button");

                //close excel file
                readExcelFile.CloseExcelFile();
                Logs.Info("close excel file");
            }
            catch (Exception ex)
            {
                readExcelFile.CloseExcelFile();
                Logs.Info(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }

        /// <summary>
        /// Verify Blacklisted User In Contact List
        /// </summary>
        /// <param name="sheetName">provide sheetName</param>
        public void VerifyBlacklistUserInContactList(string sheetName, string tabName = "")
        {
            readExcelFile = new ReadExcelFile(Constants.LoginRegTestDataFile);
            try
            {
                //open excel file
                readExcelFile.OpenExcelFile(sheetName);

                switch (tabName)
                {
                    //click on Contact List Tab
                    case "Contact List":
                        Helper.JavaScriptClick(ContactlistButton);
                        Logs.Info("click on Contact List Tab");
                        break;

                    //click on MFG Contact Tab
                    case "MFG Contacts":
                        Helper.JavaScriptClick(MyContactButton);
                        Logs.Info("click on MFG Contact Tab");
                        break;
                }
                //click on Blacklist button
                CommonActions.ElementWait(MyContactBlackListButton, 20);
                Helper.AddDelay(2000);
                Helper.ClickElement(MyContactBlackListButton);
                Logs.Info("click on Blacklist button");

                //verify search result should be display
                CommonActions.ElementWait(HeadingCompanyName, 20);
                string companyTitle = Helper.GetText(HeadingCompanyName);
                Helper.AddDelay(2000);
               

                //close excel file
                readExcelFile.CloseExcelFile();
            }
            catch (Exception ex)
            {
                readExcelFile.CloseExcelFile();
                Logs.Info(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }
      
        #endregion[Methods]
    }
}



