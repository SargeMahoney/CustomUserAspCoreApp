using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Roles;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Roles;

namespace UserTesting.Application.Features.UserManagements.Roles.Queries.GetAllRoles
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, DataResult<IEnumerable<ApplicationRole>>>
    {
        private readonly IRolesRepository _rolesRepository;

        public GetAllRolesHandler(IRolesRepository rolesRepository)
        {
            this._rolesRepository = rolesRepository;
        }
        public async Task<DataResult<IEnumerable<ApplicationRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _rolesRepository.GetAll();
            if (roles.Success)
            {
                return new DataResult<IEnumerable<ApplicationRole>>(roles.GetData());
            }
            else
            {
                return new DataResult<IEnumerable<ApplicationRole>>(success: false);
            }
         
        }
    }
}
