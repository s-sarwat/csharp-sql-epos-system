using Comp_Sci___EPOS_System.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for CreateBooking.xaml
    /// </summary>
    public partial class CreateBooking : Window
    {
        public CreateBooking()
        {
            InitializeComponent();
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "E.g. Baby highchair, Window table, etc.")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "E.g. Baby highchair, Window table, etc.";
                tb.Foreground = Brushes.Gray;
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            BookingOptionBox bookingoptions = new BookingOptionBox();
            bookingoptions.Show();
        }

        public void continueBtn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = FirstName_Box.Text;
            string LastName = LastName_Box.Text;
            string Email = Email_Box.Text;
            string Phone = PhoneNum_Box.Text;
            var dateTime = SelectDate.DisplayDate.Date.ToShortDateString();
            string bookingTime = TimeSlot_Box.Text;
            int PartySize = NoGuests_Box.Text.Length;
            int tableNumber = TableSelector.Text.Length;
            string Instructions = Instructions_Box.Text;


            if (FirstName.Length == 0 || LastName.Length == 0)
            {
                MessageBox.Show("Please enter both first & last name.");
                return;
            }

            if (Email.Length == 0 || !Email.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (Phone.Length == 0)
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }


            if (Phone.Length != 11)
            {
                MessageBoxResult result = MessageBox.Show("Phone number should be 11 digits long. Do you wish to continue with the entered number?", "Invalid input", MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (result != MessageBoxResult.Yes)
                {
                    PhoneNum_Box.Focus();
                    return;
                }

            }

            if (dateTime == "")
            {
                MessageBox.Show("Please enter a valid booking date.");
                return;
            }

            if (SelectDate.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please select a date that is not in the past.");
                return;
            }



            if (bookingTime.Length == 0)
            {
                MessageBox.Show("Please select a booking time.");
                return;
            }

            if (PartySize == 0)
            {
                MessageBox.Show("Please select the number of guests.");
                return;
            }

            if (tableNumber == 0)
            {
                MessageBox.Show("Please select a table for the booking.");
                return;
            }


            string query = $@"INSERT INTO [dbo].[Bookings]
                                ([BookingFirstName],
                                [BookingLastName],
                                [BookingEmail],
                                [BookingPhone],
                                [BookingDate],
                                [BookingTime],
                                [BookingGuests],
                                [BookingInstructions])
                                VALUES ('{FirstName}', '{LastName}', '{Email}', '{Phone}', '{dateTime}', '{bookingTime}', '{PartySize}', '{Instructions}')";

            DBHelper.ExecuteQuery(query);

            //Hide();
            //BookingConfo bookingconfirmation = new();
            //bookingconfirmation.DisplayWindowTime();
            //bookingconfirmation.Show();

            Hide();
            BookingConfo bookingconfirmation = new();
            bookingconfirmation.SetTime(DateTime.Now.ToString("HH:mm:ss"));
            bookingconfirmation.Show();

        }
    }
}
