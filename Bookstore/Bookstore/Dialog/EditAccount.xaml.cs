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
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        Account account;
        UserInfo userInfo;
        IDao db = new Dao();
        ListView ManagerAccount_ListView;
        ManagerAcountBus managerAccount = new ManagerAcountBus();
        public EditAccount(int ID, ListView managerAccount_ListView)
        {
            InitializeComponent();
            ManagerAccount_ListView = managerAccount_ListView;
            account = db.findAccountByID(ID);
            userInfo = db.findUserInfoByID(ID);

            UserName.Text = account.Username;

            DayofBirth.Text = userInfo.Dayofbirth;
            if (account.TypeAccountID == 1)
            {
                Admin_typeAccount.IsChecked = true;
            }
            else
            {
                Seller_typeAccount.IsChecked = true;
            }

            Name.Text = userInfo.Name;
            DayofBirth.Text = userInfo.Dayofbirth;
            if (userInfo.Gender == "Male")
            {
                Male_Gender.IsChecked = true;
            }
            else
            {
                Female_Gender.IsChecked = true;
            }
            PhoneNumber.Text = userInfo.PhoneNumber;
            Adress.Text = userInfo.Address;
            MoreInfo.Text = userInfo.MoreInfo;
        }

        private void EditAccount_Button_Click(object sender, RoutedEventArgs e)
        {
            if(account.ID == 1 && ConfigClass.IdLogin!= 1)
            {
                MessageBox.Show("It's Super admin you can edit this account");
                return;
            }
            string[] input = new string[4];
            //= { UserName.Text, PasswordBox.Password, Name.Text, PhoneNumber.Text };
            string password;
            if (PasswordBox.Password.Length == 0)
            {
                password = null;
                //check input empty
                input[0] = UserName.Text;
                input[1] = "AbC@12345";
                input[2] = Name.Text;
                input[3] = PhoneNumber.Text;
            }
            else
            {
                password = PasswordBox.Password;
                input[0] = UserName.Text;
                input[1] = password;
                input[2] = Name.Text;
                input[3] = PhoneNumber.Text;
            }

            string error = managerAccount.checkInput(input);
            int typeAccount;

            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }

            if (Admin_typeAccount.IsChecked == true)
            {
                typeAccount = 1;
            }
            else
            {
                typeAccount = 2;
            }
            
            db.updateAccount(account.ID, UserName.Text, password, typeAccount);

            string gender;
            if (Male_Gender.IsChecked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            var newUserInfo = new UserInfo
            {
                UserID = userInfo.UserID,
                Name = Name.Text,
                Dayofbirth = DayofBirth.Text,
                Gender = gender,
                PhoneNumber = PhoneNumber.Text,
                Address = Adress.Text,
                MoreInfo = MoreInfo.Text,
            };
            db.updateUserInfo(newUserInfo);
            ManagerAccount_ListView.ItemsSource = managerAccount.showListAccount();
            MessageBox.Show("Edit Account Success");
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
