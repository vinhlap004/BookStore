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
        IDao accountdb = new Dao();
        public bool checkLogin(string userName, string passWord)
        {
            if (accountdb.checkLogin(userName,passWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
