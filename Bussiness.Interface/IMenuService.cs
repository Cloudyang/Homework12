using System.Collections.Generic;
using Entity.Model;

namespace Bussiness.IService
{
    public interface IMenuService : IBaseService<Menu>
    {
        int AddMenu(Menu menu);
        int DeleteMenu(Menu menu);
        int UpdateMenu(Menu menu);
    }
}