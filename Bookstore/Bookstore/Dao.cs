using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    interface IDao
    {
        bool checkLogin(string userName, string passWord);
        List<Account> getAllAccount();
        List<TypeAccount> getAllTypeAccount();
        List<UserInfo> getAllUserInfo();
    };
    class Dao:IDao
    {
        BookstoreEntities DB = new BookstoreEntities();
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
    }
}
