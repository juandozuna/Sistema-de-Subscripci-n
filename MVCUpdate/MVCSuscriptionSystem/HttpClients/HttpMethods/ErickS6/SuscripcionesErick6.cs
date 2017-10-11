using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using MVCSuscriptionSystem.HttpClients.Servicio6Erick;
using Newtonsoft.Json;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6
{
    public class SuscripcionesErick6 : AErickConnection
    {
        public List<Suscripciones6> Get()
        {
            var response = Client.GetAsync("api/Suscripciones");
            var json = response.Result.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject<Suscripciones6[]>(json);
            response.Wait();
            return s.ToList();
        }


        public Suscripciones6 GetSingle(int id)
        {
            var response = Client.GetAsync("api/Suscripciones/" + id);
            var json = response.Result.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject<Suscripciones6>(json);

            response.Wait();
            return s;
        }

        public Suscripciones6 Post(int iDCliente, int iDSuscriptor, int iDServicio, string activacion)
        {
            Suscripciones6 s = new Suscripciones6() { IDCliente = iDCliente,IDServicio = iDServicio, IDSuscriptor = iDSuscriptor, Activacion = activacion};
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var result = Client.PostAsync("api/Suscripciones", content);
            var response = result.Result.Content.ReadAsAsync<Suscripciones6>().Result;
            result.Wait();
            return response;

        }

        public bool PostEstadoSuscripcion(int id, bool state)
        {
            string accion = "Desactivar";
            if (state) accion = "Activar";
                var result = Client.PostAsync("api/Suscripciones/" + id + "?Accion=" + accion,new StringContent(""));
                var response = result.IsCompleted;
            result.Wait();
                return response;
        }

        public Suscripciones6 Delete(int id)
        {
            var result = Client.DeleteAsync("api/Suscripciones/" + id);
            var response = result.Result.Content.ReadAsAsync<Suscripciones6>().Result;
            result.Wait();
            return response;
        }

        public bool Modificar(int id, Suscripciones6 s)
        {
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var result = Client.PutAsync("api/Suscripciones", content);
            var response = result.IsCompleted;
            result.Wait();
            return response;

        }

    }
}