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

            Assert.AreEqual("NYStyleCheesePizza", nyCheesePizza.Name);
            Assert.AreEqual("NYStyleClamPizza", nyClamPizza.Name);


            ChicagoPizzaStore chiagoPizzaStore = new ChicagoPizzaStore();
            Pizza chicagoCheesePizza = chiagoPizzaStore.CreatePizza("cheese");
            Pizza chicagoClamPizza = chiagoPizzaStore.CreatePizza("clam");

            Assert.AreEqual("ChicagoStyleCheesePizza", chicagoCheesePizza.Name);
            Assert.AreEqual("ChicagoStyleClamPizza", chicagoClamPizza.Name);

        }

        [TestMethod]
        [TestCategory("Factory")]
        public void PizzaTestDriver()
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            var pizza = nyStore.OrderPizza("cheese");
            string nyPizzaExpectedStatus =
@"Prepare NYStyleCheesePizza
Tossing dough...
Adding sauce...
Adding toppings: 
	Grated Reggiano Cheese
Bake for 25 minutes at 350
Cut pizza into diagonal slices
Place pizza in official PizzaStore box
";
            Assert.AreEqual(nyPizzaExpectedStatus, pizza.Status);

            pizza = chicagoStore.OrderPizza("cheese");
            string chicagoPizzaOrderStatus =
@"Prepare ChicagoStyleCheesePizza
Tossing dough...
Adding sauce...
Adding toppings: 
	Shredded Mozzarella Cheese
Bake for 25 minutes at 350
Cutting the pizza into square slices
Place pizza in official PizzaStore box
";
            Assert.AreEqual(chicagoPizzaOrderStatus, pizza.Status);
        }
    }
}
