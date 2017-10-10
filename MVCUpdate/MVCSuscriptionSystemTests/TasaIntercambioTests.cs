using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using MVCSuscriptionSystem.HttpClients;
using MVCSuscriptionSystem.HttpClients.HttpMethods;

namespace MVCSuscriptionSystemTests
{
    [TestClass]
    public class TasaIntercambioTests
    {
        private TasaClient tasa = new TasaClient();
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void GetTasas()
        {
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
            DateTime date = new DateTime(2017, 10, 9);
            var ts = tasa.GetTasadDeIntercambioFecha("7", date);
            TestContext.WriteLine(ts.ToString());

            Assert.IsNotNull(ts);
            Assert.AreEqual(ts.ValorIntercambio, 48);
        }


        [TestMethod]
        public void PostTasa()
        {
            var TasaDeIntercambio = new TasasDeIntercambio();
            TasaDeIntercambio.ClientKey = "7";
            TasaDeIntercambio.ValorIntercambio = 45.34M;

            var ts = tasa.PostTasaDeIntercambio(TasaDeIntercambio.ClientKey, TasaDeIntercambio);
            TestContext.WriteLine("Client: {0}, Valor: {1}, Fecha: {2}, ID: {3}",ts.ClientKey,ts.ValorIntercambio, ts.Fecha, ts.TasaID);

            Assert.IsNotNull(ts);
            Assert.AreEqual("7",ts.ClientKey);

        }

    }
}
