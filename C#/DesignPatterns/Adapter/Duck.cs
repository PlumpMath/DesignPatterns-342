using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public interface IDuck
    {
        void Quack();
        void Fly();
        string GetStatus();
    }

    public class MallardDuck : IDuck
    {
        private StringBuilder _status;

        public MallardDuck()
        {
            _status = new StringBuilder();
        }

        public void Quack()
        {
            _status.Append(Strings.Quack);
        }

        public void Fly()
        {
            _status.Append(Strings.Fly);
        }

        public string GetStatus()
        {
            return _status.ToString();
        }
    }
}
