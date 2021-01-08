using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBS.Model;
using WebAppBS_BLL.IRepository;
using WebAppDBContext;

namespace WebAppBS_BLL.Repository
{
   public class UserBLL : IUser
    {
        private readonly AspContext _aspContext;
        public UserBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public async Task<User> AddUsers(User user)
        {
            try
            {
                var res = await _aspContext.User.AddAsync(user);
                await _aspContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _aspContext.User.ToListAsync();
        }

    }
}
