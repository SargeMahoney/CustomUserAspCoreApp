using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTesting.Persistence.Configurations
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CurrentConnection { get; set; }
    }
}
