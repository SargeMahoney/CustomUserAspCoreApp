using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Domain.Entities.Messages;
using UserTesting.Domain.Entities.Offices;
using UserTesting.Domain.Entities.Roles;

namespace UserTesting.Domain.Entities.Users
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }

        public Guid OfficeId { get; set; }

        public Guid RoleId { get; set; }

        public ApplicationRole Role { get; set; }
        public Office Office { get; set; }

        public List<Message> Messages { get; set; }


        public ApplicationUser()
        {
            Id = new Guid();
            AuthenticationType = string.Empty;
            Office = new Office();
            Messages = new List<Message>();
        }

        public bool IsInRole(string role)
        {
            if (Role == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Role.Name))
            {
                return false;
            }

            if (Role.Name == role)
            {
                return true;
            }

            return false;
        }
    }
}
