using Bookstore.BUS;
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

namespace Bookstore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginBus login = new LoginBus();
        public LoginWindow()
        {
            InitializeComponent();
        }

        // login: Username: admin password: Ad@123
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.checkLogin(UserName_TextBox.Text,Password_Box.Password))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Your username or password not correct!!");
            } 
        }
    }
}
