using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bussiness.Service
{
    public class MenuService : BaseService<Menu>
    {
        public MenuService(DbContext context) : base(context)
        {
        }

        public int Add(Menu menu)
        {
            return base.Insert(menu);
        }

        public int Update(Menu menu)
        {
            return base.Update(menu);
        }

        public int Delete(Menu menu)
        {
            return base.Delete(menu);
        }

        public int AccreditUser(IEnumerable<User> users)
        {
            return 0;
        }
    }
}
