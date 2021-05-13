using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Roles;
using UserTesting.Application.Contracts.Persistence.Users;
using UserTesting.Application.Features.UserManagements.Offices.Queries.GetAll;
using UserTesting.Application.Features.UserManagements.Roles.Queries.GetAllRoles;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Users;
using UserTesting.Persistence.Configurations;
using UserTesting.Persistence.SqlServer._base;

namespace UserTesting.Persistence.SqlServer.Repositories.ApplicationUsers
{
    public class ApplicationUsersRepository : SqlDbBaseRepository, IUsersRepository
    {
       
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;

        public ApplicationUsersRepository(IDatabaseSettings dbConfig, IMediator mediatr, IMapper mapper) : base(dbConfig)
        {
           
            this._mediatr = mediatr;
            this._mapper = mapper;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {

            try
            {
                using var _connection = Connection;

                var sql = "INSERT INTO ApplicationUsers (Username, Password,Name)" +
                    "VALUES (@UserName, @Password, @Name)";

                var rows = await _connection.ExecuteAsync(sql, new { user.UserName, user.Password, user.Name });

                if (rows > 0)
                {
                    return IdentityResult.Success;
                }
                return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Name}." });
            }
            catch (Exception ex)
            {

                throw;
            }
      
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
         
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using var _connection = Connection;
            var sql = "SELECT * " +
                       "FROM ApplicationUsers " +
                       "WHERE Id = @Id;";

          
          

           var myUser = await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                Id = userId
            });
            await ElaborateUserData(myUser);

            return myUser;
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using var _connection = Connection;

            string sql = "SELECT * " +
                         "FROM ApplicationUsers " +
                         "WHERE UserName = @UserName;";

            var myUser = await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                UserName = normalizedUserName
            });

            await ElaborateUserData(myUser);
            return myUser;
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            using var _connection = Connection;

            string sql = "SELECT * " +
                         "FROM ApplicationUsers " +
                         "WHERE UserName = @UserName;";

            var result = await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                UserName = user.UserName
            });

            return result.Id.ToString();
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

         //   user.Name = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Password);
        }
        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult<bool>(!String.IsNullOrEmpty(user.Password));
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (passwordHash == null) throw new ArgumentNullException(nameof(passwordHash));

            user.Password = passwordHash;
            return Task.FromResult<object>(null);

        }

        public bool CheckIfOffice(string userName,string officeName)
        {
            return true;
        }

        public async Task<DataResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            using var _connection = Connection;
            var sql = "SELECT * " +
                       "FROM ApplicationUsers ";




            var myUsers = await _connection.QueryAsync<ApplicationUser>(sql);
            await ElaborateUsersData(myUsers);

            return new DataResult<IEnumerable<ApplicationUser>>(myUsers);
        }

        private async Task ElaborateUsersData(IEnumerable<ApplicationUser> myUsers)
        {
            var roles = await _mediatr.Send(new GetAllRolesQuery());
            if (roles.Success)
            {
                foreach (var user in myUsers)
                {
                    user.Role = roles.GetData().FirstOrDefault(x => x.Id == user.RoleId);
                }

            }

            var offices = await _mediatr.Send(_mediatr.Offices().GetAll());
            if (offices.Success)
            {
                foreach (var user in myUsers)
                {
                    user.Office = offices.GetData().FirstOrDefault(x => x.Id == user.OfficeId);
                }             
            }

            var messages = await _mediatr.Send(_mediatr.Messages(_mapper).GetAll());
            if (messages.Success)
            {
                foreach (var user in myUsers)
                {
                    user.Messages = messages.GetData().Where(x => x.UserName == user.UserName).ToList();
                }
            }

        }

        private async Task ElaborateUserData(ApplicationUser myUsers)
        {
            var roles = await _mediatr.Send(new GetAllRolesQuery());
            if (roles.Success)
            {
                myUsers.Role = roles.GetData().FirstOrDefault(x => x.Id == myUsers.RoleId);                
            }

            var offices = await _mediatr.Send(_mediatr.Offices().GetAll());
            if (offices.Success)
            {
                myUsers.Office = offices.GetData().FirstOrDefault(x => x.Id == myUsers.OfficeId);
            }

            var messages = await _mediatr.Send(_mediatr.Messages(_mapper).GetAll());
            if (messages.Success)
            {
                myUsers.Messages = messages.GetData().Where(x => x.UserName == myUsers.UserName).ToList();
            }
        }
    }
}
