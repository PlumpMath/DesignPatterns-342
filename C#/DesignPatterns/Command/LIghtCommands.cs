using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    public class Light
    {
        public States CurrentState
        {
            get { return _state; }
        }

        private States _state;

        public enum States { On, Off, Dim};

        public Light()
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

        public void DimLights()
        {
            _state = States.Dim;
        }
    }

    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            this._light.TurnOn();
        }

        public void Undo()
        {
            this._light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            this._light.TurnOff();
        }

        public void Undo()
        {
            this._light.TurnOn();
        }
    }
}
