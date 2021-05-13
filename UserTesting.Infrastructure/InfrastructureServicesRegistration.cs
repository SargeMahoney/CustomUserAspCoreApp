using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Infrastructure.Messages;
using UserTesting.Application.Contracts.Infrastructure.ViewModels.MessagesPage;
using UserTesting.Infrastructure.Messages;
using UserTesting.Infrastructure.ViewModels.MessagePage;

namespace UserTesting.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
       

            services.AddSingleton<IMessageEvent,MessageEvent>();

            services.AddScoped<IMessagesPage, MessagePageVm>();
        

            return services;

        }
    }
}
