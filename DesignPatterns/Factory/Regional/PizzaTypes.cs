using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Abstract
{
    public abstract class Pizza
    {
        public string Name { get; internal set; }
        public IDough Dough { get; internal set; }
        public ISauce Sauce { get; internal set; }
        public ICheese[] Cheeses { get; internal set; }
        public IVeggies Veggies { get; internal set; }
        public IClams Clams { get; internal set; }
        public List<object> Toppings { get; internal set; }
        public string Status
        {
            get
            {
                return m_StatusBuilder.ToString();
            }
        }

        internal IPizzaIngredientFactory IngredientFactory;


        internal StringBuilder m_StatusBuilder;

        public Pizza()
        {
            Toppings = new List<object>();
            m_StatusBuilder = new StringBuilder();
        }

        public abstract void Prepare();

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

    public class CheesePizza : Pizza
    {
        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            this.IngredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            m_StatusBuilder.AppendLine("Preparing " + Name);
            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheeses = IngredientFactory.CreateCheese();
        }
    }

    public class ClamPizza : Pizza
    {
        public ClamPizza(IPizzaIngredientFactory ingredientFactory)
        {
            this.IngredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            m_StatusBuilder.AppendLine("Preparing : " + Name);
            this.Dough = IngredientFactory.CreateDough();
            this.Sauce = IngredientFactory.CreateSauce();
            this.Cheeses = IngredientFactory.CreateCheese();
            this.Clams = IngredientFactory.CreateClam();
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
        {
            this.IngredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            m_StatusBuilder.AppendLine("Preparing " + Name);
            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheeses = IngredientFactory.CreateCheese();
            Toppings.Add(IngredientFactory.CreatePepperoni());
        }
    }

    public class VeggiePizza : Pizza
    {
        public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
        {
            this.IngredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            m_StatusBuilder.AppendLine("Preparing " + Name);
            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheeses = IngredientFactory.CreateCheese();
            Toppings.Add(IngredientFactory.CreateVeggies());
        }
    }
}
