using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace InstutiteOfFineArt.Daos
{
    public class AwardDAO
    {
        public static DataTable All()
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            string sql = "SELECT * FROM [Awards]";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql,DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }
       

        public static Award Find(int id)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Awards where Id = @Id";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.SelectCommand.Parameters.AddWithValue("@Id", id);
            adap.Fill(dt);
            if (dt.Rows.Count > 0) {
                Award a = new Award();
                a.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                a.AdwardName = dt.Rows[0]["AwardName"].ToString();
                a.AdwardRank = dt.Rows[0]["AwardRank"].ToString();
                a.AwardDescription = dt.Rows[0]["AwardDescription"].ToString();
                a.PaintingId = Convert.ToInt32(dt.Rows[0]["PaintingId"]);
                a.CompetitionId = Convert.ToInt32(dt.Rows[0]["CompetitionId"]);
                return a;
            }
            return null;

        }

        public static DataTable Where(Dictionary<string, object> query) 
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Awards where ";
            int i = 1;
            foreach (var item in query)
            {
                if (i < query.Count)
                    sql += String.Format("{0} = @{1} and ", item.Key, i);
                else
                    sql += String.Format("{0} = {1}", item.Key, i);
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

        public static DataTable Search(List<String> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Awards where ";
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

        public static bool Create(Award a)
        {

            DBUtilities.Connection();
            try
            {
                string sql = "Insert into Awards (AwardName,AwardRank,AwardDescription,PaintingId,CompetitionId)";
                sql += " values (@1,@2,@3,@4,@5)";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1", a.AdwardName);
                cmd.Parameters.AddWithValue("@2", a.AdwardRank);
                cmd.Parameters.AddWithValue("@3", a.AwardDescription);
                cmd.Parameters.AddWithValue("@4", a.PaintingId);
                cmd.Parameters.AddWithValue("@5", a.CompetitionId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {                
                return false;
            }
            finally
            {
                DBUtilities.Close_Connection();
            }
        }
        public static bool Update(Award a)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Update Awards set ";
                Type myType = a.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                int i = 1;
                int j = 1;
                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(a, null);
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
                    object propValue = prop.GetValue(a, null);
                    if (propValue != null && prop.Name != "Id")
                    {
                        if (j < props.Count)
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                        else
                        {
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i + 1), a.Id);
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
        public static bool Destroy(Award a)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Delete from Awards where Id = @1";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1", a.Id);
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