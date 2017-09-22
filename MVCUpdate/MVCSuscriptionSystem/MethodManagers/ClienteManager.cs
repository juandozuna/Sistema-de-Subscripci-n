using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights.Web;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class ClienteManager
    {

        public static void CrearCliente(FormCollection collection)
        {
            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            var cli = new Cliente()
            {
                Primer_Nombre = collection["Primer_Nombre"],
                Segundo_Nombre = collection["Segundo_Nombre"],
                Primer_Apellido = collection["Primer_Apellido"],
                Fecha_de_nacimiento = DateTime.ParseExact(collection["Fecha_de_nacimiento"],"yyyy-MM-dd", CultureInfo.InvariantCulture),
                Fecha_de_expiracion = DateTime.ParseExact(collection["Fecha_de_expiracion"], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Numero_Telefonico = collection["Numero_Telefonico"],
                NumeroTarjeta = Int32.Parse(collection["NumeroTarjeta"]),
                e_mail = collection["e_mail"],
                Metodo_de_Pago = collection["Metodo_de_Pago"],
                CVC_o_CVV = Int32.Parse(collection["CVC_o_CVV"]),
                
            };

            if (cli != null)
            {
                db.Clientes.Add(cli);
                db.SaveChanges();
                cli = db.Clientes.OrderByDescending(w => w.ClientID).First();
                SubscripcionManager.CrearSubscripcionNueva(cli);

            }
        }

        public static void CrearCliente(Cliente cli)
        {
            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            if (cli != null)
            {
                db.Clientes.Add(cli);
                db.SaveChanges();
                cli = db.Clientes.OrderByDescending(w => w.ClientID).First();
                SubscripcionManager.CrearSubscripcionNueva(cli);
               
            }
        }

        public static Cliente UltimoCliente()
        {
            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            return db.Clientes.OrderByDescending(x => x.ClientID).First();
        }

       
    }
}