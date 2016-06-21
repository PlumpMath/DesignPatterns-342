using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod
{
    public class Coffee : CaffeineBeverage
    {
        public Coffee()
        { }

        public override void AddCondiments()
        {
            _Status.AppendLine("Dripping Coffee through filter");
        }

        public override void Brew()
        {
            _Status.AppendLine("Adding Sugar and Milk");
        }
    }
}
