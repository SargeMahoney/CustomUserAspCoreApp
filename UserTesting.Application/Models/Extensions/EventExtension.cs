using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class EventExtension
    {
        public static void Raise(this EventHandler eventHandler, object sender, EventArgs args)
        {
            if (eventHandler == null)
                return;
            eventHandler(sender, args);
        }
    }
}
