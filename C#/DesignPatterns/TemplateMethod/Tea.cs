using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod
{
    public class Tea : CaffeineBeverage
    {
        public Tea()
        { }

        public override void AddCondiments()
        {
            _Status.AppendLine("Adding Lemon");
        }

        public override void Brew()
        {
            _Status.AppendLine("Steeping the tea");
        }
    }
}
