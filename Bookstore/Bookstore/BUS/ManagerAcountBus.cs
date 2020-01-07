using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace Bookstore.BUS
{
    public class BindingAccount
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string TypeAccount { get; set; }
        public string Name { get; set; }
        public string Dayofbirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string MoreInfo{ get; set; }
    }
    class ManagerAcountBus
    {
        private static IDao accountdb = new Dao();
        public List<BindingAccount> Show()
        {
            accountdb = new Dao();
            var account = accountdb.getAllAccount();
            var typeAccount = accountdb.getAllTypeAccount();
            var userInfo = accountdb.getAllUserInfo();

            var showdb = (from a in account
                          join b in typeAccount on a.TypeAccountID equals b.ID
                          join c in userInfo on a.ID equals c.UserID
                          select new BindingAccount
                          {
                              ID = a.ID.ToString(),
                              UserName = a.Username,
                              TypeAccount = b.TypeAccount1,
                              Name = c.Name,
                              Dayofbirth = c.Dayofbirth,
                              Gender = c.Gender,
                              PhoneNumber = c.PhoneNumber,
                              Address = c.Address,
                              MoreInfo = c.MoreInfo,
                          }).ToList();
            List<BindingAccount> db = new List<BindingAccount>();
            foreach (var item in showdb)
            {
                db.Add(item);
            }
            return db;
        }

        static public List<Account> getAllAccount()
        {
            return accountdb.getAllAccount();
        }

        public bool isValidPass(string password)
        {
            //
            string regex = @"(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*\.(\){\}[\]]).{8,}";
            return Regex.IsMatch(password, regex);
        }

        public bool isValidUsername(string username)
        {
            string regex = @"[a-zA-Z-0-9]{5,}";
            return Regex.IsMatch(username, regex);
        }

        public bool isValidPhoneNumber(string phonenumber)
        {
            if (phonenumber.Length != 10)
            {
                return false;
            }
            if (phonenumber.All(char.IsDigit) == false)
            {
                return false;
            }
            return true;
        }

        public bool isValidName(string name)
        {
            string regex = @"[a-zA-Z]{2,}";
            return Regex.IsMatch(name, regex);
        }

        public string checkInput(string[] input)
        {
            //check input empty
            foreach (var text in input)
                if (string.IsNullOrEmpty(text))
                    return "Please fill in all required fields";

            //check username
            string username = input[0];
            if (isValidUsername(username) == false)
            {
                return "Username only contains number, alphabet and\nmust have at least 5 character";
            }

            //check pass
            string password = input[1];
            if (isValidPass(password) == false)
            {
                return "Password must contains number, alphabet and special character in !@#$%^&*.\n Password has length at least 8";
            }

            //check name
            string name = input[2];
            if (isValidName(name) == false)
            {
                return "Name is incorrect";
            }

            string phonenumber = input[3];
            //check phone number
            if (isValidPhoneNumber(phonenumber) == false)
            {
                return ("Phone number is incorrect");
            }

            return "";

        }

        public List<BindingAccount> search(List<BindingAccount> database, string keyword)
        {
            var accounts = Show();

            var account = accountdb.getAllAccount();
            var typeAccount = accountdb.getAllTypeAccount();
            var userInfo = accountdb.getAllUserInfo();

            var showdb = (from a in account
                          join b in typeAccount on a.TypeAccountID equals b.ID
                          join c in userInfo on a.ID equals c.UserID
                          where a.Username.ToLower().Contains($"{keyword.ToLower()}")
                          select new BindingAccount
                          {
                              ID = a.ID.ToString(),
                              UserName = a.Username,
                              TypeAccount = b.TypeAccount1,
                              Name = c.Name,
                              Dayofbirth = c.Dayofbirth,
                              Gender = c.Gender,
                              PhoneNumber = c.PhoneNumber,
                              Address = c.Address,
                              MoreInfo = c.MoreInfo,
                          }).ToList();
            List<BindingAccount> db = new List<BindingAccount>();
            foreach (var item in showdb)
            {
                db.Add(item);
            }
            return db;
        }

    }
}
