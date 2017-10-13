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
            var ErickList = Erick6S.Get(); 
            var PedroList = Pedro3S.GetServicios();

            var sdb = db.Servicios.ToList();
            var listwhole = ErickList.Union(PedroList);

            List<Servicio> nuevo = new List<Servicio>();
            List<Servicio> modificado = new List<Servicio>();
            List<Servicio> Borrado = new List<Servicio>();
            foreach (var i in listwhole)
            {
                if (sdb.Any(d => d.IDErick == i.IDErick))
                {
                    modificado.Add(i);
                }
                else if(i.IDPedro == 0)
                {
                    nuevo.Add(i);
                }
                else if (sdb.Any(p => p.IDPedro == i.IDPedro))
                {
                    modificado.Add(i);
                }
                else if (i.IDErick == 0)
                {
                    nuevo.Add(i);
                }
            }

            var IDdbErick = sdb.Select(d => d.IDErick);
            var IDdbPedro = sdb.Select(d => d.IDPedro);
            var IDLErick = listwhole.Select(d => d.IDErick);
            var IDLPedro = listwhole.Select(d => d.IDPedro);
            var IDborradoPedro = IDdbPedro.Except(IDLPedro);
            var IDborradoErick = IDdbErick.Except(IDLErick);
            var borradoErick = sdb.Where(d => IDborradoErick.Any(p => p == d.IDErick));
            var borradoPedro = sdb.Where(d => IDborradoPedro.Any(p => p == d.IDPedro));
            Borrado = borradoPedro.Union(borradoErick).ToList();



            ServiciosManager.AgregarListadoDeServicios(nuevo);
            ServiciosManager.ModificarListadoDeServicios(modificado);
            ServiciosManager.BorrarListadoDeServicios(Borrado);


            return sdb;
        }


        public bool BorrarServicio(Servicio s)
        {
            if (s.IDErick != 0 && s.IDPedro == 0)
            {
                Erick6S.Delete(s.IDErick);
                return true;
            }else if(s.IDPedro != 0 && s.IDErick == 0)
            {
                Pedro3S.BorrarServicio(s);
                return true;
            }
            return false;
        }

        public void ModificarServicio(Servicio s)
        {
            if (s.IDErick != 0 && s.IDPedro == 0)
            {
                Erick6S.Modificar(s.IDErick,s);
            }else if (s.IDPedro != 0 && s.IDErick == 0)
            {
                Pedro3S.Modificar(s.IDPedro, s);
            }
        }


        public void CrearServicioPedro(Servicio servicio)
        {
            TasaClient t = new TasaClient();
            var tasa = t.GetTasasDeIntercambio("7").First();
            servicio.Precio = (servicio.Precio/tasa.ValorIntercambio);
            Pedro3S.PostServicio(servicio);
        }

        public void CrearServicioErick(Servicio servicio)
        {
            Erick6S.Post(servicio);
        }



    }



}