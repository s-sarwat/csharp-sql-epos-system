using System.Data;
using System.Data.SqlClient;

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
        public static void ExecuteQuery(string queryString)
        {
            string connectionString = @"Data Source=SARWAT-LENOVO\SQLEXPRESS;Initial Catalog=CSProject;Integrated Security=True";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}