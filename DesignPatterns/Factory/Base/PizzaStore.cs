using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Base
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza;

            pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        public abstract Pizza CreatePizza(string type);
    }

    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new NYStyleCheesePizza();
            }
            else if (type == "veggie")
            {
                return new NYStyleVeggiePizza();
            }
            else if (type == "clam")
            {
                return new NYStyleClamPizza();
            }
            else if (type == "pepperoni")
            {
                return new NYStylePepperoniPizza();
            }
            else
            {
                return null;
            }
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new ChicagoStyleCheesePizza();
            }
            else if (type == "veggie")
            {
                return new ChicagoStyleVeggiePizza();
            }
            else if (type == "clam")
            {
                return new ChicagoStyleClamPizza();
            }
            else if (type == "pepperoni")
            {
                return new ChicagoStylePepperoniPizza();
            }
            else
            {
                return null;
            }
        }
    }

    public class CaliforniaPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new CaliforniaStyleCheesePizza();
            }
            else if (type == "veggie")
            {
                return new CaliforniaStyleVeggiePizza();
            }
            else if (type == "clam")
            {
                return new CaliforniaStyleClamPizza();
            }
            else if (type == "pepperoni")
            {
                return new CaliforniaStylePepperoniPizza();
            }
            else
            {
                return null;
            }
        }
    }
}
