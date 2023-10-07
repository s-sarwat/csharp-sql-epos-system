using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using Comp_Sci___EPOS_System.Helpers;

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

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            string id = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (id.Replace(" ", "").Length != 4)
            {
                MessageBox.Show("Please enter valid Staff ID.");
                return;
            }

            

            if (id == "" || password == "")
            {
                MessageBox.Show("Please enter Staff ID and password.");
                return;
            }


            string query = $"SELECT * FROM Users WHERE ID = {id} AND Password = '{password}'";

            DataRowCollection drc = DBHelper.GetRows(query);

            if (drc.Count > 0)
            {
                this.Hide();
                Home homescreen = new();
                homescreen.Show();
            }
            else
            {
                MessageBox.Show("Invalid user or password. Please try again.");
                return;
            }










        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) || (e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }
    }
}



