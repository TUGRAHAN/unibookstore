using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class PrivateMessage: BaseEntity
    {
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }

        public int MessageToUserID { get; set; }
        [ForeignKey("MessageToUserID")]
        public virtual FrontUser MessageToUser { get; set; }

        public int FrontUserID { get; set; }
        [ForeignKey("FrontUserID")]
        public virtual FrontUser FrontUser { get; set; }
    }
}
