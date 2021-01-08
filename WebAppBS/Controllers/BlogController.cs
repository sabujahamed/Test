using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBS.Model;
using WebAppBS.Model.VM;
using WebAppBS_BLL.IRepository;
namespace WebAppBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlog _blog;
        public BlogController(IBlog blog)
        {
            this._blog = blog;
        }

        [HttpPost("AddPost")]
        public ActionResult AddPost(Blog blog)
        {
            return new JsonResult(this._blog.AddBlog(blog));
        }

        [HttpGet("GetBlogDetails")]
        public async Task<ActionResult> GetBlogDetails(BlogFilterPagination blogFilter)
        {

            try
            {
                var res = await this._blog.GetUserBlogDetails(blogFilter);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
