using System;
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
            numCustomersInput.ShowDialog();
            int tableCustomers = numCustomersInput.NumCustomers;
            int tableNumber = int.Parse(button.Content.ToString());

            this.Hide();
            OrderMenu menu = new OrderMenu(tableNumber, tableCustomers);
            menu.OrderType = OrderType;
            menu.Show();


        }
    }
}
