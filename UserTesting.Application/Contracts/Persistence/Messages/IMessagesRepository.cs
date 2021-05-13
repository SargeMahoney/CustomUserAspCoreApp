using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Base;
using UserTesting.Domain.Entities.Messages;

namespace UserTesting.Application.Contracts.Persistence.Messages
{
    public interface IMessagesRepository : IAsyncRepository<Message>
    {
    }
}
