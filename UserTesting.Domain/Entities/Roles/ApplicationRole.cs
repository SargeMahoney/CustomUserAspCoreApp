using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTesting.Domain.Entities.Roles
{
    public class ApplicationRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }




        public ApplicationRole()
        {
            Id = new Guid();
            Name = string.Empty;
        }



    }
}
