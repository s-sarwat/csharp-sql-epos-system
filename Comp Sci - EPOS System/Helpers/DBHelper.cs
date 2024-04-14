using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;

namespace Comp_Sci___EPOS_System.Helpers
{
    public static class DBHelper
    {
        public static DataRowCollection GetRows(string query)
        {
            string connection = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";

            using (SqlConnection c = new(connection))
            {
                c.Open();

                SqlCommand cmd = new(query);

                SqlDataAdapter sda = new(query, connection);

                DataTable dtable = new();
                sda.Fill(dtable);

                c.Close();

                return dtable.Rows;

            }

        }
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