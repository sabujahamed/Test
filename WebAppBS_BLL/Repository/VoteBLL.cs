using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppBS.Model;
using WebAppBS_BLL.IRepository;
using WebAppDBContext;

namespace WebAppBS_BLL.Repository
{
   public class VoteBLL : IVote
    {
        private readonly AspContext _aspContext;
        public VoteBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public async Task<LikeOrDisLikes> AddLikeOrDisLikes(LikeOrDisLikes vote)
        {
            try
            {
                var res = await _aspContext.LikeOrDisLikes.AddAsync(vote);
                await _aspContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LikeOrDisLikes>> GetAll()
        {
            return await _aspContext.LikeOrDisLikes.ToListAsync();
        }
    }
}
