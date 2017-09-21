using System.Collections.Generic;
using Entity.Model;
using Service.Model;

namespace Bussiness.IService
{
    public interface IMenuService : IBaseService<Menu>
    {
        TreeResult<MenuView> GetMenuTreeGrid();
        int AddMenuReturnId(Menu menu);
    }
}