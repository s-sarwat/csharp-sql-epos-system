using Comp_Sci___EPOS_System.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : Window
    {
        public string OrderType { get; set; }

        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
            //Home home = new Home();
            //home.Show();


            FirstName_Box.Text = "Sarwat";
            LastName_Box.Text = "S";
            Email_Box.Text = "s@gh.com";
            Phone_Box.Text = "07777777777";
            Address_Box.Text = "ssss";
            City_Box.Text = "ddd";
            Postcode_Box.Text = "SE153WQ";

        }

        private void Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            string FirstName = FirstName_Box.Text;
            string LastName = LastName_Box.Text;
            string Email = Email_Box.Text;
            string Phone = Phone_Box.Text;
            string Address = Address_Box.Text;
            string City = City_Box.Text;
            string Postcode = Postcode_Box.Text;
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

            if (Address.Length == 0)
            {
                MessageBox.Show("Please enter an address.");
                return;
            }

            if (City.Length == 0)
            {
                MessageBox.Show("Please enter the city.");
                return;
            }

            if (Postcode.Length > 7 || Postcode.Length < 5)
            {
                MessageBox.Show("Please enter a valid postcode.");
                return;
            }

            bool postcode_check = false;

            if (char.IsLetter(Postcode[Postcode.Length -2]) && 
                char.IsLetter(Postcode[Postcode.Length - 1]) && 
                char.IsDigit(Postcode[Postcode.Length -3]) &&
                char.IsLetter(Postcode[0]))
            {
                postcode_check = true;
            }
            
            else
            {
                MessageBox.Show("The format of the postcode is incorrect.");
                postcode_check = false;
                return;
                
            }



            if (Phone.Length != 11)
            {
                MessageBox.Show("Phone number must be exactly 11 digits long.");
                return;
            }

            if (postcode_check == true)
            {
                Customer customer = new Customer();
                customer.FirstName = FirstName;
                customer.LastName = LastName;
                customer.Email = Email;
                customer.Address = Address;
                customer.Phone = Phone;
                customer.City = City;
                customer.Postcode = Postcode;   
                customer.Instructions = Instructions;

                Hide();
                OrderMenu menu = new OrderMenu(customer);
                menu.OrderType = OrderType;
                menu.Show();
            }
            
        }
    }
}
