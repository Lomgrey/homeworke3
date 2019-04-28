using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModulSchool_HomeWork.BuisnessLogic;
using ModulSchool_HomeWork.Models;

namespace ModulSchool_HomeWork.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersInfoRequestHandler _usersInfoRequestHandler;

        public UsersController(UsersInfoRequestHandler usersInfoRequestHandler)
        {
            _usersInfoRequestHandler = usersInfoRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<User> GetUserInfo(long id)
        {
            return _usersInfoRequestHandler.Handle(id);
        }

        [HttpPost]
        public Task<AddUserResult> AddOrUpdateUserInfo(User user)
        {
            return _usersInfoRequestHandler.Handle(user);
        }
    }
}
