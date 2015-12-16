using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void DecoratorPattern()
        {
            DecoratorPattern.Beverage testBeverage = new DecoratorPattern.Decaf();
            testBeverage = new DecoratorPattern.Whip(testBeverage);
            testBeverage = new DecoratorPattern.SteamedMilk(testBeverage);
            testBeverage = new DecoratorPattern.Soy(testBeverage);

            Assert.AreEqual("Decaf, Whip, Steamed Milk, Soy", testBeverage.GetDescription());
            Assert.AreEqual((double)(1.05 + .10 + .10 + .15), testBeverage.Cost());
        }
    }
}
