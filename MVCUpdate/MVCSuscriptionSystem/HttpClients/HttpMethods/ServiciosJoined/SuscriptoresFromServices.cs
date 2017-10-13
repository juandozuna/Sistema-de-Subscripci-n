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
        private ServiciosFromServices services;
        private MVCSuscriptionDatabseEntities db;


        public SuscriptoresFromServices()
        {
            suscripcionesPedro3 = new SuscripcionesPedro3();
            suscriptoresPedro3 = new SuscriptoresPedro3();
            suscriptoresErick6 = new SuscriptoresErick6();
            suscripcionesErick6 = new SuscripcionesErick6();
            services = new ServiciosFromServices();
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

        public bool ActivarSuscripcionesExternasDeCliente(Subscripcion suscripcione)
        {
            
            var servPedro = suscripcione.Plan.ServicioEnPlans.Where(d=>d.Servicio.IDPedro != 0 && d.Servicio.IDErick == 0);
            var servErick = suscripcione.Plan.ServicioEnPlans.Where(d=>d.Servicio.IDErick != 0 && d.Servicio.IDPedro  == 0);
            foreach (var i in servPedro)
            {
                suscripcionesPedro3.CrearSuscripcionNueva(suscripcione.ClienteSuscripcions.First().Cliente.IDPedro,i.Servicio.IDPedro, 1);
            }
            foreach (var i in servErick)
            {
                suscripcionesErick6.Post(suscripcione.ClienteSuscripcions.First().Cliente.IDErick,i.Servicio.IDErick, true);
            }
            return false;

        }

        



    }
}