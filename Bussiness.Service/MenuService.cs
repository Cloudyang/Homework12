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
    }
}
