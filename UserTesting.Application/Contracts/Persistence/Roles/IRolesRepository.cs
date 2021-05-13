using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Roles;

namespace UserTesting.Application.Contracts.Persistence.Roles
{
    public interface IRolesRepository : IRoleStore<ApplicationRole>
    {
        Task<DataResult<IEnumerable<ApplicationRole>>> GetAll();
    }
}
