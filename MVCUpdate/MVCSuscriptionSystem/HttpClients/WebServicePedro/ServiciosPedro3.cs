using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.WebReferencePedro;

namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class ServiciosPedro3
    {
        
        private ManejadorServicios manager = new ManejadorServicios();

        public List<Servicio> GetServicios()
        {
            List<Servicio> servicios = null;
            var result = manager.Servicios();
            if (result.success)
            {
                var serializedServicios = (SerializedServicio[])result.data;
                servicios = serializedServicios.Select(d => new Servicio(){Nombre = d.nombre, Precio = d.precio}).ToList();

            }

            return servicios;

        }



    }
}