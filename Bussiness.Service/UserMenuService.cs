using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Bussiness.IService;
using System.Data.Entity;

namespace Bussiness.Service
{
    public class UserMenuService : BaseService<UserMenuMapping>, IUserMenuService
    {
        private DbSet<User> _UserDbSet;
        private DbSet<Menu> _MenuDbSet;

        public UserMenuService(DbContext context) : base(context)
        {
            this._UserDbSet = context.Set<User>();
            this._MenuDbSet = context.Set<Menu>();
        }

        public void DeleteMappingByMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void DeleteMappingByUser(User user)
        {
            throw new NotImplementedException();
        }

        public void MappingUserMenu(Menu menu, IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        public void MappingUserMenu(User user, IEnumerable<Menu> menus)
        {
            throw new NotImplementedException();
        }
    }
}
