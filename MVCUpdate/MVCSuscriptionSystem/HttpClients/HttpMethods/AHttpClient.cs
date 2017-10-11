using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVCSuscriptionSystem.HttpClients.HttpMethods
{
     public abstract class AHttpClient : IDisposable
    {
        protected static HttpClient Client = new HttpClient();


        public void Dispose()
        {
            Client.Dispose();
        }
    }
}