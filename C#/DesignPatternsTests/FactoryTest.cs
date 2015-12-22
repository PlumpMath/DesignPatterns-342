using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        [TestCategory("Factory")]
        public void BasicPizzaStore()
        {
            Factory.Base.NYPizzaStore nyPizzaStory = new Factory.Base.NYPizzaStore();
            Factory.Base.Pizza nyCheesePizza = nyPizzaStory.CreatePizza("cheese");
            Factory.Base.Pizza nyClamPizza = nyPizzaStory.CreatePizza("clam");

            Assert.AreEqual("NYStyleCheesePizza", nyCheesePizza.Name);
            Assert.AreEqual("NYStyleClamPizza", nyClamPizza.Name);


            Factory.Base.ChicagoPizzaStore chiagoPizzaStore = new Factory.Base.ChicagoPizzaStore();
            Factory.Base.Pizza chicagoCheesePizza = chiagoPizzaStore.CreatePizza("cheese");
            Factory.Base.Pizza chicagoClamPizza = chiagoPizzaStore.CreatePizza("clam");

            Assert.AreEqual("ChicagoStyleCheesePizza", chicagoCheesePizza.Name);
            Assert.AreEqual("ChicagoStyleClamPizza", chicagoClamPizza.Name);

        }

        [TestMethod]
        [TestCategory("Factory")]
        public void BasicPizzaTestDriver()
        {
            Factory.Base.PizzaStore nyStore = new Factory.Base.NYPizzaStore();
            Factory.Base.PizzaStore chicagoStore = new Factory.Base.ChicagoPizzaStore();

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

        [TestMethod]
        [TestCategory("Factory")]
        public void AbstractPizzaStore()
        {
            Factory.Abstract.NYPizzaStore nyPizzaStory = new Factory.Abstract.NYPizzaStore();
            Factory.Abstract.Pizza nyCheesePizza = nyPizzaStory.CreatePizza("cheese");
            Factory.Abstract.Pizza nyClamPizza = nyPizzaStory.CreatePizza("clam");

            Assert.AreEqual("New York Style Cheese Pizza", nyCheesePizza.Name);
            Assert.AreEqual("New York Style Clam Pizza", nyClamPizza.Name);


            Factory.Abstract.ChicagoPizzaStore chiagoPizzaStore = new Factory.Abstract.ChicagoPizzaStore();
            Factory.Abstract.Pizza chicagoCheesePizza = chiagoPizzaStore.CreatePizza("cheese");
            Factory.Abstract.Pizza chicagoClamPizza = chiagoPizzaStore.CreatePizza("clam");

            Assert.AreEqual("Chicago Style Cheese Pizza", chicagoCheesePizza.Name);
            Assert.AreEqual("Chicago Style Clam Pizza", chicagoClamPizza.Name);
        }
    }
}
