using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6;
using MVCSuscriptionSystem.HttpClients.WebServicePedro;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ServiciosJoined
{
    public class SuscriptoresFromServices
    {
        private SuscripcionesErick6 suscripcionesErick6;
        private SuscriptoresErick6 suscriptoresErick6;
        private SuscripcionesPedro3 suscripcionesPedro3;
        private SuscriptoresPedro3 suscriptoresPedro3;
        private MVCSuscriptionDatabseEntities db;


        public SuscriptoresFromServices()
        {
            suscripcionesPedro3 = new SuscripcionesPedro3();
            suscriptoresPedro3 = new SuscriptoresPedro3();
            suscriptoresErick6 = new SuscriptoresErick6();
            suscripcionesErick6 = new SuscripcionesErick6();
            db = new MVCSuscriptionDatabseEntities();
        }

        public Cliente CrearSuscriptor(Cliente cliente)
        {
            var e = suscriptoresErick6.Post(cliente, "0000");
            var p = suscriptoresPedro3.PostSuscriptor(cliente);
            cliente.IDErick = e.IDErick;
            cliente.IDPedro = p.IDPedro;
            return cliente;
        }




    }
}