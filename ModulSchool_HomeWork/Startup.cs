using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModulSchool_HomeWork.BuisnessLogic;
using ModulSchool_HomeWork.Services;
using ModulSchool_HomeWork.Services.Interfaces;
using ModulSchool_HomeWork.Consumers;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.Hosting;
using ModulSchool_HomeWork.Comands;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace ModulSchool_HomeWork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<GetUsersInfoRequestHandler>();
            services.AddScoped<AddUserRequestHandler>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddScoped<AddUserConsumer>();
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AddUserConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host("localhost", "/", h => { });
                    
                    cfg.ReceiveEndpoint(host, "add-user", e =>
                    {
                        e.PrefetchCount = 16;
                        
                        e.ConfigureConsumer<AddUserConsumer>(provider);
                        EndpointConvention.Map<AddUserCommand>(e.InputAddress);
                    });
                }));
                
                x.AddRequestClient<AddUserCommand>();
            });
            
            services.AddSingleton<IHostedService, BusService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}