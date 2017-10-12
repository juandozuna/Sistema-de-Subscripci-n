using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using MVCSuscriptionSystem.HttpClients.HttpMethods;
using MVCSuscriptionSystem.HttpClients.WebServicePedro;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystemTests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext testContext { get; set; }

        [TestMethod]
        public void GetServiciosPedroTest()
        {
            ServiciosPedro3 cliente = new ServiciosPedro3();
            var servicios = cliente.GetServicios();
            foreach (var item in servicios)
            {
                testContext.WriteLine(item.Nombre);
                testContext.WriteLine(item.Precio.ToString());
                testContext.WriteLine("#####");
            }
            Assert.IsTrue(servicios.Count > 0);
        }

        //[TestMethod]
        //public void GetServicioPedroEspecifico()
        //{

        //}


    }
}
