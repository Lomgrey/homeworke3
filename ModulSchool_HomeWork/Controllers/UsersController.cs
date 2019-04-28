using System;
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
        private readonly GetUsersInfoRequestHandler _getUsersInfoRequestHandler;
        private readonly AddUserRequestHandler _addUserRequestHandler;

        public UsersController(GetUsersInfoRequestHandler getUsersInfoRequestHandler, AddUserRequestHandler addUserRequestHandler)
        {
            _getUsersInfoRequestHandler = getUsersInfoRequestHandler;
            _addUserRequestHandler = addUserRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUsersInfoRequestHandler.Handle(id);
        }

        [HttpPost("add")]
        public Task<User> AddUserInfo([FromBody]User user)
        {
            var id = Guid.NewGuid();
            user.Id = id;
            
            return _addUserRequestHandler.Handle(user);
        }
    }
}
