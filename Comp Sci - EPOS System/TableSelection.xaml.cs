using System;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for TableSelection.xaml
    /// </summary>
    public partial class TableSelection : Window
    {
        public string OrderType { get; set; }
        public TableSelection()
        {
            InitializeComponent();
        }

        public void TableBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            NumCustomersInput numCustomersInput = new NumCustomersInput();
            numCustomersInput.ShowDialog(); // Displays pop up box for input
            int tableCustomers = numCustomersInput.NumCustomers;
            int tableNumber = int.Parse(button.Content.ToString());

            this.Hide(); // Hide the current window
            OrderMenu menu = new OrderMenu(tableNumber, tableCustomers);
            menu.OrderType = OrderType;
            menu.Show(); // Display the order menu window


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
