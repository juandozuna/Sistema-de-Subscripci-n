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

        public SerializedSuscripcion CrearSuscripcionNueva(int suscriptor, int servicio, int activado )
        {
            //El ID de CLIENTE DEL GRUPO 2 es 47 en el programa de Pedro;
            int cliente = 47;
            var result = manejador.CrearSuscripcion(suscriptor, cliente, servicio, activado);
            if (result.success)
            {
                var p = (int) result.data;
                var i = manejador.BuscarIDSuscripcion(p);
                if (i.success)
                {
                    var j = (SerializedSuscripcion) i.data;
                    return j;
                }
            }
            return null;

        }
    }
}