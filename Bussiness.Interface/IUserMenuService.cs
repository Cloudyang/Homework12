using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Bussiness.IService
{
    public interface IUserMenuService : IBaseService<UserMenuMapping>
    {
        void MappingUserMenu(User user, IEnumerable<Menu> menus);
        void MappingUserMenu(Menu menu, IEnumerable<User> users);
        void DeleteMappingByUser(User user);
        void DeleteMappingByMenu(Menu menu);
    }
}
