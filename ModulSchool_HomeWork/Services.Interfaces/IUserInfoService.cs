using System;
using System.Threading.Tasks;
using ModulSchool_HomeWork.Models;

namespace ModulSchool_HomeWork.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
        Task AddNewUser(User user);
    }
}