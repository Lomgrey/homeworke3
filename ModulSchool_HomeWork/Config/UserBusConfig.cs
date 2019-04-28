using System;
using MassTransit;

namespace ModulSchool_HomeWork.Config
{
    public class UserBusConfig
    {
        public static IBusControl BusControl { get; set; }

        public static void Configure()
        {
            // something

            BusControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
                cfg.ReceiveEndpoint(host, e => { /*do something*/ });
            });

            BusControl.Start();
        }
        
    }
}