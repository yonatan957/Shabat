using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabat.DAL
{
    internal class DBconnections
    {
        private string _connectionString {  get; init; }

        public DBconnections(string conn)
        {
            if (string.IsNullOrEmpty(conn))
                throw new ArgumentNullException(nameof(conn));
            _connectionString = conn;
        }
        private void CheckConnection()
        {
            // Try to connect to the database and execute a simple query
            DataTable result = ExecuteQuery("SELECT 1+1 AS test", null!);
            if (Convert.ToInt32(result.Rows[0][0]) != 2)
                throw new Exception("Failed to connect to the database.");
        }
        public int ExecuteNoneQuery(string query, SqlParameter[] parameters) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("An error occurred:" + ex.Message);
                        return -1;
                    }
                }
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if ( parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("An error occurred:" + ex.Message);
                    }
                }
            }
            return dt;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the command.
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"General Error: {ex.Message}");
                    }

                    return null;
                }
            }
        }

        private string SqlEscape(string input)
        {
            // Simple SQL escape method to avoid basic SQL injection
            return input.Replace("'", "''");
        }
        public void CheckConnectionToDefaultDB(string dbName)
        {
            CheckConnection();
            // Construct the query to check for the existence of the database by name in the system catalog
            string query = $"SELECT db_id('{SqlEscape(dbName)}');";

            DataTable result = ExecuteQuery(query, null!);
            if (result == null || result.Rows.Count == 0 || result.Rows[0][0] == DBNull.Value)
                throw new Exception($"Database {dbName} is not defined.");
        }
    }
}
