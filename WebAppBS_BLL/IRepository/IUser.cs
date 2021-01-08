using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBS.Model;

namespace WebAppBS_BLL.IRepository
{
   public interface IUser
    {
        Task<User> AddUsers(User user);
        Task<List<User>> GetAll();
    }
}
