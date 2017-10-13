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

<<<<<<< HEAD
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
=======
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

>>>>>>> 31bc8f1d5e707b5d6ee1ba616b9946d2522ca229
        }
    }
}