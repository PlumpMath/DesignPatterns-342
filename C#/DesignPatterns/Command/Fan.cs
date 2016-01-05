using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    public class Fan
    {
        public Speed CurrentSpeed
        {
            get { return _speed; }
        }

        public enum Speed { Off, Low, Medium, High}

        private Speed _speed;

        public Fan()
        {
            _speed = Speed.Off;
        }

        internal void High()
        {
            this._speed = Speed.High;
        }

        internal void Medium()
        {
            this._speed = Speed.Medium;
        }

        internal void Low()
        {
            this._speed = Speed.Low;
        }

        internal void Off()
        {
            this._speed = Speed.Off;
        }

    }

    public class FanOffCommand :ICommand
    {
        private Fan _fan;
        private Fan.Speed _previousSpeed;

        public FanOffCommand(Fan fan)
        {
            this._fan = fan;
        }

        public void Execute()
        {
            this._fan.Off();
        }

        public void Undo()
        {
            if (_previousSpeed == Fan.Speed.Off)
            {
                this._fan.Off();
                return;
            }
            if (_previousSpeed == Fan.Speed.Low)
            {
                this._fan.Low();
                return;
            }
            if (_previousSpeed == Fan.Speed.Medium)
            {
                this._fan.Medium();
                return;
            }
            if (_previousSpeed == Fan.Speed.High)
            {
                this._fan.High();
                return;
            }
        }
    }

    public class FanHighCommand : ICommand
    {
        private Fan _fan;
        private Fan.Speed _previousSpeed;

        public FanHighCommand(Fan fan)
        {
            this._fan = fan;
            this._previousSpeed = Fan.Speed.Off;
        }

        public void Execute()
        {
            _previousSpeed = _fan.CurrentSpeed;
            this._fan.High();
        }

        public void Undo()
        {
            if(_previousSpeed == Fan.Speed.Off)
            {
                this._fan.Off();
                return;
            }
            if (_previousSpeed == Fan.Speed.Low)
            {
                this._fan.Low();
                return;
            }
            if (_previousSpeed == Fan.Speed.Medium)
            {
                this._fan.Medium();
                return;
            }
            if(_previousSpeed == Fan.Speed.High)
            {
                this._fan.High();
                return;
            }
        }
    }
}
