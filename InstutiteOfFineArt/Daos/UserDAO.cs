using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstutiteOfFineArt.Models;
using System.Data.SqlClient;
using System.Data;

namespace InstutiteOfFineArt.Daos
{
    public class UserDAO
    {
        public static DataTable All()
        {
            DataTable dt = new DataTable();
            string sql = "Select * from Users order by Id desc";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }

        public static DataTable Find(int Id)
        {
            DataTable dt = new DataTable();
            string sql = "Select * from Users where Id = @Id";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.SelectCommand.Parameters.AddWithValue("@Id", Id);
            adap.Fill(dt);
            return dt;
        }

        public static DataTable Where(Dictionary<string, string> query)
        {
            DataTable dt = new DataTable();
            string sql = "Select * from Users where ";
            int i = 1;
            foreach (var item in query)
            {
                if (i < query.Count)
                    sql += String.Format("{0} = {1} and ", item.Key, item.Value);
                else
                    sql += String.Format("{0} = {1}", item.Key, item.Value);
            }
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
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
                DBUtilities.CloseConnection();
            }
        }

        public static bool Update(User u)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Update Users set Username = @1,Password = @2,Email = @3,Name = @4,Address = @5,Gender = @6,Birthday = @7,";
                sql += "Phone = @8,Permission = @9 where Id = @10";
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
                cmd.Parameters.AddWithValue("@10", u.Id);
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
                DBUtilities.CloseConnection();
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
                DBUtilities.CloseConnection();
            }
        }
    }
}