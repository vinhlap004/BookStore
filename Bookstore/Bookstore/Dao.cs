using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Bookstore
{
    interface IDao
    {
        bool checkLogin(string userName, string passWord);
        List<Account> getAllAccount();
        List<TypeAccount> getAllTypeAccount();
        List<UserInfo> getAllUserInfo();
        int getUserType(string username);
        void addAccount(Account account);
        void addUserInfo(UserInfo userInfo);
        Account findAccountByID(int ID);
        UserInfo findUserInfoByID(int ID);
        void updateAccount(int ID, string userName, string password, int typeAccount);
        void updateUserInfo(UserInfo newuserInfo);
        void deleteAccountByID(int ID);

     

        void refreshDB();

        // Product + Checkout
        List<Product> getAllProduct();
        Product findProductByID(int id);
        void addProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(int productID);
        void updateAmount(int productID, int newAmount);
        int getMaxProductID();
        // Bill 

        int getMaxBillID();

        void addBill(Bill bill);

        //TransactionHistory
        int getMaxTransactionHistorySTT();
        void addTransactionHistory(TransactionHistory input);
    };
    class Dao : IDao
    {
        BookstoreEntities DB = new BookstoreEntities(); // change here
        public bool checkLogin(string userName, string passWord)
        {
            passWord = MD5Hash(Base64Encode(passWord));
            //var a = accountdb.DB.Accounts.Where(x => x.Username == userName).Count();
            var accountList = DB.Accounts.ToList();
            var a = (from b in accountList
                     where (b.Username == userName && b.Password == passWord)
                     select b).Count();

            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public List<Account> getAllAccount()
        {
            return DB.Accounts.ToList();
        }

        public List<TypeAccount> getAllTypeAccount()
        {
            return DB.TypeAccounts.ToList();
        }

        public List<UserInfo> getAllUserInfo()
        {
            return DB.UserInfoes.ToList();
        }

        public void addAccount(Account account)
        {
            account.Password = MD5Hash(Base64Encode(account.Password));
            DB.Accounts.Add(account);
            DB.SaveChanges();
        }

        public void addUserInfo(UserInfo userInfo)
        {
            DB.UserInfoes.Add(userInfo);
            DB.SaveChanges();
        }

        public int getUserType(string username)
        {
            var ListAccount = DB.Accounts.ToList();
            var accountType = (from acc in ListAccount
                               where acc.Username == username
                               select acc).FirstOrDefault<Account>();
            return accountType.TypeAccountID;
        }

        public Account findAccountByID(int ID)
        {
            return DB.Accounts.SingleOrDefault(id => id.ID == ID);
        }

        //public List<Account> findAccountByUserName(string username)
        //{
        //    var accountList = DB.Accounts.ToList();
        //    string usernameRegex = @"[\\w]*" + username + "[\\w]*";
            
        //    var a = (from b in accountList
        //             where (b.Username == username)
        //             select b);
            
        //    return a;
        //}

        public UserInfo findUserInfoByID(int ID)
        {
            return DB.UserInfoes.SingleOrDefault(id => id.UserID == ID);
        }

        public void updateAccount(int ID, string userName, string password, int typeAccount)
        {
            var account = findAccountByID(ID);
            account.Username = userName;
            if (password != null)
            {
                account.Password = MD5Hash(Base64Encode(password));
            }
            account.TypeAccountID = typeAccount;
            DB.SaveChanges();
        }

        public void updateUserInfo(UserInfo newuserInfo)
        {
            var userInfo = findUserInfoByID(newuserInfo.UserID);
            userInfo.Name = newuserInfo.Name;
            userInfo.Dayofbirth = newuserInfo.Dayofbirth;
            userInfo.Gender = newuserInfo.Gender;
            userInfo.PhoneNumber = newuserInfo.PhoneNumber;
            userInfo.Address = newuserInfo.Address;
            userInfo.MoreInfo = newuserInfo.MoreInfo;
            DB.SaveChanges();
        }

        public void deleteAccountByID(int ID)
        {
            var account = findAccountByID(ID);
            var userInfo = findUserInfoByID(ID);
            DB.Accounts.Remove(account);
            DB.UserInfoes.Remove(userInfo);
            DB.SaveChanges();
        }

        public List<Product> getAllProduct()
        {
            return DB.Products.ToList();
        }

        public Product findProductByID(int id)
        {
            return DB.Products.SingleOrDefault(product => product.ID == id);
        }

        public void addProduct(Product product)
        {
            DB.Products.Add(product);
            DB.SaveChanges();
        }

        public void updateProduct(Product product)
        {
            var productChange = this.findProductByID(product.ID);

            productChange.Name = product.Name;
            productChange.Price = product.Price;
            productChange.Amount = product.Amount;
            productChange.Author = product.Author;
            productChange.Catalogries = product.Catalogries;
            productChange.Deliver = product.Deliver;

            DB.SaveChanges();
        }

        public void deleteProduct(int productID)
        {
            var deletedItem = this.findProductByID(productID);

            DB.Products.Remove(deletedItem);
            DB.SaveChanges();
        }

        public int getMaxBillID()
        {
            return DB.Bills.Max(item => item.ID);
        }

        public void addBill(Bill bill)
        {
            DB.Bills.Add(bill);
            DB.SaveChanges();
        }

        public void addTransactionHistory(TransactionHistory input)
        {
            DB.TransactionHistories.Add(input);
            DB.SaveChanges();
        }

        public int getMaxTransactionHistorySTT()
        {
            return DB.TransactionHistories.Max(item => item.STT);
        }

        public void refreshDB()
        {
            DB = new BookstoreEntities();
        }

        public void updateAmount(int productID, int descAmount)
        {
            var productChange = DB.Products.SingleOrDefault(product => product.ID == productID);

            productChange.Amount -= descAmount;
            DB.SaveChanges();
        }

        public int getMaxProductID()
        {
            return DB.Products.Max(product => product.ID);
        }
    }
}
