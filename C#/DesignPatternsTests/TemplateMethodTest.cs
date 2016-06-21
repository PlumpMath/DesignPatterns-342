using System;
using DesignPatterns.TemplateMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsTests
{
    [TestClass]
    public class TemplateMethodTest
    {
        [TestMethod]
        [TestCategory("TemplateMethod")]
        public void MethodAbstraction()
        {
            CaffeineBeverage tea = new Tea();
            CaffeineBeverage coffee = new Coffee();
            CaffeineBeverage coffeeWithHook_WantsCondiments = new CoffeeWithHook();
            CaffeineBeverage coffeeWithHook_DoesntWantCondiments = new CoffeeWithHook();
            (coffeeWithHook_WantsCondiments as CoffeeWithHook).CustomerRequestedCondiments = true;
            (coffeeWithHook_DoesntWantCondiments as CoffeeWithHook).CustomerRequestedCondiments = false;

            tea.PrepareRecipe();
            coffee.PrepareRecipe();
            coffeeWithHook_WantsCondiments.PrepareRecipe();
            coffeeWithHook_DoesntWantCondiments.PrepareRecipe();

            Assert.AreNotEqual(tea.Status, coffee.Status);
            Assert.AreEqual(coffeeWithHook_WantsCondiments.Status, coffee.Status);
            Assert.AreNotEqual(coffeeWithHook_DoesntWantCondiments.Status, coffeeWithHook_WantsCondiments.Status);
        }
    }
}
