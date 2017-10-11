using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using MVCSuscriptionSystem.HttpClients.Servicio6Erick;
using MVCSuscriptionSystem.Models;
using Newtonsoft.Json;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6
{
    public abstract class AErickConnection : AHttpClient
    {
        protected AErickConnection()
        {
            Client.BaseAddress = new Uri("http://99.92.201.237/servicio6/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        

        



    }
}