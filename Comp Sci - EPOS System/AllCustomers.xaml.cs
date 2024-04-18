using Comp_Sci___EPOS_System.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for AllCustomers.xaml
    /// </summary>
    public partial class AllCustomers : Window
    {
        DataTable CustomerTable;
        public AllCustomers()
        {
            InitializeComponent();

            string queryString = $"SELECT * FROM [Customer]";

            CustomerTable = DBHelper.GetRows2(queryString);
            CustomersDataGrid.ItemsSource = CustomerTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CustomersDataGrid.SelectedItem;
                CustomerTable.Rows.Remove(row.Row);
            }
        }
    }
}
