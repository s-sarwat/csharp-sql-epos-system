using Comp_Sci___EPOS_System.Helpers;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)

        {
            string id = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Check if the length of the 'id' after removing spaces is not equal to 4
            if (id.Replace(" ", "").Length != 4)
            {
                MessageBox.Show("Please enter valid Staff ID.");
                return;
            }


            // Check if ID or password box are blank
            if (id == "" || password == "")
            {
                MessageBox.Show("Please enter Staff ID and password.");
                return;
            }

            // Construct a SQL query to retrieve data based on the provided 'id' and 'password'
            string query = $"SELECT * FROM Users WHERE ID = {id} AND Password = '{password}'";

            // Get the rows that match the query from the database using the DBHelper class
            DataRow dr = DBHelper.GetRow(query);

            // Check if username and password matched
            if (dr != null)
            {
                //MessageBox.Show("Correct"); // Display a message if details are correct.
                this.Hide(); // Hide the login form
                Home mainmenu = new();
                mainmenu.Show(); // Show the main menu
            }
            else
            {
                // If credentials are incorrect, display a message
                MessageBox.Show("Invalid user and/or password. Please try again.");
                return;
            }










        }

        // Check if the pressed key is not a number (0-9) or if it is the Space key
        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // If the condition is true, mark the event as handled to prevent the character from being entered
            if ((e.Key < Key.D0 || e.Key > Key.D9) || (e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}



