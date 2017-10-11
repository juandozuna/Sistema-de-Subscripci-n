using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace MVCSuscriptionSystem.HttpClients
{
    public class TasasDeIntercambio
    {

       
        public int TasaID { get; set; }
        public string ClientKey { get; set; }
        public double ValorIntercambio { get; set; }
        public DateTime Fecha { get; set; }

    }
}