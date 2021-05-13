using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Infrastructure.Messages;
using UserTesting.Domain.Entities.Messages;
using UserTesting.Domain.Models.Messages;

namespace UserTesting.Infrastructure.Messages
{
    public class MessageEvent : IMessageEvent
    {
        public event EventHandler Event_MessageSent;


        public void NewMessages(MessageSetup message)
        {
            Event_MessageSent.Raise(message, new EventArgs());
        }
    }
}
