using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class Course: BaseEntity
    {
        [Required(ErrorMessage = "Ders adı alanı bos geçilemez"), DisplayName(" Ders Adı: ")]
        public string CourseName { get; set; }

        public int MainTypeID { get; set; }
        [ForeignKey("MainTypeID")]
        public virtual MainType MainType { get; set; }

        public virtual List<University> Universities { get; set; }

    }
}
