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
    public class FrontUser: BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; } // nice to have alan kaldirabiliriz gereksiz bulursak buradan.

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; } // optional alan

        public string Address { get; set; }

        public bool isCustomerCampaignMail { get; set; }

        public bool isCustomerCampaignSMS { get; set; }

        public int? UniversityID { get; set; }
        [ForeignKey("UniversityID")]
        public virtual University University { get; set; }

        public int UniversityClass { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<PerformancePoint> PerformancePoints { get; set; }

        public virtual List<PrivateMessage> PrivateMessages { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
