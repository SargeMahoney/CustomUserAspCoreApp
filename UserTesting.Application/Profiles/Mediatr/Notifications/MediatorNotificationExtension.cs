using UserTesting.Application.Features.Notifications.Command;
using UserTesting.Domain.Models.Messages;

namespace MediatR
{
    public class MediatorNotificationExtension
    {
        public MediatorNotificationExtension()
        {
          
        }

        public SendNotificationCommand SendNotificationAboutMessage(MessageSetup message)
        {
            var command = new SendNotificationCommand();
            command.Message = message;
            return command;
        }
    }
}
