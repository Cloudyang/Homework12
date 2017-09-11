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
    public class MenuService : BaseService<Menu>, IMenuService
    {
        public MenuService(DbContext context) : base(context)
        {
        }

        public int AddMenu(Menu menu)
        {
            return base.Insert(menu);
        }

        public int UpdateMenu(Menu menu)
        {
            return base.Update(menu);
        }

        public int DeleteMenu(Menu menu)
        {
            return base.Delete(menu);
        }

    }
}
