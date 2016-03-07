using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm.Entity;
using UniBookStore.Service.Services.Base;

namespace UniBookStore.Service.Services.Entity
{
    public class MainTypeService: BaseService<MainType>
    {
        public bool MainTypeNameControl(string name)
        {
            return db.MainTypes.Any(x => x.MainTypeName == name);
        }

        public string GetMainTypeName(int id)
        {
            return db.MainTypes.Find(id).MainTypeName;
        }
    }
}
