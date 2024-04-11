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
        public Button[] buttonsArray;
        public int tableNumber;
        public TableSelection()
        {
            InitializeComponent();

            buttonsArray = new Button[] { Table1, Table2, Table3, Table4, Table5, Table6, Table7, Table8, Table9 };

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int tableNumber = Array.IndexOf(buttonsArray, clickedButton) + 1;
                Hide();
                CreateBooking bookingcreation = new();
                bookingcreation.Show();
            }
        }
    }
}
