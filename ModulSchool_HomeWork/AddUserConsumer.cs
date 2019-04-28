using System.Threading.Tasks;
using MassTransit;
using ModulSchool_HomeWork.Models;
using ModulSchool_HomeWork.Services;

namespace ModulSchool_HomeWork
{
    public class AddUserConsumer : IConsumer<IAddUser>
    {
        private UserInfoService _userInfoService;

        public AddUserConsumer(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task Consume(ConsumeContext<IAddUser> context)
        {
            var addUser = context.Message;

            await _userInfoService.AddNewUser(new User()
            {
                Email = addUser.Email,
                Nickname = addUser.Nickname,
                Phone = addUser.Phone
            });
            
            
        }
    }
}