using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class Writer: BaseEntity
    {
        [Required(ErrorMessage = "Yazar alanı bos geçilemez"), DisplayName(" Yazar Adı: ")]
        public string BookWriter { get; set; }  // zorunu alan

        public virtual List<Book> Books { get; set; }
    }
}
