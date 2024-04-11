using System.Windows;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for BookingOptionBox.xaml
    /// </summary>
    public partial class BookingOptionBox : Window
    {
        public BookingOptionBox()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home home = new Home();
            home.Show();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            CreateBooking createbooking = new CreateBooking();
            createbooking.Show();
        }
    }
}
