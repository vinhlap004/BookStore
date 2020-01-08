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
        public string usernameLogin { get; set; }
        public int userIDLogin { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
        }

        // login: Username: admin password: Ad@123
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserName_TextBox.Text == "")
            {
                MessageBox.Show("Please input username");
            }
            else
            {
                if (Password_Box.Password == "")
                {
                    MessageBox.Show("Please input password");
                }
                else
                {
                    if (login.checkLogin(UserName_TextBox.Text, Password_Box.Password))
                    {
                        DialogResult = true;
                        usernameLogin = UserName_TextBox.Text;
                        userIDLogin = login.getUserIDbyUserName(usernameLogin);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Your username or password not correct!!");
                    }
                }
            }
            
        }

        private void UserName_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (UserName_TextBox.Text == "")
                {
                    MessageBox.Show("Please input username");
                }
                else
                {
                    if (Password_Box.Password == "")
                    {
                        MessageBox.Show("Please input password");
                    }
                    else
                    {
                        if (login.checkLogin(UserName_TextBox.Text, Password_Box.Password))
                        {
                            DialogResult = true;
                            usernameLogin = UserName_TextBox.Text;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Your username or password not correct!!");
                        }
                    }
                }
            }
        }

        private void Password_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (UserName_TextBox.Text == "")
                {
                    MessageBox.Show("Please input username");
                }
                else
                {
                    if (Password_Box.Password == "")
                    {
                        MessageBox.Show("Please input password");
                    }
                    else
                    {
                        if (login.checkLogin(UserName_TextBox.Text, Password_Box.Password))
                        {
                            DialogResult = true;
                            usernameLogin = UserName_TextBox.Text;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Your username or password not correct!!");
                        }
                    }
                }
            }
        }
    }
}
