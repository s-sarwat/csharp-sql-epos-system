using Comp_Sci___EPOS_System.Helpers;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Comp_Sci___EPOS_System
{
    /// <summary>
    /// Interaction logic for OrderMenu.xaml
    /// </summary>
    public partial class OrderMenu : Window
    {
        public string OrderType { get; set; }

        private Customer customer;
        private Button[] buttons = new Button[18];
        private ObservableCollection<OrderItem> orderedItems;
        private decimal orderTotal;
        private int tableNumber;
        private int tableCustomers;

        public OrderMenu(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
            orderedItems = new();
            listOfItems.ItemsSource = orderedItems;
        }

        public OrderMenu(int tableNumber, int tableCustomers)
        {
            InitializeComponent();

            orderedItems = new();
            listOfItems.ItemsSource = orderedItems;
            this.tableNumber = tableNumber;
            this.tableCustomers = tableCustomers;
        }

        private void dishBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowDishes(sender as Button);
        }

        public void ShowDishes(Button button)
        {
            string groupName = button.Content.ToString();

            string query = "SELECT Dish.ID," +
                            "Dish.[Name],[Price]," +
                            "[GroupId]" +
                            "FROM[Dish]" +
                            "JOIN[Group]" +
                            "ON Dish.GroupId = [Group].Id " +
                            $"WHERE[Group].Name = '{groupName}'";

            DataRowCollection drc = DBHelper.GetRows(query);
            int count = drc.Count;
            buttons[0] = btnItem1;
            buttons[1] = btnItem2;
            buttons[2] = btnItem3;
            buttons[3] = btnItem4;
            buttons[4] = btnItem5;
            buttons[5] = btnItem6;
            buttons[6] = btnItem7;
            buttons[7] = btnItem8;
            buttons[8] = btnItem9;
            buttons[9] = btnItem10;
            buttons[10] = btnItem11;
            buttons[11] = btnItem12;
            buttons[12] = btnItem13;
            buttons[13] = btnItem14;
            buttons[14] = btnItem15;
            buttons[15] = btnItem16;
            buttons[16] = btnItem17;
            buttons[17] = btnItem18;

            // Hide buttons
            for (int i = 0; i < buttons.Count(); i++)
            {
                buttons[i].Content = "";
                buttons[i].Visibility = Visibility.Hidden;
            }

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    buttons[i].Content = drc[i]["Name"];
                    buttons[i].Tag = decimal.Parse(drc[i]["Price"].ToString());
                    buttons[i].Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("No items found from the chosen category.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home home = new Home();
            home.Show();
        }

        private void buttons_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string selectedItemName = button.Content.ToString();
            string selectedDishPrice = button.Tag.ToString();
            bool matchFound = false;

            // see if the selected dish is already in my list
            foreach (OrderItem item in orderedItems)
            {
                if (selectedItemName == item.Name)
                {
                    item.Qty++;
                    matchFound = true;
                    break;
                }
            }

            if (!matchFound)
            {
                OrderItem itemToAdd = new OrderItem();
                itemToAdd.Name = selectedItemName;
                itemToAdd.Qty = 1;
                itemToAdd.Price = decimal.Parse(selectedDishPrice);
                orderedItems.Add(itemToAdd);
            }

            listOfItems.Items.Refresh();
            UpdateOrderTotal();
        }

        private void UpdateOrderTotal()
        {
            orderTotal = 0;
            foreach (OrderItem item in orderedItems)
            {
                orderTotal += item.Qty * item.Price;
            }

            totalTextBlock.Text = "£" + orderTotal.ToString();
        }

        private void listOfItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listOfItems.SelectedItem != null)
            {
                deleteBtn.IsEnabled = true;
            }
            else
            {
                deleteBtn.IsEnabled = false;
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listOfItems.SelectedItem != null)
            {
                OrderItem itemToRemove = listOfItems.SelectedItem as OrderItem;
                orderedItems.Remove(itemToRemove);
                listOfItems.SelectedItem = null;
                deleteBtn.IsEnabled = false;
                UpdateOrderTotal();
            }
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {

            if (OrderType == "Delivery")
            {
                DeliveryAndTakeawayHandler();

            }
            else if (OrderType == "Takeaway")
            {
                DeliveryAndTakeawayHandler();

            }
            else if (OrderType == "EatIn")
            {
                TableHandler();
            }
        }

        private void DeliveryAndTakeawayHandler()
        {

            string query = "";

            if (OrderType == "Delivery")
            {
                query = $@"INSERT INTO [dbo].[Customer]
                                           ([FirstName]
                                           ,[LastName]
                                           ,[Email]
                                           ,[Address]
                                           ,[City]
                                           ,[Postcode]
                                           ,[PhoneNumber]
                                           ,[Instructions])
                                     VALUES
                                           ('{customer.FirstName}'
                                           ,'{customer.LastName}'
                                           ,'{customer.Email}'
                                           ,'{customer.Address}'
                                           ,'{customer.City}'
                                           ,'{customer.Postcode}'
                                           ,'{customer.Phone}'
                                           ,'{customer.Instructions}')";



            }
            else if (OrderType == "Takeaway")
            {
                query = $@"INSERT INTO [dbo].[Customer]
                                           ([FirstName]
                                           ,[LastName]
                                           ,[Email]
                                           ,[PhoneNumber]
                                           ,[Instructions])
                                     VALUES
                                           ('{customer.FirstName}'
                                           ,'{customer.LastName}'
                                           ,'{customer.Email}'
                                           ,'{customer.Phone}'
                                           ,'{customer.Instructions}')";


            }

            int customerID = DBHelper.ExecuteScalar(query);


            query = $@"INSERT INTO [dbo].[Order]
                               ([CustomerId]
                               ,[TotalPrice]
                               ,[UserID])
                         VALUES
                               ({customerID}
                               ,{orderTotal}
                               ,1)";

            int orderID = DBHelper.ExecuteScalar(query);

            foreach (OrderItem item in orderedItems)
            {

                query = $@"INSERT INTO[dbo].[OrderDetail]
                                    ([OrderId]
                                   , [DishName]
                                   , [DishQty])
                             VALUES
                                   ({orderID}
                                   ,'{item.Name}'
                                   ,{item.Qty})";

                DBHelper.ExecuteQuery(query);
            }

            MessageBoxResult result = MessageBox.Show("Your order has successfully been placed.", "Order Confirmation", MessageBoxButton.OK);

            if (result == MessageBoxResult.OK)
            {
                this.Close();
                Home home = new Home();
                home.Show();
            }

        }

        private void TableHandler()
        {

            string query = $@"INSERT INTO [dbo].[TableOrder]
                                   ([TableID]
                                   ,[Customers]
                                   ,[TotalPrice])
                             VALUES
                                   ({tableNumber}
                                   ,{tableCustomers}
                                   ,{orderTotal})";

            int orderID = DBHelper.ExecuteScalar(query);

            foreach (OrderItem item in orderedItems)
            {
                query = $@"INSERT INTO [dbo].[TableOrderDetail]
                                   ([TableID]
                                   ,[DishName]
                                   ,[DishQty])
                             VALUES
                                   ({tableNumber}
                                   ,'{item.Name}'
                                   ,{item.Qty})";

                DBHelper.ExecuteQuery(query);
            }

            MessageBoxResult result = MessageBox.Show("Your order has successfully been placed.", "Order Confirmation", MessageBoxButton.OK);

            if (result == MessageBoxResult.OK)
            {
                this.Close();
                TableSelection tableSelection = new TableSelection();
                tableSelection.Show();
            }
        }







    }
}