using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBS.Model;

namespace WebAppBS_BLL.IRepository
{
   public interface IComments
    {
        Task<Comments> AddComments(Comments post);
        Task<List<Comments>> GetAll();
    }
}
