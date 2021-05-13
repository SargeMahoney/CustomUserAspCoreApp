using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Infrastructure.Messages;
using UserTesting.Application.Models.Results;

namespace UserTesting.Application.Features.Notifications.Command
{
    public class SendNotificationHandler : IRequestHandler<SendNotificationCommand, BaseResult>
    {
        private readonly IMessageEvent _messageEvent;

        public SendNotificationHandler(IMessageEvent messageEvent)
        {
            this._messageEvent = messageEvent;
        }

        public async Task<BaseResult> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            _messageEvent.NewMessages(request.Message);

            return new BaseResult();
        }
    }
}
