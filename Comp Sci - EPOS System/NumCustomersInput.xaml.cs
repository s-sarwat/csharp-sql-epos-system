using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NumCustomersInput.xaml
    /// </summary>
    public partial class NumCustomersInput : Window
    {
        public int NumCustomers { get; set; }
        public NumCustomersInput()
        {
            InitializeComponent();
        }

        private void txtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomerNum.Text.Length == 0)
            {
                MessageBox.Show("Please enter the number of customers.");
                return;
            }


            NumCustomers = int.Parse(txtCustomerNum.Text.ToString());

            if (NumCustomers > 8)
            {
                MessageBox.Show("The number of customers you have entered is above the maximum allowed.");
                return;
            }

            if (NumCustomers < 1)
            {
                MessageBox.Show("The number of customers you have entered is not valid.");
                return;
            }
            this.Hide();
        }
    }
}
