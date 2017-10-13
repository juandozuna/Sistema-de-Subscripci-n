using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using MVCSuscriptionSystem.HttpClients.Servicio6Erick;
using MVCSuscriptionSystem.Models;
using Newtonsoft.Json;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6
{
    public class SuscriptoresErick6 : AErickConnection
    {
        public List<Suscriptores6> Get()
        {
            var result = Client.GetAsync("api/Suscriptores");
            var json = result.Result.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Suscriptores6[]>(json);
            result.Wait();
            return data.ToList();
        }

        public Suscriptores6 GetSingle(int id)
        {
            var result = Client.GetAsync("api/Suscriptores/" + id);
            var data = result.Result.Content.ReadAsAsync<Suscriptores6>().Result;
            result.Wait();
            return data;
        }

        public Cliente Post(Cliente c, string cedula)
        {
            var sus = new Suscriptores6()
            {
                Nombre = c.Primer_Nombre,
                Email = c.e_mail,
                Apellido = c.Primer_Apellido,
                Cedula = cedula

            };
            var content = new StringContent(JsonConvert.SerializeObject(sus), Encoding.UTF8, "application/json");
            var result = Client.PostAsync("api/Suscriptores", content);
            result.Wait();
            var response = result.Result.Content.ReadAsAsync<Suscriptores6>().Result;
            c.IDErick = response.IDSuscriptor;
            return c;
        }

        public bool Modificar(int id, Suscriptores6 s)
        {
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var result = Client.PutAsync("api/Suscriptores/" + id, content);
            result.Wait();
            var response = result.IsCompleted;
            return response;
        }

        public Suscriptores6 Delete(int id)
        {
            var result = Client.DeleteAsync("api/Suscriptores/" + id);
            var data = result.Result.Content.ReadAsAsync<Suscriptores6>().Result;
            return data;
        }
    }
}