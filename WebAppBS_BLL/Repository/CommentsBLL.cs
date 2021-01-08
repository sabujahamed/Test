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
   public class CommentsBLL : IComments
    {

        private readonly AspContext _aspContext;
        public CommentsBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public async Task<Comments> AddComments(Comments comments)
        {
            try
            {
                var res = await _aspContext.Comments.AddAsync(comments);
                await _aspContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Comments>> GetAll()
        {
            return await _aspContext.Comments.ToListAsync();
        }
    }
}
