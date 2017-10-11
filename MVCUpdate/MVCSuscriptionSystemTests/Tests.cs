using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using MVCSuscriptionSystem.HttpClients;
using MVCSuscriptionSystem.HttpClients.HttpMethods;
using MVCSuscriptionSystem.HttpClients.HttpMethods.ErickS6;
using MVCSuscriptionSystem.HttpClients.Servicio6Erick;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem;
using MVCSuscriptionSystem.ServiceReference;
using MVCSuscriptionSystem.WebServices;
using Newtonsoft.Json;
using SerializedServicio = MVCSuscriptionSystem.ServicioPedro.SerializedServicio;

namespace MVCSuscriptionSystemTests
{
    [TestClass]
    public class Tests
    {
       
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void GetTasas()
        {
            TasaClient tasa = new TasaClient();
            var ts = tasa.GetTasasDeIntercambio("7");


            foreach (var t in ts)
            {
                TestContext.WriteLine(t.ClientKey);
                TestContext.WriteLine(t.ValorIntercambio.ToString());
                TestContext.WriteLine(t.Fecha.ToString());
                TestContext.WriteLine("-----------");
            }
            bool greater = ts.Count > 0;
            Assert.IsNotNull(ts);
            Assert.AreEqual(ts[0].ClientKey, "7");
            Assert.IsTrue(greater);

        }

        [TestMethod]
        public void GetTasaDate()
        {
            TasaClient tasa = new TasaClient();
            DateTime date = new DateTime(2017, 10, 9);
            var ts = tasa.GetTasadDeIntercambioFecha("7", date);
            TestContext.WriteLine(ts.ToString());

            Assert.IsNotNull(ts);
            Assert.AreEqual(ts.ValorIntercambio, 48);
        }


        [TestMethod]
        public void PostTasa()
        {
            TasaClient tasa = new TasaClient();
            var TasaDeIntercambio = new TasasDeIntercambio();
            TasaDeIntercambio.ClientKey = "dddd";
            TasaDeIntercambio.ValorIntercambio = 45.34;
            TasaDeIntercambio.Fecha = DateTime.Today;
            TestContext.WriteLine(JsonConvert.SerializeObject(TasaDeIntercambio));

            var ts = tasa.PostTasaDeIntercambio("dddd", TasaDeIntercambio);
            TestContext.WriteLine("Client: {0}, Valor: {1}, Fecha: {2}, ID: {3}",ts.ClientKey,ts.ValorIntercambio, ts.Fecha, ts.TasaID);

            Assert.IsNotNull(ts);
            Assert.AreEqual(TasaDeIntercambio.ClientKey,ts.ClientKey);

        }

        [TestMethod]
        public void GetServiciosErickTest()
        {
            ServiciosErick6 client = new ServiciosErick6();
            var servicios = client.Get();
            foreach (var item in servicios)
            {
                TestContext.WriteLine(item.IDServicio.ToString());
                TestContext.WriteLine(item.Nombre);
                TestContext.WriteLine(item.Precio.ToString());
                TestContext.WriteLine("#####");
            }
            Assert.IsTrue(servicios.Count>0);
        }


        [TestMethod]
        public void GetServicioErickSpecifico()
        {
            ServiciosErick6 client = new ServiciosErick6();
            var item = client.GetSingle(1);
            TestContext.WriteLine(item.Nombre);
            TestContext.WriteLine(item.Precio.ToString());
            TestContext.WriteLine("#####");
            Assert.AreEqual("ServicioCR", item.Nombre);
        }

        [TestMethod]
        public void PostServicioErick()
        {
            Servicio s = new Servicio(){Nombre = "UnitTesting2JD2",Precio = 23};
            ServiciosErick6 client = new ServiciosErick6();
            var p = client.Post(s);
            TestContext.WriteLine(p.Nombre);
            TestContext.WriteLine(p.Precio.ToString());
            TestContext.WriteLine("#####");

            Assert.IsNotNull(p);
            Assert.AreEqual(s.Nombre, p.Nombre);

        }

        [TestMethod]
        public void DeleteServicioErick()
        {
            ServiciosErick6 client = new ServiciosErick6();
            var p = client.Delete(6);
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void ModificarServicioErick()
        {
            ServiciosErick6 client = new ServiciosErick6();
            Servicio ts = new Servicio(){Nombre = "ModificadoJD", Precio = 345};
            var s = client.Modificar(4, ts);
            Assert.IsFalse(s.Contains("404"));
        }

        //Clientes del Servicio 3 de Erick
        [TestMethod]
        public void GetClientesErickTest()
        {
            ClientesErick6 client = new ClientesErick6();
            var response = client.Get();
            foreach (var cliente6 in response)
            {
                TestContext.WriteLine("Cliente: "+ cliente6.IDCliente.ToString());
            }
            Assert.IsTrue(response.Count>0);
        }

        [TestMethod]
        public void GetSingleClienteErickTest()
        {
            ClientesErick6 client = new ClientesErick6();
            var r = client.GetSingle(2);
            Assert.IsNotNull(r);
            Assert.AreEqual(2,r.IDCliente);
        }

        [TestMethod]
        public void PostClienteErickTest()
        {
            ClientesErick6 client = new ClientesErick6();
            var r = client.Post("pruebas@unitarias.com", "grupo2");
            Assert.IsNotNull(r);
            Assert.AreEqual("grupo2",r.Empresa);
        }

        [TestMethod]
        public void GetRNCTest()
        {
            RNCClient c = new RNCClient();
            var s = c.GetRnc1(101807695);
            string se = "101807695";
            Assert.AreEqual(se, s.RNC);

        }

        [TestMethod]
        public void PedroServiceTest()
        {
            var o = PedroWebServiceMethods.GetServiciosPedro();
            foreach (var servicio in o)
            {
                TestContext.WriteLine(servicio.Nombre);
                TestContext.WriteLine("_______________");
            }



        }


    }
}
