using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    class Dao
    {
        public BookstoreEntities DB { get; set; }
        public Dao()
        {
            DB = new BookstoreEntities();
        }
    }
}
