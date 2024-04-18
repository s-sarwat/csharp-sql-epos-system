using System.Windows;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for SettingsMenu.xaml
    /// </summary>
    public partial class SettingsMenu : Window
    {
        public SettingsMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home home = new Home();
            home.Show();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AllCustomers allCustomers = new AllCustomers();
            allCustomers.Show();
        }
    }
}
