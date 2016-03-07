using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm.Entity;
using UniBookStore.Service.Services.Base;

namespace UniBookStore.Service.Services.Entity
{
    public class AdminRegisterService: BaseService<AdminUser>
    {
        public bool IsRegisterUserName(string userName)
        {
            return db.AdminUsers.Any(x => (x.UserName == userName) && x.IsActive == true);
        }

        public bool IsRegisterEmail(string email)
        {
            return db.AdminUsers.Any(x => (x.Email == email) && x.IsActive == true);
        }
    }
}
