using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    namespace DecoratorPattern
    {
        public abstract class CondimentDecorator: Beverage
        {
        }

        public class Mocha: CondimentDecorator
        {
            private Beverage Beverage;

            public Mocha(Beverage Beverage)
            {
                this.Beverage = Beverage;
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription() + ", Mocha";
            }

            public override double Cost()
            {
                return .20 + this.Beverage.Cost();
            }
        }

        public class Soy: CondimentDecorator
        {
            private Beverage Beverage;

            public Soy(Beverage Beverage)
            {
                this.Beverage = Beverage;
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription() + ", Soy";
            }

            public override double Cost()
            {
                return .15 + this.Beverage.Cost();
            }
        }

        public class Whip: CondimentDecorator
        {
            private Beverage Beverage;

            public Whip(Beverage Beverage)
            {
                this.Beverage = Beverage;
            }

            public override string GetDescription()
            {
                return Beverage.GetDescription() + ", Whip";
            }

            public override double Cost()
            {
                return .10 + this.Beverage.Cost();
            }
        }

        public class SteamedMilk: CondimentDecorator
        {
            private Beverage Beverage;

            public SteamedMilk(Beverage Beverage)
            {
                this.Beverage = Beverage;
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription() + ", Steamed Milk";
            }

            public override double Cost()
            {
                return .10 + this.Beverage.Cost();
            }
        }
    }
}
