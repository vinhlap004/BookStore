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
        public UpdateProduct(Product product)
        {
            _idProductSelected = product.ID;

            InitializeComponent();
            this.ProductName.Text = product.Name;
            this.Price.Text = product.Price.ToString();
            BasisPrice.Text = product.BasisPrice.ToString();
            this.Amount.Text = product.Amount.ToString();
            this.Author.Text = product.Author;
            this.Deliver.Text = product.Deliver;
            this.Catalogries.Text = product.Catalogries;
        }

        private void EditProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            int price = -1, amount = -1, basisPrice = -1;
            if (!( (this.Price.Text == "" || int.TryParse(this.Price.Text, out price)) && (this.BasisPrice.Text == "" || int.TryParse(this.BasisPrice.Text, out basisPrice)) && (this.Amount.Text == "" || int.TryParse(this.Amount.Text, out amount)) ))
            {
                MessageBox.Show("Please type a number for Price and Amount, not a letter");
                return;
            }
            //basisPrice =int.Parse(this.BasisPrice.Text);
            //int.TryParse(this.Amount.Text, out amount);// ko hiu lam tai sao sai 
            ManagerInventoryBus.updateProduct(_idProductSelected, this.ProductName.Text, price,basisPrice ,amount, this.Author.Text, this.Deliver.Text, this.Catalogries.Text);

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
