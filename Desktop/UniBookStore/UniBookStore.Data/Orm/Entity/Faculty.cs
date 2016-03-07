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
    public class Faculty: BaseEntity
    {
        [Required(ErrorMessage = "Fakülte adı bos geçilemez"), DisplayName(" Fakülte adı: ")]
        public string FacultyName { get; set; }

        public int UniversityID { get; set; }
        [ForeignKey("UniversityID")]
        public virtual University University { get; set; }

        public virtual List<UniDepartment> UniDepartments { get; set; }

    }
}
