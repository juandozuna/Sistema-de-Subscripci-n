using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.WebReferencePedro;

namespace MVCSuscriptionSystem.HttpClients.WebServicePedro
{
    public class ClientesPedro3
    {
        private ManejadorServicios manager;

        public ClientesPedro3()
        {
            manager = new ManejadorServicios();
            
        }

        public List<SerializedCliente> GetClientes()
        {
            List<SerializedCliente> clientes = null;
            var result = manager.Clientes();
            if (result.success)
            {
                var data = (SerializedCliente[]) result.data;
                clientes = data.ToList();
            }
            return clientes;
        }


        public SerializedCliente GetSingleCliente(int id)
        {
            SerializedCliente cliente = null;
            var result = manager.BuscarIDCliente(id);
            if (result.success)
            {
                var data = (SerializedCliente) result.data;
                cliente = data;
            }
            return cliente;
        }


        public bool BorrarCliente(int id)
        {
            if (GetSingleCliente(id) != null)
            {
                var result = manager.BorrarCliente(id);
                return true;
            }
            return false;

        }



        public bool ModificarCliente(int id, string nombre)
        {
            if (GetSingleCliente(id) != null)
            {
                var result = manager.EditarNombreCliente(id, nombre);
                if (result.success)
                {
                    return true;
                }
            }
            return false;
        }
    }
}