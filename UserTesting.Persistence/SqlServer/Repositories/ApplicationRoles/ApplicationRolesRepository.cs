using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Roles;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Roles;
using UserTesting.Persistence.Configurations;
using UserTesting.Persistence.SqlServer._base;

namespace UserTesting.Persistence.SqlServer.Repositories.ApplicationRoles
{
    public class ApplicationRolesRepository : SqlDbBaseRepository, IRolesRepository
    {
        private readonly IMapper _mapper;

        public ApplicationRolesRepository(IDatabaseSettings dbConfig, IMapper mapper) : base(dbConfig)
        {
            this._mapper = mapper;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            using var _connection = Connection;

            var sql = "INSERT INTO dbo.ApplicationRoles " +
                "VALUES (@Name)";

            var rows = await _connection.ExecuteAsync(sql, new { role.Name });

            if (rows > 0)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {role.Name}." });
        }

        public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<IEnumerable<ApplicationRole>>> GetAll()
        {
            using var _connection = Connection;

            var sql = "SELECT * FROM dbo.ApplicationRoles ";

            var rows = await _connection.QueryAsync<ApplicationRoleDto>(sql);
            if (rows.Count() > 0)
            {
                var data= _mapper.Map<IEnumerable<ApplicationRole>>(rows);
                return new DataResult<IEnumerable<ApplicationRole>>(data);
            }
            else
            {
                return new DataResult<IEnumerable<ApplicationRole>>(success: false);
            }
  
        }

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
