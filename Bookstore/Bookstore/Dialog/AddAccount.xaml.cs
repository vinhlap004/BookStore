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

namespace Bookstore.Dialog
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        IDao db = new Dao();
        ListView ManagerAccount_ListView;
        ManagerAcountBus managerAccount = new ManagerAcountBus();
        public AddAccount(ListView managerAccount_ListView)
        {
            InitializeComponent();
            ManagerAccount_ListView = managerAccount_ListView;
        }

        private void AddAccount_Button_Click(object sender, RoutedEventArgs e)
        {
            int typeAccount;  
            if(admin_typeAccount.IsChecked== true)
            {
                typeAccount = 1;
            }
            else
            {
                typeAccount = 2;
            }
            var newAccount = new Account
            {
                Username = UserName.Text,
                Password = PasswordBox.Password,
                TypeAccountID = typeAccount
            };
            db.addAccount(newAccount);

            string gender;
            if (male_Gender.IsChecked==true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            var newUserInfo = new UserInfo
            {
                UserID = newAccount.ID,
                Name = Name.Text,
                Dayofbirth = DayofBirth.Text,
                Gender = gender,
                PhoneNumber = PhoneNumber.Text,
                Address = Adress.Text,
                MoreInfo = MoreInfo.Text
            };
            db.addUserInfo(newUserInfo);
            ManagerAccount_ListView.ItemsSource = managerAccount.Show();
            MessageBox.Show("Add Account Success");
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
