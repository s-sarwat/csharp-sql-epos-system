using System.Windows;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ShowLogin(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow LoginWindow = new();
            LoginWindow.Show();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            SettingsMenu settings = new SettingsMenu();
            settings.Show();

        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            CustomerDetails delivery = new CustomerDetails();
            delivery.OrderType = "Delivery";
            delivery.Show();
        }

        private void btnBookings_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            BookingOptionBox bookingoptions = new BookingOptionBox();
            bookingoptions.Show();
        }

        private void btnTakeaway_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            TakeawayDetails takeaway = new TakeawayDetails();
            takeaway.OrderType = "Takeaway";
            takeaway.Show();
        }

        private void btnEatIn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            TableSelection tableSelection = new TableSelection();
            tableSelection.OrderType = "EatIn";
            tableSelection.Show();

        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AllOrders allOrders = new AllOrders();
            allOrders.Show();
        }
    }
}
