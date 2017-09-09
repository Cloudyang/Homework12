using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IService
{
    public interface ICategoryService 
    {
        IQueryable<TEntity> GetAll<TEntity>(Expression<Func<Category, TEntity>> selector);

        IQueryable<Category> GetAll();
    }
}
