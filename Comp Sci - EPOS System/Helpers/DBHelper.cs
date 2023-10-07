using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
