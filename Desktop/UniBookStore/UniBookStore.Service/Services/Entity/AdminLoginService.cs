using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm.Entity;
using UniBookStore.Service.Services.Base;

namespace UniBookStore.Service.Services.Entity
{
    public class AdminLoginService: BaseService<AdminUser>
    {
        public bool IsLogin(string userName, string password)
        {
            return db.AdminUsers.Any(x => x.UserName == userName && x.Password == password && x.IsActive == true);
        }
    }
}
