using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;


namespace UserTesting.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
         


            return services;
        }
    }
}
