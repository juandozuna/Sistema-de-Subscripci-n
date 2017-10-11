using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            Client.DefaultRequestHeaders.Accept.Clear();
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TasasDeIntercambio> GetTasasDeIntercambio(string userKey)
        {

           
            string json = null;
            var response = Client.GetAsync("api/TasasDeIntercambios?userKey="+ userKey);
            json = response.Result.Content.ReadAsStringAsync().Result;
            var root = JsonConvert.DeserializeObject<TasasDeIntercambio[]>(json);
            
            var tasas = root.ToList();
            response.Wait();
            return tasas;

        }

        public TasasDeIntercambio GetTasadDeIntercambioFecha(string userKey, DateTime date)
        {
            var response = Client.GetAsync("api/TasasDeIntercambios?userKey="+userKey+"&date="+date.ToString("yyyy-MM-dd",DateTimeFormatInfo.InvariantInfo));
            string json = response.Result.Content.ReadAsStringAsync().Result;
            var tasa = JsonConvert.DeserializeObject<TasasDeIntercambio>(json);

            response.Wait();
            return tasa;
        }

        public TasasDeIntercambio PostTasaDeIntercambio(string userKey, TasasDeIntercambio tasa)
        {

            tasa.ClientKey = userKey;
            var content = new StringContent(JsonConvert.SerializeObject(tasa), Encoding.UTF8, "application/json");
            var url = "api/TasaDeIntercambios?userKey=" + userKey;
            var result = Client.PostAsync(url, content);
            var tas = result.Result.Content.ReadAsAsync<TasasDeIntercambio>().Result;


            return tas;

        }

    }

   
}