using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSuscriptionSystem.HttpClients.Servicio6Erick
{
    public class Suscripciones6
    {
        public int IDSuscripcion { get; set; }
        public int IDCliente { get; set; }
        public int IDSuscriptor { get; set; }
        public int IDServicio { get; set; }
        public string Activacion { get; set; }
        public Cliente6 Clientes { get; set; }
        public Servicios6 Servicios { get; set; }
        public Suscriptores6 Suscriptores { get; set; }
    }
}