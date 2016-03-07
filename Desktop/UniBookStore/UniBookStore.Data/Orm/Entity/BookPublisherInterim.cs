using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class BookPublisherInterim
    {
        public int ID { get; set; } // codefirst icerisinde db'de primary key tanimlamasi icin bunu eklemek zorundayim. yoksa tablo olusmaz. base entity'den miras almadik ayrica ID kolonu yarattik

        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
