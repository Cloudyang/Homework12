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

        public int AddUser(User user)
        {
            return base.Insert(user);
        }

        public int UpdateUser(User user)
        {
            return base.Update(user);
        }

        public int DeleteUser(User user)
        {
            return base.Delete(user.Id);
        }

        public IQueryable<User> GetAll()
        {
            return base.Set();
        }
    }
}
