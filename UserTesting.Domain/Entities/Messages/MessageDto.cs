using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTesting.Domain.Entities.Messages
{
    public class MessageDto
    {

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; set; }
        public bool IsReaded { get; set; }
    }
}
