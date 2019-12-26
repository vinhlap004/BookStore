using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookstore.BUS
{
    class LoginBus
    {
        private Dao accountdb = new Dao();
        public bool checkLogin(string userName, string passWord)
        {
            passWord = MD5Hash(Base64Encode(passWord));
            //var a = accountdb.DB.Accounts.Where(x => x.Username == userName).Count();
            var accountList = accountdb.DB.Accounts.ToList();
            var a = (from b in accountList
                     where (b.Username == userName && b.Password== passWord)
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
    }
}
