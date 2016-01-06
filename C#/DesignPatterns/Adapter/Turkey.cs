using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public class TurkeyAdapter : IDuck
    {
        private ITurkey _turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }

        public void Quack()
        {
            _turkey.Gobble();
        }

        public void Fly()
        {
            for(int i =0; i < 5; i++)
            {
                _turkey.Fly();
            }
        }

        public string GetStatus()
        {
            return _turkey.GetStatus();
        }
    }

    public interface ITurkey
    {
        void Gobble();
        void Fly();
        string GetStatus();
    }

    public class WildTurkey : ITurkey
    {
        private StringBuilder _status;

        public WildTurkey()
        {
            _status = new StringBuilder();
        }

        public void Gobble()
        {
            _status.Append(Strings.Gobble);
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
