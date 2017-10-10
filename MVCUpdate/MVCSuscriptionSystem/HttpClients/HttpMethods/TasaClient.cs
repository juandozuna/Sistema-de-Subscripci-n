using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods
{
    public class TasaClient : AHttpClient
    {
        public TasaClient()
        {
            Client.BaseAddress = new Uri("http://99.92.201.237/tasa5/");
            //Client.DefaultRequestHeaders.Accept.Clear();
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TasasDeIntercambio> GetTasasDeIntercambio(string userKey)
        {

           
            string json = null;
            var response = Client.GetAsync("api/TasasDeIntercambios?userKey="+ userKey);
            json = response.Result.Content.ReadAsStringAsync().Result;
            var root = JsonConvert.DeserializeObject<TasasDeIntercambio[]>(json);
            
            var tasas = root.ToList();
            return tasas;

        }

    }

   
}