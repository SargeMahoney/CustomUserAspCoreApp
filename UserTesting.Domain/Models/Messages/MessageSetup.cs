using System;
using System.Collections.Generic;

namespace UserTesting.Domain.Models.Messages
{
    public class MessageSetup
    {
        public string Title { get; set; }
        public string MessageBody { get; set; }

        public List<Guid> OfficesId { get; set; }

        public MessageSetup()
        {
            OfficesId = new List<Guid>();
            MessageBody = string.Empty;
            Title = string.Empty;
        }
    }
}
