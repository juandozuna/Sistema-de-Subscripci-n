using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace MVCSuscriptionSystem.HttpClients
{
    public class TasasDeIntercambio
    {
        [Key]
        public int TasaID { get; set; }

        public string ClientKey { get; set; }

        public double ValorIntercambio { get; set; }

        public DateTime Fecha { get; set; }

    }
}