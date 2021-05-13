using AutoMapper;
using UserTesting.Application.Features.UserManagements.Messages.Command.AddMessage;
using UserTesting.Application.Features.UserManagements.Roles.Commands.AddRole;
using UserTesting.Application.Features.UserManagements.Users.Commands.AddUser;
using UserTesting.Domain.Entities.Messages;
using UserTesting.Domain.Entities.Offices;
using UserTesting.Domain.Entities.Roles;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Application.Profiles.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationRole, ApplicationRoleDto>().ReverseMap();
            CreateMap<ApplicationRole, AddRoleCommand>().ReverseMap();
            CreateMap<ApplicationUser, AddUserCommand>().ReverseMap();
            CreateMap<Office, OfficeDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<AddMessageCommand, Message>().ReverseMap();
        }
    }
}
