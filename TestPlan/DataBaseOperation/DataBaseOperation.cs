
using MFG_Atomation.Utility.BlackListing;
using MFG_Automation.Generics;
using MFGAutomation.Generics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFG_Atomation.TestPlan.ActionTracker
{
    class ActionTracker : CommonProperties
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Logs.InitializeLogger();
            CommonActions.SetUpConfigDetails();
        }

        [SetUp]
        public void InitializeBroser()
        {
            //Logs.StartTestCase();
            //Driver = BrowserGenerics.LaunchBrowser();
            //Logs.PrintInfo("Browser is initialized successfully");
        }


        [Test, Description("Retrive Record From Database")]
        [Author("DataBase AUtomation Automation")]
        [Property("TestCaseId", "01")]
        [Category("Functional")]
        public void RetriveDataFromDatabase()
        {
            //Report Generation
            Logs.StartReporting(Constants.RetriveDataFromDatabase);

            //Start Execution
            ExtentManager.CreateTest(Constants.RetriveDataFromDatabase);
            try
            {
                //      ActionTrackerUtility.M2_3444_BuyerActionTrackerTab(Constants.M2_3394_ActionTrackerBuyerTab);
                DatabaseUtility.RetriveDataFromDatabase();
                Logs.Info("Test case passed successfully");
            }
            catch (Exception ex)
            {
                CommonActions.TestFailed(Constants.RetriveDataFromDatabase, ex);
                Logs.Fail("Test case failed");
                throw ex;
            }
        }

        [Test, Description("Insert Record Into Database")]
        [Author("DataBase AUtomation Automation")]
        [Property("TestCaseId", "01")]
        [Category("Functional")]
        public void InsertDataFromDatabase()
        {
            //Extent Report Generation
            Logs.StartReporting(Constants.InsertDataFromDatabase);

            //Start Execution
            ExtentManager.CreateTest(Constants.InsertDataFromDatabase);
            try
            {
                DatabaseUtility.InsertDataFromDatabase();
                Logs.Info("Test case passed successfully");
            }
            catch (Exception ex)
            {
                CommonActions.TestFailed(Constants.InsertDataFromDatabase, ex);
                Logs.Fail("Test case failed");
                throw ex;
            }
        }



        [TearDown]
        //End of Execution
        public void Close()
        {
            Logs.EndTestCase();           
            Logs.Info("Browser is closed successfully");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Logs.EndExecution();
            Extent.Flush();
        }
    }
}

