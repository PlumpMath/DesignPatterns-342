using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Base
{
    public abstract class Pizza
    {
        public string Name { get; internal set; }
        public string Dough { get; internal set; }
        public string Sauce { get; internal set; }
        public string Cheeses { get; internal set; }
        public string Veggies { get; internal set; }
        public List<string> Toppings { get; internal set; }
        public string Status
        {
            get
            {
                return m_StatusBuilder.ToString();
            }
        }


        internal StringBuilder m_StatusBuilder;

        public Pizza()
        {
            Toppings = new List<string>();
            m_StatusBuilder = new StringBuilder();
        }

        public virtual void Prepare()
        {
            m_StatusBuilder.AppendLine("Prepare " + Name);
            m_StatusBuilder.AppendLine("Tossing dough...");
            m_StatusBuilder.AppendLine("Adding sauce...");
            m_StatusBuilder.AppendLine("Adding toppings: ");
            for (int i = 0; i < Toppings.Count; i++)
            {
                m_StatusBuilder.AppendLine("\t" + Toppings[i]);
            }
        }

        public virtual void Bake()
        {
            m_StatusBuilder.AppendLine("Bake for 25 minutes at 350");
        }

        public virtual void Cut()
        {
            m_StatusBuilder.AppendLine("Cut pizza into diagonal slices");
        }

        public virtual void Box()
        {
            m_StatusBuilder.AppendLine("Place pizza in official PizzaStore box");
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            this.Name = "NYStyleCheesePizza";
            this.Dough = "This Crust Dough";
            this.Sauce = "Marinara Sauce";

            this.Toppings.Add("Grated Reggiano Cheese");
        }
    }
    
    public class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            this.Name = "NYStyleClamPizza";
        }
    }

    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            this.Name = "NYStylePepperoniPizza";
        }
    }

    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            this.Name = "NYStyleVeggiePizza";
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            this.Name = "ChicagoStyleCheesePizza";
            this.Dough = "Extra Thick Crust Dough";
            this.Sauce = "Plum Tomato Sauce";

            this.Toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void Cut()
        {
            this.m_StatusBuilder.AppendLine("Cutting the pizza into square slices");
        }
    }    

    public class ChicagoStyleClamPizza : Pizza
    {
        public ChicagoStyleClamPizza()
        {
            this.Name = "ChicagoStyleClamPizza";
        }
    }

    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            this.Name = "ChicagoStylePepperoniPizza";
        }
    }

    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            this.Name = "ChicagoStyleVeggiePizza";
        }
    }

    public class CaliforniaStyleCheesePizza : Pizza
    {
        public CaliforniaStyleCheesePizza()
        {
            this.Name = "CaliforniaStyleCheesePizza";
        }
    }

    public class CaliforniaStyleClamPizza : Pizza
    {
        public CaliforniaStyleClamPizza()
        {
            this.Name = "CalforniaStyleClamPizza";
        }
    }

    public class CaliforniaStylePepperoniPizza : Pizza
    {
        public CaliforniaStylePepperoniPizza()
        {
            this.Name = "CalforniaStylePepperoniPizza";
        }
    }

    public class CaliforniaStyleVeggiePizza : Pizza
    {
        public CaliforniaStyleVeggiePizza()
        {
            this.Name = "CalforniaStyleVeggiePizza";
        }
    }
}
