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
    public class CompetitionDAO
    {
        public DataTable All()
        {

            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Competitions] order by Id desc";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.Fill(dt);
            return dt;
        }

        public Competition Find(int id)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Competitions] order by Id desc WHERE Id = @1";
            SqlDataAdapter adap = new SqlDataAdapter(sql, DBUtilities.objConnection);
            adap.SelectCommand.Parameters.AddWithValue("@1", id);
            adap.Fill(dt);
            if (dt.Rows.Count > 0) {
                Competition c = new Competition();
                c.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                c.StaffId = Convert.ToInt32(dt.Rows[0]["StaffId"]);
                c.Topic = dt.Rows[0]["Topic"].ToString();
                c.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]);
                c.DueDate = Convert.ToDateTime(dt.Rows[0]["DueDate"]);
                c.CompetitionDescription = dt.Rows[0]["CompetitionDescription"].ToString();
                c.Condition = dt.Rows[0]["Condition"].ToString();
                c.Remark = dt.Rows[0]["Remark"].ToString();
                return c;
            }
            return null;
        }

        public Competition Where(Dictionary<string, object> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Competitions] where ";
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
            if (dt.Rows.Count > 0)
            {
                Competition c = new Competition();
                c.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                c.StaffId = Convert.ToInt32(dt.Rows[0]["StaffId"]);
                c.Topic = dt.Rows[0]["Topic"].ToString();
                c.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]);
                c.DueDate = Convert.ToDateTime(dt.Rows[0]["DueDate"]);
                c.CompetitionDescription = dt.Rows[0]["CompetitionDescription"].ToString();
                c.Condition = dt.Rows[0]["Condition"].ToString();
                c.Remark = dt.Rows[0]["Remark"].ToString();
                return c;
            }
            return null;
        }
        public DataTable Search(List<string> query)
        {
            DBUtilities.objConnection = new SqlConnection(DBUtilities.connStr);
            DataTable dt = new DataTable();
            string sql = "Select * from [Competitions] where ";
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


        public bool Create(Competition c)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "INSERT INTO [Competitions] (StaffId,Topic,StartDate,DueDate,Description,Condition,Remark)";
                sql += "VALUES (@1,@2,@3,@4,@5,@6,@7)";
                SqlCommand cmd = new SqlCommand(sql, DBUtilities.objConnection);
                cmd.Parameters.AddWithValue("@1", c.StaffId);
                cmd.Parameters.AddWithValue("@2", c.Topic);
                cmd.Parameters.AddWithValue("@3", c.StartDate);
                cmd.Parameters.AddWithValue("@4", c.DueDate);
                cmd.Parameters.AddWithValue("@5", c.CompetitionDescription);
                cmd.Parameters.AddWithValue("@6", c.Condition);
                cmd.Parameters.AddWithValue("@7", c.Remark);
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

        public bool Update(Competition c)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "Update [Competitions] set ";
                Type myType = c.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                int i = 1;
                int j = 1;
                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(c, null);
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
                    object propValue = prop.GetValue(c, null);
                    if (propValue != null && prop.Name != "Id")
                    {
                        if (j < props.Count)
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                        else
                        {
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i), propValue);
                            cmd.Parameters.AddWithValue(String.Format("@{0}", i + 1), c.Id);
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

        public bool Destroy(Competition c)
        {
            DBUtilities.Connection();
            try
            {
                string sql = "DELETE FROM [Competitions] WHERE Id = @1";
                SqlCommand comand = DBUtilities.objConnection.CreateCommand();
                comand.CommandText = sql;
                comand.Parameters.AddWithValue("@1", c.Id);
                comand.ExecuteNonQuery();
                comand.Dispose();
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