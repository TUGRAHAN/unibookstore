using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class ImagePath: BaseEntity
    {
        public string BookImagePath { get; set; }      // zorunu alan eklenecek kitap fotograflarinin yollari bu kolonda tutulacak db'de. multifile upload olmali

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
    }
}
