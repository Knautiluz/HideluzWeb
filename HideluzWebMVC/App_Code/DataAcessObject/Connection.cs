using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

/// <summary>
/// Descrição resumida de Connection
/// </summary>
namespace HideluzWebMVC.DAO
{
    public class Connection
    {
        protected MySqlConnection DataConnection { get; set; }

        protected void OpenDatabase()
        {
            string connectionString = "Server=hideluz-web.mysql.uhserver.com;Database=hideluz_web;Uid=hideluz;Pwd=SwordMaster@10;";
            using (DataConnection = new MySqlConnection(connectionString))
            {
                DataConnection.Open();
            }
        }
        protected void CloseDatabase()
        {
            try
            {
                DataConnection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected int ExecuteNonQuery(string sql)
        {
            var cmd = PrepareQuery(sql);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        protected List<object> ExecuteQuery(string sql)
        {
            var cmd = PrepareQuery(sql);
            var reader = cmd.ExecuteReader();
            var table = reader.GetSchemaTable();
            var columns = table.Rows.Count;
            List<string> Result;
            List<object> Results = new List<object>();
            while (reader.Read())
            {
                Result = new List<string>();
                for (int i = 0; i < columns; i++)
                {
                    var data = reader.GetString(i);
                    Result.Add(data);
                }
                Results.Add(Result);
            }
            return Results;
        }
        protected int ExecuteScalar(string sql)
        {
            var cmd = PrepareQuery(sql);

            try
            {
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }
        private MySqlCommand PrepareQuery(string sql)
        {
            var cmd = DataConnection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection.Open();
            return cmd;
        }
    }
}