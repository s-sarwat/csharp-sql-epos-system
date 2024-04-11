using Comp_Sci___EPOS_System.Helpers;
using System;
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
        private Button[] buttons = new Button[18];
        public OrderMenu()
        {
            InitializeComponent();

        }

        private void dishBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowDishes(sender as Button);
        }

        private void ShowDishes(Button button)
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
                    string dishName = drc[i]["Name"].ToString();
                    decimal dishPrice = decimal.Parse(drc[i]["Price"].ToString());
                    buttons[i].Content = dishName;
                    buttons[i].Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("No items found from the chosen category.");
            }


        }

        //private void btnGroup2_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        //private void btnGroup3_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        //private void btnGroup4_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        //private void btnGroup5_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        //private void btnGroup6_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        //private void btnGroup7_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        //private void btnGroup8_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowDishes(sender as Button);
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home home = new Home();
            home.Show();
        }

        private void buttons_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int buttonIndex = Array.IndexOf(buttons, button);
            if (buttonIndex != -1)
            {
                Button clickedButton = buttons[buttonIndex];
            }

            TextBlock newTextBlock = new TextBlock();
            newTextBlock.Text = button.Content.ToString();

            newTextBlock.Margin = new Thickness(5);
            newTextBlock.FontSize = 16;
            newTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
            dishListStack.Children.Add(newTextBlock);

        }
    }
}