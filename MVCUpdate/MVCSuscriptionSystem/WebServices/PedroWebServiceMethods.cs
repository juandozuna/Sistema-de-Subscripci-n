using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.ServicioPedro;

namespace MVCSuscriptionSystem.WebServices
{
    public class PedroWebServiceMethods
    {
       

        public static SOAPResponse GetServicios()
        {
            var t = new ServicioPedro.ServiciosResponseBody().ServiciosResult;
            return t;
        }

    }
}