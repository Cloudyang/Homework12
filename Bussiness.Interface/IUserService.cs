using System.Linq;
using Entity.Model;

namespace Bussiness.IService
{
    public interface IUserService : IBaseService<User>
    {
        int AddUser(User user);
        int DeleteUser(User user);
        IQueryable<User> GetAll();
        int UpdateUser(User user);
        //  int BindingMenu(Menu menu);
    }
}