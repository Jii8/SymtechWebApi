using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SymtechBankApi
{
    [Obsolete]
    public class DbHelper
    {
        // Moved connection string to web.config
        //private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SymtechBank.mdf;Integrated Security=True;Connect Timeout=30";
        // Note: Not using the class. However not removed.
        public static SqlConnection NewConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SymtechBankApiDbConnection"].ConnectionString);
        }
    }
}