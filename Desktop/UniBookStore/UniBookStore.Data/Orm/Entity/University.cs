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
    public class University: BaseEntity
    {
        [Required(ErrorMessage = "Universite adı bos geçilemez"), DisplayName(" Universite Adı: ")]
        public string UniversityName { get; set; }

        public int MainTypeID { get; set; }

        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        public virtual List<FrontUser> FrontUsers { get; set; }

        public virtual List<Faculty> Faculties { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
