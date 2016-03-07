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
    public class UniDepartment: BaseEntity
    {
        [Required(ErrorMessage = "Bölüm adı bos geçilemez"), DisplayName(" Bölüm adı: ")]
        public string UniDepartmentName { get; set; }

        public int FacultyID { get; set; }
        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }

        public virtual List<Book> Books { get; set; }


    }
}
