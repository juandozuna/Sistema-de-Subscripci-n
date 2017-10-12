using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6;
using MVCSuscriptionSystem.HttpClients.WebServicePedro;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ServiciosJoined
{
    public class ServiciosFromServices
    {
        private ServiciosErick6 Erick6S;
        private ServiciosPedro3 Pedro3S;

        public ServiciosFromServices()
        {
            Erick6S = new ServiciosErick6();
            Pedro3S = new ServiciosPedro3();
        }

        public List<Servicio> GetServicios()
        {
            var lista1 = Erick6S.Get();
            var lista2 = Pedro3S.GetServicios();
            var servicios = lista1.Union(lista2).ToList();
            using (MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities())
            {
                var sdb = db.Servicios.ToList();
                var nuevos = servicios.Where(p => !sdb.Any(o =>(o.IDErick == p.IDErick || o.IDPedro == p.IDPedro))).ToList();
                var modificados = servicios.Where(p => sdb.All(r=> (r.IDErick ==p.IDErick||r.IDPedro == p.IDPedro) )).ToList();
                var borrados = sdb.Where(p=>!servicios.Any(t=> (t.IDPedro == p.IDPedro ||t.IDErick == p.IDErick) )).ToList();

                
            }

            return servicios;
        }
    }



}