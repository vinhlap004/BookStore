using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BUS
{
    class CheckoutBus
    {
        private static IDao DataAccess = new Dao();

        static public List<Product> getAllProduct()
        {
            return  DataAccess.getAllProduct();
        }

        static public int updateSubCost(int currentSubCost, int productPrice)
        {
            return currentSubCost + productPrice;
        }

        static public double updateTotalCost(int currentSubCost, double tax)
        {
            if (tax == 0)
            {
                return currentSubCost;
            }
                return currentSubCost + currentSubCost * tax / 100;
        }

        static public List<Product> filterType(List<Product> inputList, string filterContains)
        {
            return (from item in inputList where item.Type == filterContains select item).ToList<Product>();
        }

        static public List<Product> filterAuthor(List<Product> inputList, string filterContains)
        {
            return (from item in inputList where item.Author.ToLower().Contains(filterContains.ToLower()) select item).ToList<Product>();
        }

        static public List<Product> filterCatalogries(List<Product> inputList, string filterContains)
        {
            return (from item in inputList where item.Catagories.ToLower().Contains(filterContains.ToLower()) select item).ToList<Product>();
        }

        static public List<Product> filterDeliver(List<Product> inputList, string filterContains)
        {
            return (from item in inputList where item.Deliver.ToLower().Contains(filterContains.ToLower()) select item).ToList<Product>();
        }

        static public string generateBillID()
        {
            int a = DataAccess.getMaxBillID() + 1;
            return (a).ToString();
        }

        static public void addBill(string billID, double totalCost)
        {
            var bill = new Bill() { ID = int.Parse(billID), DateCreated = DateTime.Today.ToShortDateString(), TotalCost = totalCost };
            DataAccess.addBill(bill);
        }

        public static void addTrade(List<BillInfo> productOnBill, string billID)
        {
            int tradeID = DataAccess.getMaxTransactionHistorySTT() + 1;
            foreach(var item in productOnBill)
            {
                TransactionHistory trade = new TransactionHistory() { BillID = int.Parse(billID), ProductID = item.ID, ProductBasisPrice=item.BasisPrice, ProductPrice = item.Price, Unit = item.Unit, STT = tradeID };
                DataAccess.addTransactionHistory(trade);

                tradeID += 1;
            }
        }
        public static void updateAmount(List<BillInfo> productOnBill)
        {
            foreach (var item in productOnBill)
                DataAccess.updateAmount(item.ID, item.Unit);
        }

        public static List<Product> search(List<Product> data, string containt)
        {
            return (from item in data
                    where item.Name.ToLower().Contains($"{containt.ToLower()}")
                    select item).ToList<Product>();
        }

    }
}
