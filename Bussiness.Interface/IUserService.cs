using System.Linq;
using Entity.Model;

namespace Bussiness.Service
{
    public interface IUserService
    {
        int Add(User user);
        int Delete(User user);
        IQueryable<User> GetAll();
        int Update(User user);
    }
}