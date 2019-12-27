using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public string PhoneNuber { get; set; }
        public string Address { get; set; }
        public string MoreInfo{ get; set; }
    }
    class ManagerAcountBus
    {
        IDao accountdb = new Dao();
        public BindingList<BindingAccount> Show()
        {
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
                              PhoneNuber = c.PhoneNumber,
                              Address = c.Address,
                              MoreInfo = c.MoreInfo,
                          }).ToList();
            BindingList<BindingAccount> db = new BindingList<BindingAccount>();
            foreach (var item in showdb)
            {
                db.Add(item);
            }
            return db;
        }
    }
}
