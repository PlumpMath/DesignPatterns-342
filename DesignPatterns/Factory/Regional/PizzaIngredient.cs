using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Abstract
{
    public interface IPizzaIngredientFactory
    {
        IDough CreateDough();
        ISauce CreateSauce();
        ICheese[] CreateCheese();
        IVeggies[] CreateVeggies();
        IPepperoni CreatePepperoni();
        IClams CreateClam();
    }
    public class NYPizzaIngredientFacotry : IPizzaIngredientFactory
    {
        public ICheese[] CreateCheese()
        {
            return new ICheese[] { new ReggianoCheese() };
        }

        public IClams CreateClam()
        {
            return new FreshClams();
        }

        public IDough CreateDough()
        {
            return new ThingCrustDough();
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public ISauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public IVeggies[] CreateVeggies()
        {
            IVeggies[] veggies = new IVeggies[]
            {
                new Garlic(), new Onion(), new Mushroom(), new RedPepper()
            };
            return veggies;
        }
    }

    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public ICheese[] CreateCheese()
        {
            ICheese[] cheeses = new ICheese[]
            {
                new Mozzarella(),
                new Parmesan()
            };
            return cheeses;
        }

        public IClams CreateClam()
        {
            return new FrozenClams();
        }

        public IDough CreateDough()
        {
            return new ExtraThickDough();
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public ISauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public IVeggies[] CreateVeggies()
        {
            IVeggies[] veggies = new IVeggies[]
            {
                new Eggplant(),
                new Spinach(),
                new Oregano(),
                new BlackOlives()
            };
            return veggies;
        }
    }

    public interface IDough
    { }

    public interface ISauce
    { }

    public interface ICheese
    { }

    public interface IVeggies
    { }

    public interface IPepperoni
    { }

    public interface IClams
    { }

    public class ThingCrustDough : IDough
    { }

    public class ExtraThickDough : IDough
    { }

    public class MarinaraSauce : ISauce
    { }

    public class PlumTomatoSauce : ISauce
    { }

    public class ReggianoCheese : ICheese
    { }

    public class Mozzarella : ICheese
    { }

    public class Parmesan : ICheese
    { }

    public class Garlic : IVeggies
    { }

    public class Onion : IVeggies
    { }

    public class Mushroom : IVeggies
    { }

    public class RedPepper : IVeggies
    { }

    public class Eggplant : IVeggies
    { }

    public class Spinach : IVeggies
    { }

    public class BlackOlives : IVeggies
    { }

    public class Oregano : IVeggies
    { }

    public class SlicedPepperoni : IPepperoni
    { }

    public class FreshClams : IClams
    { }

    public class FrozenClams : IClams
    { }
}