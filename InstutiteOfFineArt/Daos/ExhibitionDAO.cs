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
    public class ExhibitionDAO
    {
        public static DataTable All()
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Exhibitions] order by Id desc";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }

        public static Exhibition Find(int Id)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Exhibitions] where Id = @Id";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.SelectCommand.Parameters.AddWithValue("@Id", Id);
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Exhibition e = new Exhibition();
                e.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                e.ManagerId = Convert.ToInt32(dt.Rows[0]["ManagerId"]);
                e.ExhibitionName = dt.Rows[0]["ExhibitionName"].ToString();
                e.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]);
                e.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]);
                e.ExhibitionDescription = dt.Rows[0]["ExhibitionName"].ToString();
                return e;
            }
            return null;
        }

        public static DataTable WHERE(Dictionary<string, object> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Exhibitions] where ";
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

        public static DataTable Search(List<string> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Exhibitions] where ";
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
        public static bool Create(Exhibition e)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Insert into [Exhibitions] (Name,ManagerId,StartDate,EndDate,Description)";
                sql += " values (@1,@2,@3,@4,@5)";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1",e.ExhibitionName);
                cmd.Parameters.AddWithValue("@2", e.ManagerId);
                cmd.Parameters.AddWithValue("@3", e.StartDate);
                cmd.Parameters.AddWithValue("@4", e.EndDate);
                cmd.Parameters.AddWithValue("@5", e.ExhibitionDescription);
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

        public static bool Update(Exhibition e)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Update [Exhibitions] set ";
                Type myType = e.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                int i = 1;
                int j = 1;
                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(e, null);
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
                    object propValue = prop.GetValue(e, null);
                    if (propValue != null && prop.Name != "Id")
                    {
                        if (j < props.Count)
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                        else
                        {
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i + 1), e.Id);
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

        public static bool Destroy(Exhibition u)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Delete from [Exhibitions] where Id = @1";
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