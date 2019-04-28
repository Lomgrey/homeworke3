using System.Threading.Tasks;
using MassTransit;
using ModulSchool_HomeWork.Comands;
using ModulSchool_HomeWork.Services.Interfaces;

namespace ModulSchool_HomeWork.Consumers
{
    public class AddUserConsumer : IConsumer<AddUserCommand>
    {
        private IUserInfoService _userInfoService { get; }

        public AddUserConsumer(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task Consume(ConsumeContext<AddUserCommand> context)
        {
            await _userInfoService.AddNewUser(context.Message.User);
        }
    }
}