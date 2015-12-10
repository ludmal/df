using System;
using System.Linq;
using DF.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DF.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new DealContext())
            {
                var deals = db.ActiveDeals.ToList();

                Assert.IsTrue(deals.Any());
            }
        }
    }
}
