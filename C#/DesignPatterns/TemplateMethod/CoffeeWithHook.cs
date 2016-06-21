using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod
{
    public class CoffeeWithHook : CaffeineBeverage
    {
        public bool CustomerRequestedCondiments { get; set; }

        public CoffeeWithHook()
        { }

        public override void AddCondiments()
        {
            _Status.AppendLine("Dripping Coffee through filter");
        }

        public override void Brew()
        {
            _Status.AppendLine("Adding Sugar and Milk");
        }

        public override bool CustomerWantsCondiments()
        {
            return CustomerRequestedCondiments;
        }

    }
}
