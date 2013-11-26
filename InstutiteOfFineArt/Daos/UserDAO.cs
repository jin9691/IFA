using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstutiteOfFineArt.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using InstutiteOfFineArt.Codes;

namespace InstutiteOfFineArt.Daos
{
    public class UserDAO
    {
        public static DataTable All()
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Users order by Id desc";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }

        public static User Find(int Id)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Users where Id = @Id";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.SelectCommand.Parameters.AddWithValue("@Id", Id);
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                User u = new User();
                u.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                u.Name = dt.Rows[0]["Name"].ToString();
                u.Username = dt.Rows[0]["Username"].ToString();
                u.Email = dt.Rows[0]["Email"].ToString();
                u.Gender = bool.Parse(dt.Rows[0]["Gender"].ToString());
                u.Birthday = DateTime.Parse(dt.Rows[0]["Birthday"].ToString());
                u.Address = dt.Rows[0]["Address"].ToString();
                u.Phone = dt.Rows[0]["Phone"].ToString();
                u.Permission = Convert.ToInt32(dt.Rows[0]["Permission"].ToString());
                return u;
            }
            return null;
        }

        public static DataTable Where(Dictionary<string, object> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Users where ";
            int i = 1;
            foreach (var item in query)
            {
                if (i < query.Count)
                    sql += String.Format("{0} = @{1} and ", item.Key, i);
                else
                    sql += String.Format("{0} = @{1}", item.Key, i);
                i++;
            }
            i = 1;
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            foreach (var item in query)
            {
                adap.SelectCommand.Parameters.AddWithValue("@" + i, item.Value);
                i++;
            }
            adap.Fill(dt);
            return dt;
        }

        public static DataTable Search(List<string> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Users where ";
            int i = 1;
            foreach (var item in query)
            {
                if (i < query.Count)
                    sql += String.Format("{0} or ", item);
                else
                    sql += String.Format("{0} order by Id desc", item);
                i++;
            }
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }

        public static bool Create(User u)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Insert into Users (Username,Password,Email,Name,Address,Gender,Birthday,Phone,Permission)";
                sql += " values (@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1", u.Username);
                cmd.Parameters.AddWithValue("@2", u.Password);
                cmd.Parameters.AddWithValue("@3", u.Email);
                cmd.Parameters.AddWithValue("@4", u.Name);
                cmd.Parameters.AddWithValue("@5", u.Address);
                cmd.Parameters.AddWithValue("@6", u.Gender);
                cmd.Parameters.AddWithValue("@7", u.Birthday);
                cmd.Parameters.AddWithValue("@8", u.Phone);
                cmd.Parameters.AddWithValue("@9", u.Permission);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DBUtilities.Close_Connection();
            }
        }

        public static bool Update(User u)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Update Users set ";
                Type myType = u.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                int i = 1;
                int j = 1;
                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(u, null);
                    if (propValue != null && prop.Name != "Id")
                    {
                        if (j < props.Count)
                            sql += String.Format("{0} = @{1} ,", prop.Name, i);
                        else
                            sql += String.Format("{0} = @{1} where ID= @{2}", prop.Name, i, i + 1);
                        i++;
                    }
                    j++;
                }
                i = 1;
                j = 1;
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(u, null);
                    if (propValue != null && prop.Name != "Id")
                    {
                        if (j < props.Count)
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                        else
                        {
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i + 1), u.Id);
                        }
                        i++;
                    }
                    j++;
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DBUtilities.Close_Connection();
            }
        }

        public static bool Destroy(User u)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Delete from Users where Id = @1";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1", u.Id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DBUtilities.Close_Connection();
            }
        }
    }
}