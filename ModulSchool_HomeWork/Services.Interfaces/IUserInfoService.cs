using System;
using System.Threading.Tasks;
using ModulSchool_HomeWork.Models;

namespace ModulSchool_HomeWork.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(long id);
        Task<AddUserResult> AddNewUser(User user);
    }
}