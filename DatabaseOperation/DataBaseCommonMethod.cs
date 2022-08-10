using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFG_Atomation.DatabaseOperation
{
    public class DataBaseCommonMethod
    {
        public static string server = "localhost";
        public static string database = "recordCompany";
        public static string userName = "root";
        public static string passWord = "root";
        public static int Port = 3306;

        public static string constring = "server=" + server + ";user=" + userName + "; database=" + database + "; port=" + Port + ";password=" + passWord + ";";

    }
}
