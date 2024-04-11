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
    /// Interaction logic for BookingConfo.xaml
    /// </summary>
    public partial class BookingConfo : Window
    {
        public BookingConfo()
        {
            InitializeComponent();
        }


        public void SetTime(string time)
        {
            txtTimeCompleted.Text = time;
        }

        

        //public void DisplaySystemTime()
        //{
        //    DateTime currentTime = DateTime.Now;
        //    txtTimeCompleted.Text = currentTime.ToString("HH:mm:ss");
        //}

        //internal void DisplayWindowTime()
        //{
        //    throw new NotImplementedException();
        //}


    }
}
