using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class Projector
    {
        public States State { get; internal set; }

        public enum States { On,Off, PlayingMovie}

        public Projector()
        {
            State = States.Off;
        }

        public void TurnOff()
        {
            State = States.Off;
        }

        public void TurnOn()
        {
            State = States.On;
        }

        public void PlayMovie()
        {
            State = States.PlayingMovie;
        }
    }

    public class PopcornPopper
    {
        public States State { get; internal set; }

        public enum States { Off, Popping}

        public PopcornPopper()
        {
            State = States.Off;
        }

        public void TurnOff()
        {
            State = States.Off;
        }

        public void TurnOn()
        {
            State = States.Popping;
        }
    }

    public class Stero
    {
        public int Volume { get; internal set; }
        public States State
        {
            get
            {
                return _state;
            }
        }

        public enum States { Off, DVD, On}
        private States _state;

        public Stero()
        {
            _state = States.Off;
        }

        public void TurnOn()
        {
            _state = States.On;
            Volume = 0;
        } 

        public void SetToDVD()
        {
            _state = States.DVD;
            Volume = 5;
        }

        public void TurnOff()
        {
            _state = States.Off;
            Volume = 0;
        }
    }

    public class Lights
    {
        public States State
        {
            get { return _state; }
        }
        public enum States { On, Off, Dim}

        private States _state;

        public Lights()
        {
            _state = States.Off;
        }

        public void TurnOn()
        {
            _state = States.On;
        }

        public void TurnOff()
        {
            _state = States.Off;
        }

        public void Dim()
        {
            _state = States.Dim;
        }
    }
}
