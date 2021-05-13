using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Features.UserManagements.Roles.Commands.AddRole;
using UserTesting.Application.Features.UserManagements.Roles.Queries.GetAllRoles;
using UserTesting.Domain.Entities.Roles;

namespace MediatR
{
    public class MediatorRolesExtension
    {
        private readonly IMapper _mapper;

        public MediatorRolesExtension(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public GetAllRolesQuery GetAll()
        {
            return new GetAllRolesQuery();
        }

        public AddRoleCommand Add(ApplicationRole applicationRole)
        {          
            return _mapper.Map<AddRoleCommand>(applicationRole);
        }

    }
}
