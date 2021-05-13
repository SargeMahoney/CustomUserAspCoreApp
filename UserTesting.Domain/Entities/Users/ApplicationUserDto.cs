using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTesting.Domain.Entities.Users
{
    public class ApplicationUserDto
    {
        public virtual Guid Id { get; set; } 
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }     
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }

        public Guid OfficeId { get; set; }

        public Guid RoleId { get; set; }
    }
}
