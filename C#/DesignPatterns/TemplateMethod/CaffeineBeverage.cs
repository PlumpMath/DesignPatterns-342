using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod
{
    public abstract class CaffeineBeverage
    {
        public string Status
        {
            get
            {
                return _Status.ToString();
            }
        }

        internal protected StringBuilder _Status;

        public CaffeineBeverage()
        {
            _Status = new StringBuilder();
        }

        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if( CustomerWantsCondiments())
            {
                AddCondiments();
            }
        }

        public void BoilWater()
        {
            _Status.AppendLine("Boiling Water");
        }

        public abstract void Brew();

        public void PourInCup()
        {
            _Status.AppendLine("Pouring into cup");
        }

        public abstract void AddCondiments();

        public virtual bool CustomerWantsCondiments()
        {
            return true;
        }
    }
}
