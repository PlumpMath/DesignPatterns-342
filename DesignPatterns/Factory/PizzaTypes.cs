using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public abstract class Pizza
    {
        internal string type;

        public Pizza()
        { }

        public void Prepare()
        { }

        public void Bake()
        { }

        public void Cut()
        { }

        public void Box()
        { }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            this.type = "NYStyleCheesePizza";
        }
    }

    public class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            this.type = "NYStyleClamPizza";
        }
    }

    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            this.type = "NYStylePepperoniPizza";
        }
    }

    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            this.type = "NYStyleVeggiePizza";
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            this.type = "ChicagoStyleCheesePizza";
        }
    }

    public class ChicagoStyleClamPizza : Pizza
    {
        public ChicagoStyleClamPizza()
        {
            this.type = "ChicagoStyleClamPizza";
        }
    }

    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            this.type = "ChicagoStylePepperoniPizza";
        }
    }

    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            this.type = "ChicagoStyleVeggiePizza";
        }
    }

    public class CaliforniaStyleCheesePizza : Pizza
    {
        public CaliforniaStyleCheesePizza()
        {
            this.type = "CaliforniaStyleCheesePizza";
        }
    }

    public class CaliforniaStyleClamPizza : Pizza
    {
        public CaliforniaStyleClamPizza()
        {
            this.type = "CalforniaStyleClamPizza";
        }
    }

    public class CaliforniaStylePepperoniPizza : Pizza
    {
        public CaliforniaStylePepperoniPizza()
        {
            this.type = "CalforniaStylePepperoniPizza";
        }
    }

    public class CaliforniaStyleVeggiePizza : Pizza
    {
        public CaliforniaStyleVeggiePizza()
        {
            this.type = "CalforniaStyleVeggiePizza";
        }
    }
}
