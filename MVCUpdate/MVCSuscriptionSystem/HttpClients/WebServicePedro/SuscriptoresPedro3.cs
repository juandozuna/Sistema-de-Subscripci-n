using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.WebReferencePedro;

namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class SuscriptoresPedro3
    {
        private ManejadorServicios manager;

        public SuscriptoresPedro3()
        {
            manager = new ManejadorServicios();
        }


        public List<Cliente> GetSuscriptores()
        {
            List<Cliente> clientes = null;
            var result = manager.Suscriptores();
            if (result.success)
            {
                var data = (SerializedSuscriptor[]) result.data;
                clientes = data.Select(p => new Cliente()
                {
                    Primer_Nombre = p.nombre,
                    Primer_Apellido = p.apellido,
                    Numero_Telefonico = p.telefono
                }).ToList();
            }

            return clientes;
        }


        public Cliente GetSingleSuscriptor(int id)
        {
            Cliente cliente = null;
            var result = manager.BuscarIDSuscriptor(id);
            if (result.success)
            {
                var data = (SerializedSuscriptor) result.data;
                cliente = new Cliente(){Primer_Nombre = data.nombre, Primer_Apellido = data.apellido, Numero_Telefonico = data.telefono};
            }

            return cliente;
        }


        public bool BorrarSuscriptor(int id)
        {
            if (GetSingleSuscriptor(id) != null)
            {
                var result = manager.BorrarSuscriptor(id);
                if (result.success)
                {
                    return true;
                }
            
            }
            return false;
        }


        public Cliente Modificar(int id, Cliente suscriptor)
        {
            if (GetSingleSuscriptor(id) != null)
            {
                var r = manager.EditarNombreSuscriptor(id, suscriptor.Primer_Nombre);
                var p = manager.EditarApellidoSuscriptor(id, suscriptor.Primer_Apellido);
                var o = manager.EditarTelefonoSuscriptor(id, suscriptor.Numero_Telefonico);
                if (r.success)
                {
                    if (p.success)
                    {
                        if (o.success)
                        {
                            return suscriptor;
                        }
                    }
                }
            }
            return null;
        }

        public Cliente PostSuscriptor(Cliente cliente)
        {
            var result = manager.CrearSuscriptor(cliente.Primer_Nombre, cliente.Primer_Apellido, cliente.Numero_Telefonico);
            if (result.success)
            {
                var re = (int) result.data;
                var p = manager.BuscarIDSuscriptor(re);
                if (p.success)
                {
                    var o = (SerializedSuscriptor) p.data;
                    cliente.IDPedro = o.id;
                    return cliente;
                }
            }
            return null;
        }



    }
}