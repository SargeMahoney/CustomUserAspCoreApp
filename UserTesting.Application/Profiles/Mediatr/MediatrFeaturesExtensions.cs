using AutoMapper;
using UserTesting.Application.Profiles.Mediatr.Users;

namespace MediatR
{
    public static class MediatrFeaturesExtensions
    {

        public static MediatorOfficeExtension Offices(this IMediator mediator)
        {
            return new MediatorOfficeExtension();
        }

        public static MediatorRolesExtension Roles(this IMediator mediator, IMapper mapper)
        {
            return new MediatorRolesExtension(mapper);
        }

        public static MediatorMessagesExtension Messages(this IMediator mediator, IMapper mapper)
        {
            return new MediatorMessagesExtension(mapper);
        }



        public static MediatorUsersExtension Users(this IMediator mediator)
        {
            return new MediatorUsersExtension();
        }

        public static MediatorNotificationExtension Notifications(this IMediator mediator)
        {
            return new MediatorNotificationExtension();
        }
    }
 
}
