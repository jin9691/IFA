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
    public class PaintingDAO
    {
        public static DataTable All()
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            string sql = "SELECT * FROM [Paintings]";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }
        public static Painting Find(int id)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Paintings where Id = @Id";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.SelectCommand.Parameters.AddWithValue("@Id", id);
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Painting p = new Painting();
                p.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                p.PaintingDescription = dt.Rows[0]["PaintingDescription"].ToString();
                p.PaintingURL = dt.Rows[0]["PaintingURL"].ToString();
                p.Mark = Convert.ToInt32(dt.Rows[0]["Mark"]);
                p.UploadDate = Convert.ToDateTime(dt.Rows[0]["UploadDate"]);
                p.LastModify = Convert.ToDateTime(dt.Rows[0]["LastModify"]);
                p.CompetitionId = Convert.ToInt32(dt.Rows[0]["CompetitionId"]);
                p.StudentId = Convert.ToInt32(dt.Rows[0]["StudentId"]);
                p.ExhibitionId = Convert.ToInt32(dt.Rows[0]["ExhibitionId"]);
                p.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                p.Comment = dt.Rows[0]["Comment"].ToString();
                p.IsExhibited = Convert.ToBoolean(dt.Rows[0]["IsExhibited"]);
                p.Price = Convert.ToInt32(dt.Rows[0]["Price"]);
                p.IsPaid = p.IsExhibited = Convert.ToBoolean(dt.Rows[0]["IsPaid"]);
                return p;
            }
            return null;

        }
        public static DataTable Where(Dictionary<string, object> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Paintings where ";
            int i = 1;
            foreach (var item in query)
            {
                if (i < query.Count)
                    sql += String.Format("{0} = @{1} and ", item.Key, i);
                else
                    sql += String.Format("{0} = {1}", item.Key, item.Value);
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

        public static DataTable Search(Dictionary<string, string> query) 
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from Paintings where ";
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
        public static bool Create(Painting a)
        {

            DBUtilities.Connection();
            try
            {
                string sql = "Insert into Paintings (PaintingDescription,PaintingURL,Mark,UploadDate,LastModify,CompetitionId,StudentId,ExhibitionId,CustomerId,Comment,IsExhibited,Price,IsPaid)";
                sql += " values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1", a.PaintingDescription);
                cmd.Parameters.AddWithValue("@2", a.PaintingURL);
                cmd.Parameters.AddWithValue("@3", a.Mark);
                cmd.Parameters.AddWithValue("@4", a.UploadDate);
                cmd.Parameters.AddWithValue("@5", a.LastModify);
                cmd.Parameters.AddWithValue("@6", a.CompetitionId);
                cmd.Parameters.AddWithValue("@7", a.StudentId);
                cmd.Parameters.AddWithValue("@8", a.ExhibitionId);
                cmd.Parameters.AddWithValue("@9", a.CustomerId);
                cmd.Parameters.AddWithValue("@10", a.Comment);
                cmd.Parameters.AddWithValue("@11", a.IsExhibited);
                cmd.Parameters.AddWithValue("@12", a.Price);
                cmd.Parameters.AddWithValue("@13", a.IsPaid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
            finally
            {
                DBUtilities.Close_Connection();
            }
        }
        public static bool Update(Painting a)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Update Paintings set ";
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
        public static bool Destroy(Painting a)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Delete from Paintings where Id = @1";
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