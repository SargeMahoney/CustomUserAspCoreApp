using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Models.Messages;

namespace UserTesting.Application.Features.Notifications.Command
{
    public class SendNotificationCommand : IRequest<BaseResult>
    {
        public MessageSetup Message { get; set; }
    }
}
