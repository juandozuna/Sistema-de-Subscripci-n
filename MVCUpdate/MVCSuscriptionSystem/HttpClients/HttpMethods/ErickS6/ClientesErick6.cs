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
    public class ClientesErick6 : AErickConnection
    {

        public List<Cliente6> Get()
        {
            var response = Client.GetAsync("api/Clientes");
            var json = response.Result.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject<Cliente6[]>(json);
            
           

            return s.ToList();
        }


        public Cliente6 GetSingle(int id)
        {
            var response = Client.GetAsync("api/Clientes/" + id);
            var json = response.Result.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject<Cliente6>(json);
           
            response.Wait();
            return s;
        }

        public Cliente6 Post(string email, string empresa)
        {
            Cliente6 s = new Cliente6(){Email = email, Empresa = empresa};
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var result = Client.PostAsync("api/Clientes", content);
            var response = result.Result.Content.ReadAsAsync<Cliente6>().Result;
            result.Wait();
            return response;

        }

       

    }
}