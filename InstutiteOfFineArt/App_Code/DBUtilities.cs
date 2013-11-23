using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using InstutiteOfFineArt.Models;
using System.Reflection;

namespace InstutiteOfFineArt
{
    public class DBUtilities
    {
        private static string connStr = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public static SqlConnection objConnection = new SqlConnection(connStr);

        public static void Connection()
        {
            objConnection.Open();
            if (objConnection.State != ConnectionState.Open)
            {
                return;
            }
        }

        public static void CloseConnection()
        {
            if (objConnection == null)
                return;
            if (objConnection.State != ConnectionState.Open)
                return;
            objConnection.Close();
            objConnection.Dispose();
        }

        public static string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }
    }
}