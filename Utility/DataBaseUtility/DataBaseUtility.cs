using MFG_Atomation.PageObjects.BlackListing;
using MFG_Atomation.PageObjects.DataBaseOperation;
using MFG_Automation.Generics;
using MFGAutomation.Generics;
using NUnit.Framework;
using System;

namespace MFG_Atomation.Utility.BlackListing
{
    public static  class DatabaseUtility
    {
       
        public static DataBaseMethod dataBaseMethod;
       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetName">provide sheetname</param>
        public static void RetriveDataFromDatabase()
        {
       
            try
            {
                //object creation
                dataBaseMethod = new DataBaseMethod();
                dataBaseMethod.RetriveDataFromDatabase();

            }
            catch (Exception ex)
            {
                CommonActions.TestFailed(Constants.RetriveDataFromDatabase, ex);
                Logs.Fail("Test case failed");
                throw ex;
            }
        }


        /// <summary>
        /// Insert Data From Database
        /// </summary>
        /// <param name="sheetName">provide sheetname</param>
        public static void InsertDataFromDatabase()
        {

            try
            {
                Random ran = new Random();
                int Studentid = ran.Next();
                string FirstName = "Test";
                String LastName = "User";
                int age = 30;
                //object creation
                dataBaseMethod = new DataBaseMethod();
                dataBaseMethod.InsertDataFromDatabase(Studentid, FirstName, LastName, age);
                
            }
            catch (Exception ex)
            {
                CommonActions.TestFailed(Constants.RetriveDataFromDatabase, ex);
                Logs.Fail("Test case failed");
                throw ex;
            }
        }

    }
}

