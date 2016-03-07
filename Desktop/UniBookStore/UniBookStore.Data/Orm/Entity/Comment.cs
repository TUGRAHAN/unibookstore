using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class Comment: BaseEntity
    {
        public string CommentContent { get; set; }

        public int? CommentToUserID { get; set; }
        [ForeignKey("CommentToUserID")]
        public virtual FrontUser CommentToUser { get; set; }

        public int? FrontUserID { get; set; }
        [ForeignKey("FrontUserID")]
        public virtual FrontUser FrontUser { get; set; }

    }
}
