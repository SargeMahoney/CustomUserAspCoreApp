using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Roles;
using UserTesting.Application.Contracts.Persistence.Users;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Roles;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Application.Features.UserManagements.Users.Commands.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand,BaseResult>
    {
        private readonly IMapper _mapper;
        private readonly IUserStore<ApplicationUser> _usersRepository;
        private readonly IRoleStore<ApplicationRole> _rolesRepository;

        public AddUserHandler(IMapper mapper, IUserStore<ApplicationUser> usersRepository, IRoleStore<ApplicationRole> rolesRepository)
        {
            this._mapper = mapper;
            this._usersRepository = usersRepository;
            this._rolesRepository = rolesRepository;
        }
        public async Task<BaseResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = this._mapper.Map<ApplicationUser>(request);
                var newUserResult = await this._usersRepository.CreateAsync(newUser,cancellationToken);
                if (newUserResult.Succeeded)
                {
                
                    return new BaseResult();
                }
                else
                {
                    return new BaseResult(success: false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
