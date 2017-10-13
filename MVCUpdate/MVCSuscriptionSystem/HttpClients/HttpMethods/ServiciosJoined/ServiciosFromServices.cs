using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6;
using MVCSuscriptionSystem.HttpClients.WebServicePedro;
using MVCSuscriptionSystem.MethodManagers;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ServiciosJoined
{
    public class ServiciosFromServices
    {
        private ServiciosErick6 Erick6S;
        private ServiciosPedro3 Pedro3S;

        private MVCSuscriptionDatabseEntities db;

        public ServiciosFromServices()
        {
            Erick6S = new ServiciosErick6();
            Pedro3S = new ServiciosPedro3();
            db = new MVCSuscriptionDatabseEntities();
        }

        public List<Servicio> GetServicios()
        {
            var lista1 = Erick6S.Get(); 
             var lista2 = Pedro3S.GetServicios();
            var servicios = lista1.Union(lista2).ToList();
            
                var sdb = db.Servicios.ToList();
                var nuevos = servicios.Where(p => !sdb.Any(o => (o.IDErick == p.IDErick || o.IDPedro == p.IDPedro)));
                var modificados = servicios.Where(p => sdb.All(r=> (r.IDErick ==p.IDErick||r.IDPedro == p.IDPedro) ));
                //var borrados = sdb.Where(p => !servicios.Any(t => (t.IDPedro == p.IDPedro || t.IDErick == p.IDErick)));
                
                ServiciosManager.AgregarListadoDeServicios(nuevos);
                ServiciosManager.ModificarListadoDeServicios(modificados);
            

            return servicios;
        }


        public bool BorrarServicio(int id)
        {
            var servicio = db.Servicios.Find(id);
            if (servicio != null)
            {
                var idErick = servicio.IDErick.ToString();
                var idPedro = servicio.IDPedro.ToString();
                if (Erick6S.GetSingle(Int32.Parse(idErick)) != null)
                {
                    Erick6S.Delete(Int32.Parse(idErick));
                    return true;

                }else if(Pedro3S.GetSingleServicio(Int32.Parse(idPedro)) != null)
                {
                    Pedro3S.BorrarServicio(Int32.Parse(idPedro));
                    return true;
                }
                return false;
            }


        }
    }



}