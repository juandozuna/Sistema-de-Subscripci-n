using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.WebReferencePedro;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class SuscripcionesPedro3
    {

        ManejadorServicios manejador = new ManejadorServicios();

        public void ActivarDesactivarSuscripcion(int id, bool estado)
        {


            var p = manejador.BuscarIDSuscripcion(id);
            if (p.success)
            {
                if (estado)
                {
                    manejador.ActivarSuscripcion(id);
                }
                else
                {
                    manejador.DesactivarSuscripcion(id);
                }
            }
            var buscar = manejador.BuscarIDSuscripcion(id);
            if (buscar.success)
            {
                if (estado)
                {
                    manejador.ActivarSuscripcion(id);
                }

                else
                {
                    manejador.DesactivarSuscripcion(id);
                }
            }
            
        }
    }
}