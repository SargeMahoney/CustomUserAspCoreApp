using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Roles;

namespace UserTesting.Application.Features.UserManagements.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<DataResult<IEnumerable<ApplicationRole>>>
    {
    }
}
