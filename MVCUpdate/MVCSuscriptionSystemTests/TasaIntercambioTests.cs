using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
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
                TestContext.WriteLine("-----------");
            }
            bool greater = ts.Count > 0;
            Assert.IsNotNull(ts);
            Assert.AreEqual(ts[0].ClientKey, "7");
            Assert.IsTrue(greater);


        }

        //[TestMethod]
        //public void GetTasas()
        //{
        //    var ts = tasa.GetTasasDeIntercambio("7");
        //    bool contains = ts.Contains("ValorIntercambio");
        //    TestContext.WriteLine(ts);
        //    Assert.IsTrue(contains);
        //}
    }
}
