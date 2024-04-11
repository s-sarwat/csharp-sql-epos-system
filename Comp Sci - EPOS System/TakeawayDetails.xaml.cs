using System;
using System.Collections.Generic;
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
    /// Interaction logic for TakeawayDetails.xaml
    /// </summary>
    public partial class TakeawayDetails : Window
    {
        public TakeawayDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Code for "cancel" button which takes user back to main menu.
            Hide();
            Home home = new Home();
            home.Show();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = FirstName_Box.Text;
            string LastName = LastName_Box.Text;
            string Email = Email_Box.Text;
            string Phone = Phone_Box.Text;
            string Instructions = Instructions_Box.Text;

            if (FirstName.Length == 0 || LastName.Length == 0)
            {
                MessageBox.Show("Please enter both first & last name.");
                return;
            }

            if (Email.Length == 0)
            {
                MessageBox.Show("An email address is required. Please enter one.");
                return;
            }

            if (!Email.Contains("@"))
            {
                MessageBox.Show("The email you have entered is invalid. Please try again.");
                return;
            }

            if (Phone.Length != 11)
            {
                MessageBox.Show("Phone number must be exactly 11 digits long.");
                return;
            }


            Hide();
            OrderMenu menu = new OrderMenu();
            menu.Show();
        }


    }
}
