using MVCSuscriptionSystem.WebReferencePedro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;


namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class ClientePedro
    {
        private ManejadorServicios manejador = new ManejadorServicios();

        public List<Cliente> GetCliente() {
            List<Cliente> clientes = null;
            var result = manejador.Clientes();
            if (result.success)
            {
                var serializedClientes = (SerializedCliente[])result.data;
                clientes = serializedClientes.Select(d => new Cliente() { Primer_Nombre = d.nombre}).ToList();

            }

            return clientes;
        }

        public Cliente GetSingleCliente (int id)
        {
            var result = manejador.BuscarIDServicio(id);
            Cliente cliente = null;
            if (result.success)
            {
                var r = (SerializedCliente)result.data;
                cliente = new Cliente() { Primer_Nombre = r.nombre};

            }
            return cliente;
        }

        public Cliente PostCliente(Cliente s)
        {
            var result = manejador.CrearCliente(s.Primer_Nombre);
            if (result.success)
            {
                var data = (int)result.data;
                return s;
            }

            return null;
        }

        public bool BorrarCliente(int id)
        {
            var result = manejador.BorrarCliente(id);
            if (result.success)
            {
                return true;
            }
            return false;
        }

        public bool Modificar(int id, Cliente cliente)
        {
            if (GetSingleCliente(id) != null)
            {
                var m = manejador.EditarNombreCliente(id, cliente.Primer_Nombre);
                return true;
            }
            return false;
        }
    }
}