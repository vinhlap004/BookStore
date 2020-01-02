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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookstore.UserControls
{
    /// <summary>
    /// Interaction logic for Sale_Report_UserControl.xaml
    /// </summary>
    public partial class Sale_Report_UserControl : UserControl
    {
        SaleReportBus saleReportBus = new SaleReportBus();
        List<BindingSaleReport> saleReport;
        public Sale_Report_UserControl()
        {
            InitializeComponent();
            saleReport = saleReportBus.getSaleReportByTime(DateTime.Today, 1);
            SaleReport_ListView.ItemsSource = saleReport;
            AmountSold_TextBlock.Text = saleReportBus.getAmountSold(saleReport).ToString();
            RevenueWithoutTax_TextBlock.Text = saleReportBus.getRevenueWithoutTax(saleReport).ToString();
            RevenueWithTax_TextBlock.Text = saleReportBus.getRevenueWithTax(DateTime.Today, 1).ToString();
            Profit_TextBlock.Text = saleReportBus.getProfit(saleReport).ToString();

            DateMode.IsChecked = true;
        }

        private void DateMode_Checked(object sender, RoutedEventArgs e)
        {
            saleReport = saleReportBus.getSaleReportByTime(DateTime.Today, 1);
            SaleReport_ListView.ItemsSource = saleReport;
            AmountSold_TextBlock.Text = saleReportBus.getAmountSold(saleReport).ToString();
            RevenueWithoutTax_TextBlock.Text = saleReportBus.getRevenueWithoutTax(saleReport).ToString();
            RevenueWithTax_TextBlock.Text = saleReportBus.getRevenueWithTax(DateTime.Today, 1).ToString();
            Profit_TextBlock.Text = saleReportBus.getProfit(saleReport).ToString();
        }

        private void MonthMode_Checked(object sender, RoutedEventArgs e)
        {
            saleReport = saleReportBus.getSaleReportByTime(DateTime.Today, 2);
            SaleReport_ListView.ItemsSource = saleReport;
            AmountSold_TextBlock.Text = saleReportBus.getAmountSold(saleReport).ToString();
            RevenueWithoutTax_TextBlock.Text = saleReportBus.getRevenueWithoutTax(saleReport).ToString();
            RevenueWithTax_TextBlock.Text = saleReportBus.getRevenueWithTax(DateTime.Today, 2).ToString();
            Profit_TextBlock.Text = saleReportBus.getProfit(saleReport).ToString();
        }

        private void YearMode_Checked(object sender, RoutedEventArgs e)
        {
            saleReport = saleReportBus.getSaleReportByTime(DateTime.Today, 3);
            SaleReport_ListView.ItemsSource = saleReport;
            AmountSold_TextBlock.Text = saleReportBus.getAmountSold(saleReport).ToString();
            RevenueWithoutTax_TextBlock.Text = saleReportBus.getRevenueWithoutTax(saleReport).ToString();
            RevenueWithTax_TextBlock.Text = saleReportBus.getRevenueWithTax(DateTime.Today, 3).ToString();
            Profit_TextBlock.Text = saleReportBus.getProfit(saleReport).ToString();
        }

        private void TotalMode_Checked(object sender, RoutedEventArgs e)
        {
            saleReport = saleReportBus.getSaleReportByTime(DateTime.Today, 4);
            SaleReport_ListView.ItemsSource = saleReport;
            AmountSold_TextBlock.Text = saleReportBus.getAmountSold(saleReport).ToString();
            RevenueWithoutTax_TextBlock.Text = saleReportBus.getRevenueWithoutTax(saleReport).ToString();
            RevenueWithTax_TextBlock.Text = saleReportBus.getRevenueWithTax(DateTime.Today, 4).ToString();
            Profit_TextBlock.Text = saleReportBus.getProfit(saleReport).ToString();
        }
    }
}
