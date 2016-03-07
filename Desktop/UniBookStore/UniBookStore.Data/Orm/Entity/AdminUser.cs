using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class AdminUser: BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; } // nice to have alan kaldirabiliriz gereksiz bulursak buradan.

        public string Email { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; } // rolleme yapmak icin kullaniyorum
    }
}
