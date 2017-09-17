using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bussiness.IService;

namespace Bussiness.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(DbContext context) : base(context)
        {
        }

        public int AddUsserReturnId(User user)
        {
            dbSet.Add(user);
            base.Commit();
            return user.Id;
        }
    }
}
