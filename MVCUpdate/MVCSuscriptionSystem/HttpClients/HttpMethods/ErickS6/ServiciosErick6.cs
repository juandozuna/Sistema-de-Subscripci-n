using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using MVCSuscriptionSystem.HttpClients.Servicio6Erick;
using MVCSuscriptionSystem.Models;
using Newtonsoft.Json;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6
{
    public class ServiciosErick6 : AErickConnection
    {
        public List<Servicio> Get()
        {
            var response = Client.GetAsync("api/Servicios");
            var json = response.Result.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject<Servicios6[]>(json);
            var serv = s.Select(p => new Servicio()
            {
                Nombre = p.Nombre,
                Precio = p.Precio,
            });
            //using (MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities())
            //{
            //    var servicios = db.Servicios.Where(p => !serv.Any(t => t.Nombre == p.Nombre));
            //    db.Servicios.AddRange(servicios);
            //    db.SaveChanges();
            //}

            return serv.ToList();
        }


        public Servicio GetSingle(int id)
        {
            var response = Client.GetAsync("api/Servicios/" + id);
            var json = response.Result.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject<Servicios6>(json);
            var servicio = new Servicio()
            {
                Nombre = s.Nombre,
                Precio = s.Precio
            };
            response.Wait();
            return servicio;
        }

        public Servicio Post(Servicio servicio)
        {
            Servicios6 s = new Servicios6() {Nombre = servicio.Nombre, Precio = servicio.Precio};
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var result = Client.PostAsync("api/Servicios", content);
            var response = result.Result.Content.ReadAsAsync<Servicios6>().Result;
            var serv = new Servicio() {Nombre = response.Nombre, Precio = response.Precio};
            result.Wait();
            return serv;

        }

        public Servicio Delete(int id)
        {
            var result = Client.DeleteAsync("api/Servicios/" + id);
            var response = result.Result.Content.ReadAsAsync<Servicios6>().Result;
            result.Wait();
            Servicio d = new Servicio(){Nombre = response.Nombre, Precio = response.Precio};
            return d;
        }


        public string Modificar(int id, Servicio servicio)
        {
            var s = new Servicios6() {Nombre = servicio.Nombre, Precio = servicio.Precio};
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            string url = "api/Servicios/" + id;
            var result = Client.PutAsync(url, content);
            var response = result.Result.Content.ReadAsStringAsync().Result;
            return response;

        }
    }
}