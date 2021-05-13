using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Domain.Entities.Messages;
using UserTesting.Domain.Models.Messages;

namespace UserTesting.Application.Contracts.Infrastructure.Messages
{
    public interface IMessageEvent
    {
        event EventHandler Event_MessageSent;
        void NewMessages(MessageSetup message);
    }
}
