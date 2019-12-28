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
using Bookstore.BUS;

namespace Bookstore.Dialog
{
    /// <summary>
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        int _idProductSelected;
        public UpdateProduct(int idProductSelected)
        {
            _idProductSelected = idProductSelected;

            InitializeComponent();
        }

        private void EditProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            int price = -1, amount = -1;
            if (!(this.Price.Text == "" || int.TryParse(this.Price.Text, out price)) && (this.Amount.Text == "" || int.TryParse(this.Amount.Text, out amount)))
            {
                MessageBox.Show("Please type a number for Price and Amount, not a letter");
                return;
            }

            int.TryParse(this.Amount.Text, out amount);// ko hiu lam tai sao sai 
            ManagerInventoryBus.updateProduct(_idProductSelected, this.ProductName.Text, price, amount, this.Author.Text, this.Deliver.Text, this.Catalogries.Text);

            DialogResult = true;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
