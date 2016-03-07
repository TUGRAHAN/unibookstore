using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm.Entity;
using UniBookStore.Service.Services.Base;

namespace UniBookStore.Service.Services.Entity
{
    public class UniversityService: BaseService<University>
    {
        public bool UniversityNameControl(string name)
        {
            return db.Universities.Any(x => x.UniversityName == name);
        }

        public string GetUniversityName(int id)
        {
            return db.Universities.Find(id).UniversityName;
        }
    }
}
