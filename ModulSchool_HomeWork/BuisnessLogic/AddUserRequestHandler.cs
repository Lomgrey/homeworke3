using System;
using System.Threading.Tasks;
using MassTransit;
using ModulSchool_HomeWork.Comands;
using ModulSchool_HomeWork.Models;
using ModulSchool_HomeWork.Services.Interfaces;

namespace ModulSchool_HomeWork.BuisnessLogic
{
    public class AddUserRequestHandler
    {
        private IBusControl _busControl;

        public AddUserRequestHandler(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public Task<User> Handle(User user)
        {
            user.Id = Guid.NewGuid();

            _busControl.Send(new AddUserCommand
            {
                User = user
            });

            return Task.FromResult(user);

        }
    }
}