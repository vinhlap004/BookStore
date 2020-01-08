using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BUS
{
    class ManagerInventoryBus
    {
        private static IDao DataAccess = new Dao();

        static public List<Product> getAllProduct()
        {
            return DataAccess.getAllProduct();
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
        public static List<Product> search(List<Product> data, string containt)
        {
            return (from item in data
                    where item.Name.ToLower().Contains($"{containt.ToLower()}")
                    select item).ToList<Product>();
        }

        public static int generateProductID()
        {
            return DataAccess.getMaxProductID() + 1;
        }

        public static void addProduct(int id, string type, string name, int price, int basisPrice, int amount, string author, string deliver, string catalogries)
        {
            Product newProduct = new Product() { ID = id, Amount = amount, Author = author, Catagories = catalogries, Deliver = deliver, Name = name, Price = price, BasisPrice = basisPrice, Type = type };

            DataAccess.addProduct(newProduct);
        }

        public static void updateProduct(int id, string name, int price, int basisPrice,  int amount, string author, string deliver, string catalogries)
        {
            Product productChange = DataAccess.findProductByID(id);

            productChange.Name = name != "" ? name : productChange.Name;


            productChange.Price = price != -1 ? price : productChange.Price;

            productChange.BasisPrice = basisPrice != -1 ? basisPrice : productChange.BasisPrice;

            productChange.Amount = amount != -1 ? amount : productChange.Amount;

            if (productChange.Type != "Stationery")
                productChange.Author = author != "" ? author : productChange.Author;

            productChange.Catagories = catalogries != "" ? catalogries : productChange.Catagories;

            productChange.Deliver = deliver != "" ? deliver : productChange.Deliver;

            DataAccess.updateProduct(productChange);
        }

        public static void deleteProduct(int productID)
        {
            DataAccess.deleteProduct(productID);
        }
    }
}
