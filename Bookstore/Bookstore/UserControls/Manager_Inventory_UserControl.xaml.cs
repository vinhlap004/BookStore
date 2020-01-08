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
using Bookstore;
using Bookstore.Dialog;
using Bookstore.BUS;
using System.ComponentModel;

namespace Bookstore.UserControls
{
    /// <summary>
    /// Interaction logic for Manager_Inventory_UserControl.xaml
    /// </summary>
    public partial class Manager_Inventory_UserControl : UserControl
    {

        //private _1712872.Bookstore connectiondb;
        private List<Product> _databaseSource = new List<Product>();
        private List<Product> _displayProductList = new List<Product>();

        public Manager_Inventory_UserControl()
        {

            _databaseSource = ManagerInventoryBus.getAllProduct();
            
            InitializeComponent();
            Customer_ListView.ItemsSource = _databaseSource;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.Customer_ListView.ItemsSource = null;

            if (this.SearchTextBox.Text == "")
                Customer_ListView.ItemsSource = _databaseSource;

            _displayProductList = ManagerInventoryBus.search(_databaseSource, this.SearchTextBox.Text);
            Customer_ListView.ItemsSource = _displayProductList;
        }

        private void FilterOkButton_Click(object sender, RoutedEventArgs e)
        {
            string[] tranform = { "All Types", "Book", "Stationery" };

            if(this._displayProductList.Count == 0)
                this._displayProductList.AddRange(_databaseSource);

            string typeFilterSelected = tranform[(this.ComboboxFilter.SelectedIndex == -1 ? 0 : this.ComboboxFilter.SelectedIndex)];

            if (typeFilterSelected != "All Types")
                _displayProductList = ManagerInventoryBus.filterType(_displayProductList, typeFilterSelected);

            if (this.AuthorCheckboxFilter.IsChecked == true && this.AuthorTextBoxFilter.Text != "")
                _displayProductList = ManagerInventoryBus.filterAuthor(_displayProductList, this.AuthorTextBoxFilter.Text);

            if (this.DeliverCheckboxFilter.IsChecked == true && this.DeliverTextBoxFilter.Text != "")
                _displayProductList = ManagerInventoryBus.filterDeliver(_displayProductList, this.DeliverTextBoxFilter.Text);

            if (this.CataloriesCheckboxFilter.IsChecked == true && this.CataloriesTextBoxFilter.Text != "")
                _displayProductList = ManagerInventoryBus.filterCatalogries(_displayProductList, this.CataloriesTextBoxFilter.Text);

            this.Customer_ListView.ItemsSource = null;
            this.Customer_ListView.ItemsSource = _displayProductList;

        }

        private void PopupEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Customer_ListView.ItemsSource = null;
            this.Customer_ListView.ItemsSource = _databaseSource;
        }

        private void AddProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            int nextProductID = ManagerInventoryBus.generateProductID();

            var addProductScreen = new AddProduct(nextProductID);

            if(addProductScreen.ShowDialog() == true)
            {
                _databaseSource = ManagerInventoryBus.getAllProduct();
                this.Customer_ListView.ItemsSource = null;
                this.Customer_ListView.ItemsSource = _databaseSource;
            }
        }

        private void UpdateProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Customer_ListView.SelectedItem == null)
                MessageBox.Show("You haven't pick product");
            else
            {
                var editProductScreen = new UpdateProduct(this.Customer_ListView.SelectedItem as Product);

                if (editProductScreen.ShowDialog() == true)
                {
                    //connectiondb = new Bookstore();
                    _databaseSource = ManagerInventoryBus.getAllProduct();
                    this.Customer_ListView.ItemsSource = null;
                    this.Customer_ListView.ItemsSource = _databaseSource;
                }
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Customer_ListView.SelectedItem == null)
                MessageBox.Show("You haven't pick product");
            else
            {

                var selectedItem = this.Customer_ListView.SelectedItem as Product;
                ManagerInventoryBus.deleteProduct(selectedItem.ID);

                _databaseSource = ManagerInventoryBus.getAllProduct();
                this.Customer_ListView.ItemsSource = null;
                this.Customer_ListView.ItemsSource = _databaseSource;
            }
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var editProductScreen = new UpdateProduct(this.Customer_ListView.SelectedItem as Product);

            if (editProductScreen.ShowDialog() == true)
            {

                //connectiondb = new Bookstore();
                _databaseSource = ManagerInventoryBus.getAllProduct();
                this.Customer_ListView.ItemsSource = null;
                this.Customer_ListView.ItemsSource = _databaseSource;
            }
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ManagerInventoryBus.deleteProduct((this.Customer_ListView.SelectedItem as Product).ID);

            _databaseSource = ManagerInventoryBus.getAllProduct();
            this.Customer_ListView.ItemsSource = null;
            this.Customer_ListView.ItemsSource = _databaseSource;
        }

        private void searchTextBlock_KeyUp(object sender, KeyEventArgs e)
        {
            this.Customer_ListView.ItemsSource = null;

            if (this.SearchTextBox.Text == "")
                Customer_ListView.ItemsSource = _databaseSource;

            _displayProductList = ManagerInventoryBus.search(_databaseSource, this.SearchTextBox.Text);
            Customer_ListView.ItemsSource = _displayProductList;
        }


        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;
        private void Customer_ListView_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    Sort(header, direction);

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(Customer_ListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

    }
}
