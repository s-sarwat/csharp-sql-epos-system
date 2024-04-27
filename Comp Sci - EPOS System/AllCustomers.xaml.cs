using Comp_Sci___EPOS_System.Helpers;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Comp_Sci___EPOS_System
{
    public partial class AllCustomers : Window
    {
        DataTable CustomerTable;
        private int selectedID;

        public AllCustomers()
        {
            InitializeComponent();

            string queryString = $"SELECT * FROM [Customer]";

            CustomerTable = DBHelper.GetRows2(queryString);
            CustomersDataGrid.ItemsSource = CustomerTable.DefaultView;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer from the system? This action cannot be undone.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes && CustomersDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CustomersDataGrid.SelectedItem;

                if(selectedRow != null)  
                {
                    int selectedID = (int)selectedRow.Row["ID"];
                    CustomerTable.Rows.Remove(selectedRow.Row);

                    string query = $@"DELETE FROM Customer
                                      WHERE ID = { selectedID }";

                    DBHelper.ExecuteQuery(query);
                    MessageBox.Show("The customer has successfully been deleted from the system.");
                }
            }
        }

    }
}