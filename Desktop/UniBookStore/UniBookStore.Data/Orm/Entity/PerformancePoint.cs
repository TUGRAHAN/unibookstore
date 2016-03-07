using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class PerformancePoint: BaseEntity
    {
        public int Point { get; set; }

        public int PointFromUserID { get; set; }

        public int PointToUserID { get; set; }

        public int FrontUserID { get; set; }
        [ForeignKey("FrontUserID")]
        public virtual FrontUser FrontUser { get; set; }

    }
}
