using Bussiness.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.IService.Model;
using Entity.Model;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data.Entity;
using Service.Model;

namespace Bussiness.Service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(DbContext context) : base(context)
        {
        }
    }
}
