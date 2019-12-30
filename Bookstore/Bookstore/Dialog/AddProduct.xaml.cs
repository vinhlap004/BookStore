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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private int _id;
        public AddProduct(int idForNewProduct)
        {
            _id = idForNewProduct;
            InitializeComponent();
        }

        private void AddProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            int price, basisPrice, amount;
            string type, author;
            if(this.ProductName.Text == "" || this.Author.Text == "" || this.Price.Text == "" || BasisPrice.Text =="" || this.Catalogries.Text == "" || this.Amount.Text == "" || this.Deliver.Text == "" || (this.Book_typeProduct.IsChecked == false && this.Stationery_typeProduct.IsChecked == false))
                MessageBox.Show("Please complete all infomation!!");
            else
            {
                if (int.TryParse(this.Price.Text, out price) &&int.TryParse(this.BasisPrice.Text, out basisPrice) && int.TryParse(this.Amount.Text, out amount))
                {
                    type = this.Book_typeProduct.IsChecked == true ? "Book" : "Stationery";
                    author = type == "Stationery" ? "-" : this.Author.Text;
                    ManagerInventoryBus.addProduct(_id, type, this.ProductName.Text, price, basisPrice,amount, author, this.Deliver.Text, this.Catalogries.Text);

                    DialogResult = true;
                    this.Close();
                }
                else
                    MessageBox.Show("Please type a number for Price, BasisPrice and Amount, not a letter ");
            }
            
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
