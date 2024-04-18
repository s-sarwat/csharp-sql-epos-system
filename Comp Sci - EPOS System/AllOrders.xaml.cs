using Comp_Sci___EPOS_System.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AllOrders.xaml
    /// </summary>
    public partial class AllOrders : Window
    {
        public AllOrders()
        {
            InitializeComponent();
            string queryString = $"SELECT * FROM [Order] INNER JOIN [OrderDetail]";

            DataTable dataTable = DBHelper.GetRows2(queryString);
            OrdersDataGrid.ItemsSource = dataTable.DefaultView;
        }


    }
}
