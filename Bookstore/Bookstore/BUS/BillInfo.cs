using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BUS
{
    class BillInfo
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int Unit { set; get; }
        public int BasisPrice { set; get; }
        public int Price { set; get; }
        public int Cost { set; get; }
    }
}
