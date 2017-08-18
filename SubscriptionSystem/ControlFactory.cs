using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public class ControlFactory
    {
        public static AControl ControlObject(string op)
        {        
            Int32.TryParse(op, out int opcion);
            switch (opcion)
            {
                case 1:
                    return new ClientManager();
                case 2:
                    return new ServiceManager();
                case 3:
                    return new PlanManager();
            }
            return null;
        }
    }
}
