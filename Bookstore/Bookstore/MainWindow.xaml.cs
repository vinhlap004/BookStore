using Bookstore.UserControls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Bookstore
{
    public static class ConfigClass
    {
    public static bool menuOpen { get; set; }
    }

    //bool menuOpen = false;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string username;
        public MainWindow()
        {
            InitializeComponent();
            ConfigClass.menuOpen = false;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            if (loginWindow.DialogResult == false)
            {
                this.Close();
            }
            else
            {
                username =loginWindow.usernameLogin;
            }
        }
        // lấy quyền sử dụng từ database
        List<int> usable_Button = new List<int>();
        // List button
        List<Button> myButtonList = new List<Button>();
        /// <summary>
        /// load các button mà user có thể sự dụng được lên màn hình
        /// </summary>
        private void LoadButton(int typeAccount)
        {
            if(typeAccount==1)
            {
                usable_Button.Add(1);// manager account
                usable_Button.Add(2);// manager inventory
                usable_Button.Add(3);// checkout
                usable_Button.Add(4);// sale report
            }
            else
            {
                usable_Button.Add(3);// checkout
            }
            

            //home button
            Button home_Button = new Button();
            home_Button.Content = "Home";
            home_Button.Margin = new Thickness(2);
            home_Button.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
            home_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            home_Button.Click += Home_Menu_Button_Click;
            myButtonList.Add(home_Button);

            foreach (var item in usable_Button)
            {
                switch (item)
                {
                    case 1:
                        Button account_Button = new Button();
                        account_Button.Content = "Manager Account";
                        account_Button.Margin = new Thickness(2);
                        account_Button.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        account_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        account_Button.Click += Account_Menu_Button_Click;
                        myButtonList.Add(account_Button);
                        break;
                    case 2:
                        Button Inventory_Button = new Button();
                        Inventory_Button.Content = "Manager Inventory";
                        Inventory_Button.Margin = new Thickness(2);
                        Inventory_Button.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        Inventory_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Inventory_Button.Click += Inventory_Menu_Button_Click;
                        myButtonList.Add(Inventory_Button);
                        break;

                    case 3:
                        Button checkout_Button = new Button();
                        checkout_Button.Content = "Checkout";
                        checkout_Button.Margin = new Thickness(2);
                        checkout_Button.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        checkout_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        checkout_Button.Click += Checkout_Menu_Button_Click;
                        myButtonList.Add(checkout_Button);
                        break;

                    case 4:
                        Button saleReport_Button = new Button();
                        saleReport_Button.Content = "Sale Report";
                        saleReport_Button.Margin = new Thickness(2);
                        saleReport_Button.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        saleReport_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        saleReport_Button.Click += SaleReport_Menu_Button_Click;
                        myButtonList.Add(saleReport_Button);
                        break;
                    default:
                        break;
                }
            }
            // Logout button
            Button Logout_Button = new Button();
            Logout_Button.Content = "Logout";
            Logout_Button.Margin = new Thickness(2);
            Logout_Button.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
            Logout_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Logout_Button.Click += Logout_Menu_Button_Click;
            myButtonList.Add(Logout_Button);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IDao db = new Dao();
            LoadButton(db.getUserType(username));
            foreach (var item in myButtonList)
            {
                ButtonPanel.Children.Add(item);
            }
            MenuBar_Tilte_TextBlock.Text = "Home";
            Home_UserControl home_Screen = new Home_UserControl(usable_Button, My_UserControl, MenuBar_Tilte_TextBlock);
            My_UserControl.Children.Add(home_Screen);

        }

        private void Home_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            My_UserControl.Children.Clear();
            MenuBar_Tilte_TextBlock.Text = "Home";
            Home_UserControl home_Screen = new Home_UserControl(usable_Button,My_UserControl,MenuBar_Tilte_TextBlock);
            My_UserControl.Children.Add(home_Screen);

            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = false;
        }

        private void Account_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            My_UserControl.Children.Clear();
            MenuBar_Tilte_TextBlock.Text = "Manager Account";
            Manager_Account_UserControl home_Screen = new Manager_Account_UserControl();
            My_UserControl.Children.Add(home_Screen);

            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = false;
        }

        private void Inventory_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            My_UserControl.Children.Clear();
            MenuBar_Tilte_TextBlock.Text = "Manager Inventory";
            Manager_Inventory_UserControl home_Screen = new Manager_Inventory_UserControl();
            My_UserControl.Children.Add(home_Screen);

            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = false;
        }

        private void Checkout_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            My_UserControl.Children.Clear();
            MenuBar_Tilte_TextBlock.Text = "Checkout";
            Checkout_UserControl home_Screen = new Checkout_UserControl();
            My_UserControl.Children.Add(home_Screen);

            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = false;
        }

        private void SaleReport_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            My_UserControl.Children.Clear();
            MenuBar_Tilte_TextBlock.Text = "Sale Report";
            Sale_Report_UserControl home_Screen = new Sale_Report_UserControl();
            My_UserControl.Children.Add(home_Screen);

            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = false;
        }

        private void Logout_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = false;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            if (loginWindow.DialogResult == false)
            {
                this.Close();
            }
            else
            {
                username = loginWindow.usernameLogin;
                IDao db = new Dao();
                myButtonList.Clear();
                usable_Button.Clear();
                ButtonPanel.Children.Clear();
                LoadButton(db.getUserType(username));
                foreach (var item in myButtonList)
                {
                    ButtonPanel.Children.Add(item);
                }
                My_UserControl.Children.Clear();
                MenuBar_Tilte_TextBlock.Text = "Home";
                Home_UserControl home_Screen = new Home_UserControl(usable_Button, My_UserControl, MenuBar_Tilte_TextBlock);
                My_UserControl.Children.Add(home_Screen); 
                this.Show();
            }
        }

        private void My_UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ConfigClass.menuOpen)
            {
                CloseMenu_BeginStoryboard.Storyboard.Begin();
                ConfigClass.menuOpen = false;
            }
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            
            OpenMenu_BeginStoryboard.Storyboard.Begin();
            ConfigClass.menuOpen = true;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (ConfigClass.menuOpen)
            {
                CloseMenu_BeginStoryboard.Storyboard.Begin();
                ConfigClass.menuOpen = false;
            }
        }
    }
}
