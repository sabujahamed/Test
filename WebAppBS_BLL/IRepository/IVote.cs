using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBS.Model;

namespace WebAppBS_BLL.IRepository
{
   public interface IVote
    {

        Task<LikeOrDisLikes> AddLikeOrDisLikes(LikeOrDisLikes vote);
        Task<List<LikeOrDisLikes>> GetAll();
    }
}
