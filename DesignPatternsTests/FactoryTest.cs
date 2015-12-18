using System;
using DesignPatterns.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        [TestCategory("Factory")]
        public void PizzaStore()
        {
            NYPizzaStore nyPizzaStory = new NYPizzaStore();
            Pizza nyCheesePizza = nyPizzaStory.CreatePizza("cheese");
            Pizza nyClamPizza = nyPizzaStory.CreatePizza("clam");

            Assert.AreEqual("NYStyleCheesePizza", nyCheesePizza.type);
            Assert.AreEqual("NYStyleClamPizza", nyClamPizza.type);


            ChicagoPizzaStore chiagoPizzaStore = new ChicagoPizzaStore();
            Pizza chicagoCheesePizza = chiagoPizzaStore.CreatePizza("cheese");
            Pizza chicagoClamPizza = chiagoPizzaStore.CreatePizza("clam");

            Assert.AreEqual("ChicagoStyleCheesePizza", chicagoCheesePizza.type);
            Assert.AreEqual("ChicagoStyleClamPizza", chicagoClamPizza.type);

        }
    }
}
