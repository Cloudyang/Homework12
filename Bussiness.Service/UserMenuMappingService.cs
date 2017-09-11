using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bussiness.Service
{
    public class UserMenuMappingService : BaseService<UserMenuMapping>
    {
        public UserMenuMappingService(DbContext context) : base(context)
        {
        }
        
    }
}
