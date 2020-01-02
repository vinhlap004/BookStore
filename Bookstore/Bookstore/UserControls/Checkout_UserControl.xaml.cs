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
using Bookstore.BUS;

namespace Bookstore.UserControls
{
    /// <summary>
    /// Interaction logic for Checkout_UserControl.xaml
    /// </summary>
    public partial class Checkout_UserControl : UserControl
    {
     
        private List<Product> databaseSource = new List<Product>(); // lưu trữ nguyên bản tất cả sản phẩm từ csdl
        private List<BillInfo> productOnBill = new List<BillInfo>();// danh sách sản phẩm hiển thị trên hóa đơn
        private List<Product> listProduct = new List<Product>(); // danh sách sản phẩm hiển thị bên khung tìm kiếm
        private int _subCost = 0;
        private double _totalCost = 0;
        private double _taxValue;
        private string _billID;

        //_1712872.Bookstore connectiondb; // remember to edit it
        public Checkout_UserControl()
        {
            //connectiondb = new Bookstore();
            databaseSource = CheckoutBus.getAllProduct();
            _billID = CheckoutBus.generateBillID();


            InitializeComponent();
            Customer_ListView.ItemsSource = databaseSource;
            try
            {
                if (TaxTextBlock.Text.Length != 0)
                    _taxValue = double.Parse(TaxTextBlock.Text);
                else
                {
                    _taxValue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a number");
            }
            BillIDTextBlock.Text = "Bill ID : " + _billID;
            this.DateTextBlock.Text = "Date: " + DateTime.Today.ToShortDateString();
        }

        //*************************************************************************************************************************
        //*                                                    CÁC HÀM PHỤ TRỢ                                                    *
        //*************************************************************************************************************************

        //------------------> Các hàm dọn dẹp giao diện và data behind <---------------------
        private void resetUI()
        {
            BillIDTextBlock.Text = "Bill ID : " + _billID;
            this.Bill_ListView.ItemsSource = null;
            this.Customer_ListView.ItemsSource = databaseSource;
        }

        private void clearCostTextBlock()
        {
            this.SubCostTextBlock.Text = "";
            this.TotalCostTextBlock.Text = "";
        }

        private void clearBindingList()
        {
            productOnBill.Clear();
            listProduct.Clear();
        }
        //------------------> Hết các hàm dọn dẹp giao diện và databehind <---------------------

        //------------------> Các hàm tính giá tiền của cái bill <-----------------------
        private void updateCostTextBlock(int priceOfProduct)
        {
            try
            {
                if (TaxTextBlock.Text.Length != 0)
                    _taxValue = double.Parse(TaxTextBlock.Text);
                else
                {
                    _taxValue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a number");
            }
            this._subCost = CheckoutBus.updateSubCost(this._subCost, priceOfProduct);
            this._totalCost = CheckoutBus.updateTotalCost(this._subCost, this._taxValue);

            this.SubCostTextBlock.Text = this._subCost.ToString();
            this.TotalCostTextBlock.Text = this._totalCost.ToString();
        }
        //------------------> Hết các hàm tính giá tiền của cái bill <-----------------------


       
   
//===============================================================================================================================================


        //*******************************************************************************************************
        //*                                      CÁC HÀM XỬ LÍ SỰ KIỆN                                          *
        //*******************************************************************************************************

        private void Customer_ListView_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (PopupEnabled.IsChecked == false)
            {
                listProduct = CheckoutBus.search(databaseSource, this.searchTextBlock.Text);
                Customer_ListView.ItemsSource = listProduct;
            }
            else
            {
                List<Product> temp = new List<Product>();
                
                listProduct = CheckoutBus.search(databaseSource, this.searchTextBlock.Text);
                string[] tranformer = { "All Types", "Book", "Stationery" };
                temp.AddRange(listProduct);
                var typeFilterSelected = tranformer[this.TypeFilterComboBox.SelectedIndex == -1 ? 0 : this.TypeFilterComboBox.SelectedIndex];

                if (typeFilterSelected != "All Types")
                    temp = CheckoutBus.filterType(temp, typeFilterSelected);

                if (this.AuthorFilterCheckBox.IsChecked == true && this.AuthorFilterTextBlock.Text != "")
                    temp = CheckoutBus.filterAuthor(temp, this.AuthorFilterTextBlock.Text);

                if (this.DeliverFilterCheckBox.IsChecked == true && this.DeliverFilterTextBlock.Text != "")
                    temp = CheckoutBus.filterDeliver(temp, this.DeliverFilterTextBlock.Text);

                if (this.CatalogriesFilterCheckBox.IsChecked == true && this.CatalogriesFliterTextBlock.Text != "")
                    temp = CheckoutBus.filterCatalogries(temp, this.CatalogriesFliterTextBlock.Text);

                this.Customer_ListView.ItemsSource = null;
                this.Customer_ListView.ItemsSource = temp;
            }
        }

        private void AddProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Customer_ListView.SelectedItem == null)
                MessageBox.Show("Phải chọn sản phẩm mới nhấn được người ơi");
            else
            {
                var itemSelected = this.Customer_ListView.SelectedItem as Product;

                var productCheck = (from item in databaseSource where item.ID == itemSelected.ID select item).ToList();

                if(productCheck[0].Amount < 1)
                {
                    MessageBox.Show("Hiện sản phẩm đã hết hàng");
                    return;
                }

                foreach (var item in productOnBill)
                {
                    if (item.ID == itemSelected.ID)
                    {
                        if(productCheck[0].Amount - item.Unit - 1 < 0)
                        {
                            MessageBox.Show("Hiện sản phẩm đã hết hàng");
                            return;
                        }

                        item.Unit++;
                        item.Cost += item.Price;
                        this.Bill_ListView.ItemsSource = null;
                        this.Bill_ListView.ItemsSource = productOnBill;                     
                        updateCostTextBlock(item.Price);
                        return;
                    }
                }

                productOnBill.Add(new BillInfo() { ID = itemSelected.ID, Name = itemSelected.Name,BasisPrice = itemSelected.BasisPrice, Price = itemSelected.Price, Unit = 1, Cost = itemSelected.Price });
                updateCostTextBlock(itemSelected.Price);

                this.Bill_ListView.ItemsSource = null;
                this.Bill_ListView.ItemsSource = productOnBill;
            }
        }

        private void clearBill_Button_Click(object sender, RoutedEventArgs e)
        {
            _subCost = 0;
            _totalCost = 0;
            resetUI();
            clearBindingList();
            clearCostTextBlock();
        }

        private void Checkout_Button_Click(object sender, RoutedEventArgs e)
        {
            updateCostTextBlock(0); // chạy lần cuối để kiểm tra xem tax có bị thay đổi ko, nếu có => tính lại theo tax mới

            CheckoutBus.addBill(_billID, _totalCost);

            // cập nhật csdl
            CheckoutBus.updateAmount(productOnBill);
            CheckoutBus.addTrade(productOnBill, _billID);

            _billID = (int.Parse(_billID) + 1).ToString();

            //hoàn tất cập nhật thông tin, xử lí giao diện, dọn dẹp chuẩn bị cho cái bill tiếp theo
            resetUI();
            clearBindingList();
            clearCostTextBlock();
            Customer_ListView.ItemsSource = CheckoutBus.getAllProduct();

        }

        private void FilterOKButton_Click(object sender, RoutedEventArgs e)
        {
            List<Product> temp = new List<Product>();
            temp.AddRange(listProduct);
            if (this.Customer_ListView.ItemsSource == null)
                MessageBox.Show("Không có gì để mà lọc đâu người hỡi");
            else
            {
                string[] tranformer = { "All Types", "Book", "Stationery" };

                var typeFilterSelected = tranformer[this.TypeFilterComboBox.SelectedIndex == -1 ? 0 : this.TypeFilterComboBox.SelectedIndex];

                if (typeFilterSelected != "All Types")
                    temp = CheckoutBus.filterType(temp, typeFilterSelected);

                if (this.AuthorFilterCheckBox.IsChecked == true && this.AuthorFilterTextBlock.Text != "")
                    temp = CheckoutBus.filterAuthor(temp, this.AuthorFilterTextBlock.Text);

                if (this.DeliverFilterCheckBox.IsChecked == true && this.DeliverFilterTextBlock.Text != "")
                    temp = CheckoutBus.filterDeliver(temp, this.DeliverFilterTextBlock.Text);

                if (this.CatalogriesFilterCheckBox.IsChecked == true && this.CatalogriesFliterTextBlock.Text != "")
                    temp = CheckoutBus.filterCatalogries(temp, this.CatalogriesFliterTextBlock.Text);

                this.Customer_ListView.ItemsSource = null;
                this.Customer_ListView.ItemsSource = temp;
            }
        }

        private void PopupEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Customer_ListView.ItemsSource = null;
            if(listProduct.Count<1)
            {
                listProduct = databaseSource;
            }
            this.Customer_ListView.ItemsSource = listProduct;
        }

        private void searchTextBlock_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                this.PopupEnabled.IsChecked = false;

                listProduct = CheckoutBus.search(databaseSource, this.searchTextBlock.Text);
                this.Customer_ListView.ItemsSource = listProduct;
            }
        }

        private void TaxTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            { 
                if (TaxTextBlock.Text.Length != 0)
                    _taxValue = double.Parse(TaxTextBlock.Text);
                else
                {
                    _taxValue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a number");
            }
            this._totalCost = CheckoutBus.updateTotalCost(this._subCost, _taxValue);
            this.TotalCostTextBlock.Text = this._totalCost.ToString();
        }
    }
}
