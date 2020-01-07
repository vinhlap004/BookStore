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
    /// Interaction logic for Pickday_UserControl.xaml
    /// </summary>
    public partial class Pickday_UserControl : UserControl
    {
        SaleReportBus saleReportBus = new SaleReportBus();
        ListView SaleReport_ListView;
        List<TextBlock> TextBlocks;
        public Pickday_UserControl(ListView saleReport_ListView, List<TextBlock> textBlocks)
        {
            InitializeComponent();
            SaleReport_ListView = saleReport_ListView;
            TextBlocks = textBlocks;
        }

        private void Pickday_Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime from;
            DateTime to;
            if (DateTime.TryParse(From.Text,out from) && DateTime.TryParse(To.Text,out to))
            {
                SaleReport_ListView.ItemsSource = saleReportBus.getSaleReportByTime(from, to);

                TextBlocks[0].Text = saleReportBus.getAmountSold(saleReportBus.getSaleReportByTime(from, to)).ToString();
                TextBlocks[1].Text = saleReportBus.getRevenueWithoutTax(saleReportBus.getSaleReportByTime(from, to)).ToString();
                TextBlocks[2].Text = saleReportBus.getRevenueWithTax(from,to).ToString();
                TextBlocks[3].Text = saleReportBus.getProfit(saleReportBus.getSaleReportByTime(from, to)).ToString();
            }
            else
            {
                MessageBox.Show("Please input correct day!!");
            }
            
            //saleReport = saleReportBus.getSaleReportByTime(DateTime.Today, 4);
            //SaleReport_ListView.ItemsSource = saleReport;
            //AmountSold_TextBlock.Text = saleReportBus.getAmountSold(saleReport).ToString();
            //RevenueWithoutTax_TextBlock.Text = saleReportBus.getRevenueWithoutTax(saleReport).ToString();
            //RevenueWithTax_TextBlock.Text = saleReportBus.getRevenueWithTax(DateTime.Today, 4).ToString();
            //Profit_TextBlock.Text = saleReportBus.getProfit(saleReport).ToString();
        }
    }
}
