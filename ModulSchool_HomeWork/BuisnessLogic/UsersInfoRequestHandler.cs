using System;
using System.Threading.Tasks;
using ModulSchool_HomeWork.Models;
using ModulSchool_HomeWork.Services.Interfaces;

namespace ModulSchool_HomeWork.BuisnessLogic
{
    public class UsersInfoRequestHandler
    {
        private readonly IUserInfoService _userInfoService;

        public UsersInfoRequestHandler(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public Task<User> Handle(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Некорректный идентификатор пользователя", nameof(id));
            }

            return _userInfoService.GetById(id);
        }

        public Task<AddUserResult> Handle(User user)
        {
            if (!user.IsInitialize())
            {
                throw new ArgumentException("Неккоректные данные пользователя", nameof(user));
            }

            return _userInfoService.AddNewUser(user);
        }
    }
}