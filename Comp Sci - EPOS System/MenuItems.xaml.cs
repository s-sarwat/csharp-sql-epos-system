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
    /// Interaction logic for MenuItems.xaml
    /// </summary>
    public partial class MenuItems : Window
    {
        DataTable MenuTable;
        private int selectedID;
        public MenuItems()
        {
            InitializeComponent();

            string queryString = $"SELECT * FROM [Dish]";

            MenuTable = DBHelper.GetRows2(queryString);
            MenuDataGrid.ItemsSource = MenuTable.DefaultView;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this dish from the system? This action cannot be undone.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes && MenuDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)MenuDataGrid.SelectedItem;

                if (selectedRow != null)
                {
                    int selectedID = (int)selectedRow.Row["ID"];
                    MenuTable.Rows.Remove(selectedRow.Row);

                    string query = $@"DELETE FROM Dish
                                      WHERE ID = {selectedID}";

                    DBHelper.ExecuteQuery(query);
                    MessageBox.Show("The dish has successfully been deleted from the system.");
                }
            }
        }
    }
}
