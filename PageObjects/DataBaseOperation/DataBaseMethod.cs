using MFG_Atomation.DatabaseOperation;
using MFG_Automation.Generics;
using MySql.Data.MySqlClient;
using System;
using static NUnit.Core.NUnitFramework;

namespace MFG_Atomation.PageObjects.DataBaseOperation
{
   public class DataBaseMethod
    {
        public DataBaseCommonMethod dataBaseCommonMethod;
         Helper helper = new Helper();


        /// <summary>
        /// Retrive Data From Database
        /// </summary>
        public void RetriveDataFromDatabase()
        {
            try
            {
                dataBaseCommonMethod = new DataBaseCommonMethod();

                MySqlConnection con = new MySqlConnection(DataBaseCommonMethod.constring);
                con.Open();
                string query = "Select * from employee";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Logs.Info(reader[0] + " -- " + reader[1] + " -- " + reader[2]+ " -- " + reader[3]);
                   

                }

                Assert.AreEqual("All", "false");
              
               
            }
            catch(Exception e)
            {
                Logs.Fail("Value not Retrive");
            }
        }



        /// <summary>
        /// Retrive Data From Database
        /// </summary>
        public void InsertDataFromDatabase(int Studentid,string firstName,string lastName,int age)
        {
            try
            {
                dataBaseCommonMethod = new DataBaseCommonMethod();

                MySqlConnection con = new MySqlConnection(DataBaseCommonMethod.constring);
                con.Open();
                string query = "INSERT INTO `recordcompany`.`employee`(`Student ID`,`FirstName`,`LastName`,`Age`)VALUES('"+Studentid+"', '"+firstName+"', '"+lastName+"', '"+age+"'); ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
           
            }
            catch (Exception e)
            {
                Logs.Fail("Value not Retrive");
            }
        }


    }
}
