using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Messages;
using UserTesting.Application.Contracts.Persistence.Offices;
using UserTesting.Application.Contracts.Persistence.Roles;
using UserTesting.Application.Contracts.Persistence.Users;
using UserTesting.Domain.Entities.Roles;
using UserTesting.Domain.Entities.Users;
using UserTesting.Persistence.Configurations;
using UserTesting.Persistence.SqlServer.Repositories.ApplicationRoles;
using UserTesting.Persistence.SqlServer.Repositories.ApplicationUsers;
using UserTesting.Persistence.SqlServer.Repositories.Messages;
using UserTesting.Persistence.SqlServer.Repositories.Offices;

namespace UserTesting.Persistence.SqlServer
{
    public static class SqlServerPersistanceServicesRegistration
    {
        public static IServiceCollection AddSqlServerPersistenceServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseConfiguration"));
            services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddTransient<IUserStore<ApplicationUser>, ApplicationUsersRepository>();
            services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRolesRepository>();
            services.AddTransient<IUsersRepository, ApplicationUsersRepository>();
            services.AddTransient<IRolesRepository, ApplicationRolesRepository>();
            services.AddTransient<IOfficesRepository, OfficesRepository>();
            services.AddTransient<IMessagesRepository, UserMessagesRepository>();

            return services;

        }

    }
}
