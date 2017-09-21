using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bussiness.IService;
using Service.Model;

namespace Bussiness.Service
{
    public class MenuService : BaseService<Menu>, IMenuService
    {
        public MenuService(DbContext context) : base(context)
        { }

        public int AddMenuReturnId(Menu menu)
        {
            dbSet.Add(menu);
            base.Commit();
            return menu.Id;
        }

        public TreeResult<MenuView> GetMenuTreeGrid()
        {
            var menus = base.Set();
            var queryable = menus.Where(o => o.ParentId > 0)
                            .Select(m => new MenuView
                            {
                                Id = m.Id,
                                Description = m.Description,
                                Name = m.Name,
                                Url = m.Url,
                                Sort = m.Sort,
                                _parentId = m.ParentId
                            }).Union(menus.Where(o => o.ParentId == 0)
                            .Select(m => new MenuView
                            {
                                Id = m.Id,
                                Description = m.Description,
                                Name = m.Name,
                                Url = m.Url,
                                Sort = m.Sort,
                                _parentId =null
                            }));
            TreeResult<MenuView> treeResult = new TreeResult<MenuView>()
            {
                total = menus.Count(),
                rows = queryable
            };

            return treeResult;
        }

    }
}
