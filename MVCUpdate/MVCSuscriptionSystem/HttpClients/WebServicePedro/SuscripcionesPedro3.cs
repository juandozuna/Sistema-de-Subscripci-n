using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.WebReferencePedro;

namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class SuscripcionesPedro3
    {

        ManejadorServicios s = new ManejadorServicios();

        public void test(int id, bool estado)
        {

            var p = s.BuscarIDSuscripcion(id);
            if (p.success)
            {
                if (estado)
                {
                    s.ActivarSuscripcion(id);
                }
                else
                {
                    s.DesactivarSuscripcion(id);
                }
            }
        }
    }
}