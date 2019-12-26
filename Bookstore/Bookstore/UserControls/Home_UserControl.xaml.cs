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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookstore.UserControls
{
    /// <summary>
    /// Interaction logic for Home_UserControl.xaml
    /// </summary>
    public partial class Home_UserControl : UserControl
    {
        List<int> usable_Button = new List<int>();
        DockPanel screen;
        TextBlock menuBar_Tilte;
        public Home_UserControl(List<int> usable_Button_List, DockPanel mainScreen,TextBlock menuBarTilte)
        {
            usable_Button = usable_Button_List;
            screen = mainScreen;
            menuBar_Tilte = menuBarTilte;
            InitializeComponent();
        }

        StackPanel stackPnl;
        Image img;
        TextBlock textblock;
        Button btn;
        public void LoadButton()
        {
            var myThickness = new Thickness();
            myThickness.Bottom = 10;
            myThickness.Left = 10;
            myThickness.Right = 10;
            myThickness.Top = 20;
            foreach (var item in usable_Button)
            {
                switch (item)
                {
                    case 1:
                        stackPnl = new StackPanel();
                        stackPnl.Orientation = Orientation.Vertical;
                        img = new Image();
                        img.Source = new BitmapImage(new Uri("/Images/warehouse.png", UriKind.Relative));
                        img.Width = 70;
                        img.Height = 70;
                        textblock = new TextBlock();
                        textblock.Text = "Manager Account";
                        textblock.TextWrapping = TextWrapping.Wrap;
                        textblock.HorizontalAlignment = HorizontalAlignment.Center;
                        textblock.FontSize = 12;
                        stackPnl.Children.Add(img);
                        stackPnl.Children.Add(textblock);
                        btn = new Button();
                        btn.Width = 150;
                        btn.Height = 150;
                        btn.Margin = myThickness;
                        btn.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        btn.Content = stackPnl;
                        btn.Click += Account_Menu_Button_Click;
                        Menu_Button_WrapPanel.Children.Add(btn);
                        break;
                    case 2:
                        stackPnl = new StackPanel();
                        stackPnl.Orientation = Orientation.Vertical;
                        img = new Image();
                        img.Source = new BitmapImage(new Uri("/Images/warehouse.png", UriKind.Relative));
                        img.Width = 70;
                        img.Height = 70;
                        textblock = new TextBlock();
                        textblock.Text = "Manager Inventory";
                        textblock.TextWrapping = TextWrapping.Wrap;
                        textblock.HorizontalAlignment = HorizontalAlignment.Center;
                        textblock.FontSize = 12;
                        stackPnl.Children.Add(img);
                        stackPnl.Children.Add(textblock);
                        btn = new Button();
                        btn.Width = 150;
                        btn.Height = 150;
                        btn.Margin = myThickness;
                        btn.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        btn.Content = stackPnl;
                        btn.Click += Inventory_Menu_Button_Click;
                        Menu_Button_WrapPanel.Children.Add(btn);
                        break;
                    case 3:
                        stackPnl = new StackPanel();
                        stackPnl.Orientation = Orientation.Vertical;
                        img = new Image();
                        img.Source = new BitmapImage(new Uri("/Images/warehouse.png", UriKind.Relative));
                        img.Width = 70;
                        img.Height = 70;
                        textblock = new TextBlock();
                        textblock.Text = "Checkout";
                        textblock.TextWrapping = TextWrapping.Wrap;
                        textblock.HorizontalAlignment = HorizontalAlignment.Center;
                        textblock.FontSize = 12;
                        stackPnl.Children.Add(img);
                        stackPnl.Children.Add(textblock);
                        btn = new Button();
                        btn.Width = 150;
                        btn.Height = 150;
                        btn.Margin = myThickness;
                        btn.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        btn.Content = stackPnl;
                        btn.Click += Checkout_Menu_Button_Click;
                        Menu_Button_WrapPanel.Children.Add(btn);
                        break;

                    case 4:
                        stackPnl = new StackPanel();
                        stackPnl.Orientation = Orientation.Vertical;
                        img = new Image();
                        img.Source = new BitmapImage(new Uri("/Images/warehouse.png", UriKind.Relative));
                        img.Width = 70;
                        img.Height = 70;
                        textblock = new TextBlock();
                        textblock.Text = "Sale Report";
                        textblock.TextWrapping = TextWrapping.Wrap;
                        textblock.HorizontalAlignment = HorizontalAlignment.Center;
                        textblock.FontSize = 12;
                        stackPnl.Children.Add(img);
                        stackPnl.Children.Add(textblock);
                        btn = new Button();
                        btn.Width = 150;
                        btn.Height = 150;
                        btn.Margin = myThickness;
                        btn.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
                        btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        btn.Content = stackPnl;
                        btn.Click += SaleReport_Menu_Button_Click;
                        Menu_Button_WrapPanel.Children.Add(btn);
                        break;
                    default:
                        break;
                }
            }
            //stackPnl = new StackPanel();
            //stackPnl.Orientation = Orientation.Vertical;
            //img = new Image();
            //img.Source = new BitmapImage(new Uri("/Images/warehouse.png", UriKind.Relative));
            //img.Width = 70;
            //img.Height = 70;
            //textblock = new TextBlock();
            //textblock.Text = "Logout";
            //textblock.TextWrapping = TextWrapping.Wrap;
            //textblock.HorizontalAlignment = HorizontalAlignment.Center;
            //textblock.FontSize = 12;
            //stackPnl.Children.Add(img);
            //stackPnl.Children.Add(textblock);
            //btn = new Button();
            //btn.Width = 150;
            //btn.Height = 150;
            //btn.Margin = myThickness;
            //btn.Background = new SolidColorBrush(Color.FromRgb(245, 246, 247));
            //btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            //btn.Content = stackPnl;
            //btn.Click += Logout_Menu_Button_Click;
            //Menu_Button_WrapPanel.Children.Add(btn);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadButton();
        }


        private void Account_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            screen.Children.Clear();
            menuBar_Tilte.Text = "Manager Account";
            Manager_Account_UserControl myScreen = new Manager_Account_UserControl();
            screen.Children.Add(myScreen);
        }

        private void Inventory_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            screen.Children.Clear();
            menuBar_Tilte.Text = "Manager Inventory";
            Manager_Inventory_UserControl myScreen = new Manager_Inventory_UserControl();
            screen.Children.Add(myScreen);
        }

        private void Checkout_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            screen.Children.Clear();
            menuBar_Tilte.Text = "Checkout";
            Checkout_UserControl myScreen = new Checkout_UserControl();
            screen.Children.Add(myScreen);
        }

        private void SaleReport_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            screen.Children.Clear();
            menuBar_Tilte.Text = "Sale Report";
            Sale_Report_UserControl myScreen = new Sale_Report_UserControl();
            screen.Children.Add(myScreen);
        }

    }
}
