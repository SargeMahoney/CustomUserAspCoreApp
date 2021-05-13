using AutoMapper;
using MediatR;
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

namespace UserTesting.Application.Features.UserManagements.Roles.Commands.AddRole
{
    public class AddRoleHandler : IRequestHandler<AddRoleCommand, BaseResult>
    {
        private readonly IMapper _mapper;
        private readonly IRoleStore<ApplicationRole> _rolesRepository;

        public AddRoleHandler(IMapper mapper, IRoleStore<ApplicationRole> rolesRepository)
        {
            this._mapper = mapper;
            this._rolesRepository = rolesRepository;
        }
        public async Task<BaseResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var newRole = _mapper.Map<ApplicationRole>(request);
            var newRoleResult = await _rolesRepository.CreateAsync(newRole, cancellationToken);
            if (newRoleResult.Succeeded)
            {
                return new BaseResult();
            }
            else
            {
                return new BaseResult(success: false);
            }
        }
    }
}
