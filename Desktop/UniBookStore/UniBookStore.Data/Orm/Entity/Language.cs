using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class Language: BaseEntity
    {
        public string LanguageName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
