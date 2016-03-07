using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm // namespace yolundan .Base'i kaldirdim. Bu sayede entity classlarinda ctrl. yapmama gerek kalmadi ayni dosya yolunda olacaklari icin
{
    public class BaseEntity
    {
        public int ID { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }  // bu gerekiyor ama dikkat edelim buna urunu pasif ettiginde silinmemesi gerekiyor.

        public DateTime? AddDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        // daha ekleyecek kisa base property'ler olursa ekleriz 
    }
}
