using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class Publisher: BaseEntity
    {
        public string PublisherName { get; set; }

        public virtual List<BookPublisherInterim> Books { get; set; }
    }
}
