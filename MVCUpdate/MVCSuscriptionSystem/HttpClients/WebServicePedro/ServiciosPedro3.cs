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
        
        private ManejadorServicios manager;

        public ServiciosPedro3()
        {
            manager = new ManejadorServicios();
        }

        public List<Servicio> GetServicios()
        {
            List<Servicio> servicios = null;
            var result = manager.Servicios();
            if (result.success)
            {
                var serializedServicios = (SerializedServicio[])result.data;
                servicios = serializedServicios.Select(d => new Servicio()
                {
                    Nombre = d.nombre,
                    Precio = d.precio,
                    IDPedro = d.id,
                    IDErick = 0
                    
                }).ToList();

            }

            return servicios;

        }

        public Servicio GetSingleServicio(int id)
        {
            var result = manager.BuscarIDServicio(id);
            Servicio servicio = null;
            if (result.success)
            {
                var r = (SerializedServicio) result.data;
                servicio = new Servicio(){
                    Nombre = r.nombre,
                    Precio = r.precio,
                    IDPedro = r.id,
                    IDErick = 0
                };

            }
            return servicio;
        }

        public Servicio PostServicio(Servicio s)
        {
            var result = manager.CrearServicio(s.Nombre, s.Nombre, float.Parse(s.Precio.ToString()));
            if (result.success)
            {
                var data = (int)result.data;
                return s;
            }

            return null;
        }


        public bool BorrarServicio(int id)
        {
            var result = manager.BorrarServicio(id);
            if (result.success)
            {
                return true;
            }
            return false;
        }

        public bool Modificar(int id, Servicio servicio)
        {
            if (GetSingleServicio(id) != null)
            {
                var m = manager.EditarNombreServicio(id, servicio.Nombre);
                var n = manager.EditarPrecioServicio(id, servicio.Precio);
                return true;
            }
            return false;
        }



    }
}