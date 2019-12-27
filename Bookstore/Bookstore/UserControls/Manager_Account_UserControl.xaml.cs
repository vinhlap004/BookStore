using Bookstore.BUS;
using Bookstore.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Bookstore.UserControls
{
    /// <summary>
    /// Interaction logic for Manager_Account_UserControl.xaml
    /// </summary>
    public partial class Manager_Account_UserControl : UserControl
    {

        ManagerAcountBus managerAccount = new ManagerAcountBus();
        IDao db = new Dao();
        public Manager_Account_UserControl()
        {
            InitializeComponent();
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ManagerAccount_ListView.ItemsSource = managerAccount.Show();
        }

        private void Add_Account_Click(object sender, RoutedEventArgs e)
        {
            AddAccount addAccountDialog = new AddAccount(ManagerAccount_ListView);
            addAccountDialog.ShowDialog();
        }

        private void EditAccount_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ManagerAccount_ListView.SelectedItem as BindingAccount;
            if(selectedItem==null)
            {
                MessageBox.Show("Please choose an account you want to edit");
            }
            else {
                EditAccount editAccount = new EditAccount(int.Parse(selectedItem.ID), ManagerAccount_ListView);
                editAccount.ShowDialog();
            }
        }

        private void DeleteAccount_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ManagerAccount_ListView.SelectedItem as BindingAccount;
            if (selectedItem == null)
            {
                MessageBox.Show("Please choose an account you want to delete");
            }
            else
            {
                db.deleteAccountByID(int.Parse(selectedItem.ID));
                ManagerAccount_ListView.ItemsSource = managerAccount.Show();
                MessageBox.Show("Delete success");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BindingAccount selectedItem = ManagerAccount_ListView.SelectedItem as BindingAccount;
            if (selectedItem == null)
            {
                MessageBox.Show("Please choose an account you want to edit");
            }
            else
            {
                EditAccount editAccount = new EditAccount(int.Parse(selectedItem.ID), ManagerAccount_ListView);
                editAccount.ShowDialog();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = ManagerAccount_ListView.SelectedItem as BindingAccount;
            if (selectedItem == null)
            {
                MessageBox.Show("Please choose an account you want to delete");
            }
            else
            {
                db.deleteAccountByID(int.Parse(selectedItem.ID));
                ManagerAccount_ListView.ItemsSource = managerAccount.Show();
                MessageBox.Show("Delete success");
            }
        }
    }
}
