using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using InstutiteOfFineArt.Models;

namespace InstutiteOfFineArt.Codes
{
    public class DBUtilities
    {
        public static string connStr = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public static SqlConnection objConnection;
            
        public static void Connection()
        {
            objConnection = new SqlConnection(connStr);
            objConnection.Open();
            if (objConnection.State != ConnectionState.Open)
            {
                return;
            }
        }

        public static void Close_Connection()
        {
            if (objConnection == null)
                return;
            if (objConnection.State != ConnectionState.Open)
                return;
            objConnection.Close();
            objConnection.Dispose();
        }
    }
}