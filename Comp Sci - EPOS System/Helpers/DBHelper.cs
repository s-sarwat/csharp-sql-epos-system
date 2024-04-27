using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;

namespace Comp_Sci___EPOS_System.Helpers
{
    public static class DBHelper
    {
        // Return a single row based on SQL query
        public static DataRow GetRow(string query)
        {
            // Create a connection to the database
            string connection = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";
            DataRow dataRow = null;

            using (SqlConnection c = new(connection))
            {
                SqlCommand cmd = new(query);
                SqlDataAdapter sda = new(query, connection);
                DataTable dtable = new();
                sda.Fill(dtable);

                if (dtable != null && dtable.Rows.Count > 0)
                {
                    dataRow = dtable.Rows[0];
                }
            }

            return dataRow;
        }

        // Return rows of data based on SQL query
        public static DataRowCollection GetRows(string query)
        {
            // Create a connection to the database
            string connection = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";

            using (SqlConnection c = new(connection))
            {
                SqlCommand cmd = new(query);
                SqlDataAdapter sda = new(query, connection);
                DataTable dtable = new();
                sda.Fill(dtable);

                // Return the rows of data
                return dtable.Rows;

            }

        }

        // Returns a data table based on SQL query
        public static DataTable GetRows2(string queryString)
        {
            string connectionString = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Executes the passed in query
        public static int ExecuteQuery(string queryString)
        {
            string connectionString = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }

        }

        // Executes the passed in query and return the identity
        public static int ExecuteScalar(string queryString)
        {
            string connectionString = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";

            using (SqlConnection connection = new(connectionString))
            {
                queryString = queryString + "; SELECT SCOPE_IDENTITY()";
                SqlCommand command = new(queryString, connection);
                command.Connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }

        }
    }
}