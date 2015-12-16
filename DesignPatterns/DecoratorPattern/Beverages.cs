using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    namespace DecoratorPattern
    {
        public abstract class Beverage
        {
            internal string Description = "Unknown Beverage";

            public abstract double Cost();

            public abstract string GetDescription();
        }

        public class HouseBlend:Beverage
        {
            public HouseBlend()
            {
                this.Description = "House Blend";
            }

            public override double Cost()
            {
                return .89;
            }

            public override string GetDescription()
            {
                return this.Description;
            }
        }

        public class DarkRoast: Beverage
        {
            public DarkRoast()
            {
                this.Description = "Dark Roast";
            }

            public override double Cost()
            {
                return .99;
            }

            public override string GetDescription()
            {
                return this.Description;
            }
        }

        public class Espresso: Beverage
        {
            public Espresso()
            {
                this.Description = "Espresso";
            }

            public override double Cost()
            {
                return 1.99;
            }

            public override string GetDescription()
            {
                return this.Description;
            }
        }

        public class Decaf: Beverage
        {
            public Decaf()
            {
                this.Description = "Decaf";
            }

            public override double Cost()
            {
                return 1.05;
            }

            public override string GetDescription()
            {
                return this.Description;
            }
        }
    }
}
