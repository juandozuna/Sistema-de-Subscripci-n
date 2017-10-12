using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.WebReferencePedro;

namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class SuscripcionesPedro3
    {
        private ManejadorServicios manager;

        public SuscripcionesPedro3()
        {
            manager = new ManejadorServicios();
        }

        public List<SerializedSuscripcion> GetSuscripciones()
        {
            var result = manager.Suscripciones();
            List<SerializedSuscripcion> suscripciones = null;
            if (result.success)
            {
                var p = (SerializedSuscripcion[]) result.data;
                suscripciones = p.ToList();
            }
            return suscripciones;
        }

        public SerializedSuscripcion GetSingleSuscripcion(int id)
        {
            SerializedSuscripcion suscripcion = null;
            var result = manager.BuscarIDSuscripcion(id);
            if (result.success)
            {
                suscripcion = (SerializedSuscripcion) result.data;
            }
            return suscripcion;
        }

        public bool CrearSuscripcion(int suscriptor, int cliente, int servicio, int activado)
        {
            var result = manager.CrearSuscripcion(suscriptor, cliente, servicio, activado);
            if (result.success)
            {
                var p = (int) result.data;
                return true;
            }

            return false;
        }

        public bool BorrarSuscripcion(int id)
        {
            var result = manager.BorrarSuscripcion(id);
            if (result.success)
            {
                return true;
            }
            return false;
        }

        public void ActiivarDesactivarSuscripcion(int IdSuscripcion, int estado)
        {
            if (GetSingleSuscripcion(IdSuscripcion) != null)
            {
                if (estado == 1)
                {
                    manager.ActivarSuscripcion(IdSuscripcion);
                }
                else manager.DesactivarSuscripcion(IdSuscripcion);

            }
        }



    }
}