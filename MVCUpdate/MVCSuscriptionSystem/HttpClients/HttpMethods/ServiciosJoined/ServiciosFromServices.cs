using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
            return servicios;
        }

        /// <summary>
        /// recibe 1 para guardar el servicio en el de pedro
        /// recibe 2 para guardar en el servicio de Erick
        /// </summary>
        /// <param name="PoE">Enque servicio guarda</param>
        /// <returns></returns>
        public Servicio PostServicio(int PoE, Servicio servicio)
        {
            Servicio s = null;
            if (PoE == 1)
            {
               s= Pedro3S.PostServicio(servicio);
            }else if (PoE == 2)
            {
                s = Erick6S.Post(servicio);
            }
            return s;
        }

        public bool ModificarServicio(int PoE, int IdS, Servicio servicio)
        {
            if (PoE == 1)
            {
                if (Pedro3S.Modificar(IdS, servicio))
                {
                    return true;
                }
            }else if (PoE == 2)
            {
                if (Erick6S.Modificar(IdS, servicio))
                {
                    return true;
                }
            }
            return false;
        }


        public bool BorrarServicio(int PoE, int IdS)
        {
            
            if (PoE == 1)
            {
                var p = Pedro3S.BorrarServicio(IdS);
                if (p)
                {
                    return true;
                }
            }else if (PoE == 2)
            {
                var p = Erick6S.Delete(IdS);
                if (p != null) return true;
            }
            return false;
        }
    }
}