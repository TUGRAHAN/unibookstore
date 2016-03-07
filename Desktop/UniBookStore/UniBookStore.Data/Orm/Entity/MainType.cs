using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class MainType: BaseEntity
    {
        [Required(ErrorMessage = "Tip alanı bos geçilemez"), DisplayName(" Tipi: ")]
        public string MainTypeName { get; set; }

        public virtual List<Course> Courses { get; set; }






    }
}
