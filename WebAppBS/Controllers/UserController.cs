using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBS.Model;
using WebAppBS_BLL.IRepository;

namespace WebAppBS.Controllers
{
    [Route("api/[User]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            this._user = user;
        }

        [HttpPost("AddUser")]
        public ActionResult AddUser(User user)
        {
            return new JsonResult(this._user.AddUsers(user));
        }



    }
}
