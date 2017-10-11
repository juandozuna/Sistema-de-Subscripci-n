using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.ServicioPedro;

namespace MVCSuscriptionSystem.WebServices
{
    public class PedroWebServiceMethods
    {
        private ManejadorServicios t = new ManejadorServicios();

        public List<Servicio> GetServiciosPedro()
        {
            List<Servicio> servicios = null;
            var p = t.Servicios();
            if (p.success)
            {
                var d = (SerializedServicio[]) p.data;
                var dl = d.ToList();
                servicios = dl.Select(x => new Servicio(){Nombre = x.nombre, Precio = x.precio}).ToList();

            }

            return servicios;


        }


    }
}