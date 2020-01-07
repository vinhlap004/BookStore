using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookstore.BUS
{
    class BindingSaleReport
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int BasisPrice { get; set; }
        public int AmountSold { get; set; }
        public double Revenue { get; set; }
        public double Profit { get; set; }
    }


    class SaleReportBus
    {

        private static IDao DataAccess = new Dao();

        List<Product> products = DataAccess.getAllProduct();

        List<Bill> bills = DataAccess.getAllBill();

        List<TransactionHistory> transactionHistories = DataAccess.getAllTransactionHistories();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"> mode = 1 getSaleReport by day, mode = 2 get by month, mode = 3 get by year , mode = 4 get all</param>
        /// <returns></returns>
        public List<BindingSaleReport> getSaleReportByTime(DateTime dateTime, int mode)
        {
            List<BindingSaleReport> result = new List<BindingSaleReport>();
            List<Bill> myBills = new List<Bill>();
            switch (mode)
            {
                case 1:
                    myBills = (from bill in bills
                               where DateTime.Parse(bill.DateCreated) == dateTime
                               select bill).ToList();
                    break;
                case 2:
                    myBills = (from bill in bills
                               where DateTime.Parse(bill.DateCreated).Month == dateTime.Month && DateTime.Parse(bill.DateCreated).Year == dateTime.Year
                               select bill).ToList();
                    break;
                case 3:
                    myBills = (from bill in bills
                               where DateTime.Parse(bill.DateCreated).Year == dateTime.Year
                               select bill).ToList();
                    break;
                case 4:
                    myBills = bills;
                    break;
                default:
                    break;
            }
            List<TransactionHistory> mytransations = (from bill in myBills
                                                      join transaction in transactionHistories on bill.ID equals transaction.BillID
                                                      select transaction).ToList();

            List<TransactionHistory> transations = (from bill in myBills
                                                    join transaction in transactionHistories on bill.ID equals transaction.BillID
                                                    select transaction).ToList();

            for (int i = 0; i < mytransations.Count; i++)
            {

                for (int j = i+1; j < mytransations.Count; j++)
                {
                    if (mytransations[i].ProductID == mytransations[j].ProductID && mytransations[i].ProductPrice == mytransations[j].ProductPrice)
                    {
                        mytransations.Remove(mytransations[j]);
                        j--;
                    }
                }
            }

            foreach (var item in mytransations)
            {
                Product myProduct = new Product();
                myProduct = products.Find(prod => prod.ID == item.ProductID);
                var transOfProduct = (from trans in transations where trans.ProductID == item.ProductID && trans.ProductPrice == item.ProductPrice select trans).ToList();
                var unit = transOfProduct.Select(x => x.Unit).Sum();
                BindingSaleReport salereport = new BindingSaleReport
                {
                    ID = myProduct.ID,
                    Type = myProduct.Type,
                    Name = myProduct.Name,
                    Price = transOfProduct.First().ProductPrice,
                    BasisPrice = transOfProduct.First().ProductBasisPrice,
                    AmountSold = unit,
                    Revenue = transOfProduct.First().ProductPrice * unit,
                    Profit = myProduct.Price * unit - transOfProduct.First().ProductBasisPrice * unit,
                };
                result.Add(salereport);
            }
            return result;
        }

        public List<BindingSaleReport> getSaleReportByTime(DateTime start, DateTime end)
        {
            List<BindingSaleReport> result = new List<BindingSaleReport>();
            List<Bill> myBills = new List<Bill>();
            myBills = (from bill in bills
                       where DateTime.Parse(bill.DateCreated) >= start && DateTime.Parse(bill.DateCreated)<= end
                       select bill).ToList();
            List<TransactionHistory> mytransations = (from bill in myBills
                                                      join transaction in transactionHistories on bill.ID equals transaction.BillID
                                                      select transaction).ToList();

            List<TransactionHistory> transations = (from bill in myBills
                                                    join transaction in transactionHistories on bill.ID equals transaction.BillID
                                                    select transaction).ToList();

            for (int i = 0; i < mytransations.Count; i++)
            {
                for (int j = i + 1; j < mytransations.Count; j++)
                {
                    if (mytransations[i].ProductID == mytransations[j].ProductID && mytransations[i].ProductPrice == mytransations[j].ProductPrice)
                    {
                        mytransations.Remove(mytransations[j]);
                        j--;
                    }
                }
            }

            foreach (var item in mytransations)
            {
                Product myProduct = new Product();
                myProduct = products.Find(prod => prod.ID == item.ProductID);
                var transOfProduct = (from trans in transations where trans.ProductID == item.ProductID && trans.ProductPrice == item.ProductPrice select trans).ToList();
                var unit = transOfProduct.Select(x => x.Unit).Sum();
                BindingSaleReport salereport = new BindingSaleReport
                {
                    ID = myProduct.ID,
                    Type = myProduct.Type,
                    Name = myProduct.Name,
                    Price = transOfProduct.First().ProductPrice,
                    BasisPrice = transOfProduct.First().ProductBasisPrice,
                    AmountSold = unit,
                    Revenue = transOfProduct.First().ProductPrice * unit,
                    Profit = myProduct.Price * unit - transOfProduct.First().ProductBasisPrice * unit,
                };
                result.Add(salereport);
            }
            return result;
        }


        public double getRevenueWithoutTax(List<BindingSaleReport> bindingSaleReports)
        {
            double result = 0;
            foreach (var item in bindingSaleReports)
            {
                result += item.Revenue;
            }
            return result;
        }

        public double getRevenueWithTax(DateTime dateTime, int mode)
        {
            List<Bill> myBills = new List<Bill>();
            switch (mode)
            {
                case 1:
                    myBills = (from bill in bills
                               where DateTime.Parse(bill.DateCreated) == dateTime
                               select bill).ToList();
                    break;
                case 2:
                    myBills = (from bill in bills
                               where DateTime.Parse(bill.DateCreated).Month == dateTime.Month && DateTime.Parse(bill.DateCreated).Year == dateTime.Year
                               select bill).ToList();
                    break;
                case 3:
                    myBills = (from bill in bills
                               where DateTime.Parse(bill.DateCreated).Year == dateTime.Year
                               select bill).ToList();
                    break;
                case 4:
                    myBills = bills;
                    break;
                default:
                    break;
            }

            double result = 0;
            foreach (var item in myBills)
            {
                result += item.TotalCost;
            }
            return result ;
        }

        public double getRevenueWithTax(DateTime start, DateTime end)
        {
            List<Bill> myBills = new List<Bill>();
            myBills = (from bill in bills
                       where DateTime.Parse(bill.DateCreated) >= start && DateTime.Parse(bill.DateCreated) <= end
                       select bill).ToList();
            double result = 0;
            foreach (var item in myBills)
            {
                result+= item.TotalCost;
            }
            return result;
        }

        public double getAmountSold(List<BindingSaleReport> bindingSaleReports)
        {
            double result = 0;
            foreach (var item in bindingSaleReports)
            {
                result += item.AmountSold;
            }
            return result;
        }

        public double getProfit(List<BindingSaleReport> bindingSaleReports)
        {
            double result = 0;
            foreach (var item in bindingSaleReports)
            {
                result += item.Profit;
            }
            return result;
        }

    }
}
