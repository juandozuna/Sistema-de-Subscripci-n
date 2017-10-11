using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods
{
    public class RNCClient : AHttpClient
    {
        public RNCClient()
        {
            Client.BaseAddress = new Uri("http://99.92.201.237/cedula1/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public RNC1 GetRnc1(int RNCoCedula)
        {

            var result = Client.GetAsync("api/RNC/" + RNCoCedula);
            var response = result.Result.Content.ReadAsAsync<RNC1>().Result;
            return response;
;
        }

    }
}