using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    public class GarageDoor
    {
        public LightStates LightState
        {
            get { return _lightState; }
        }

        public DoorStates DoorState
        {
            get { return _doorState; }
        }

        public enum DoorStates { Up, Down, GoingDown, Obstructed}
        public enum LightStates {  On, Off}

        private LightStates _lightState;
        private DoorStates _doorState;

        public GarageDoor()
        {
            this._lightState = LightStates.Off;
            this._doorState = DoorStates.Down;
        }

        public void RaiseDoor()
        {
            _doorState = DoorStates.Up;
            _lightState = LightStates.On;
        }

        public void LowerDoor()
        {
            // This method will make the door go down if it is up and will check for an obstruction before going down; 
            if (_doorState == DoorStates.Obstructed)
            {
                _doorState = DoorStates.Up;
                return;
            }
            
            if (_doorState == DoorStates.Down)
            {
                return;
            }

            if(_doorState == DoorStates.GoingDown)
            {
                _doorState = DoorStates.Down;
                _lightState = LightStates.Off;
                return;
            }

            _doorState = DoorStates.GoingDown;

        }

        public void LightsOff()
        {
            _lightState = LightStates.Off;
        }

        public void LightsOn()
        {
            _lightState = LightStates.On;
        }

        public void AddObstruction()
        {
            this._doorState = DoorStates.Obstructed;
        }

        public void RemoveObstruction()
        {
            this._doorState = DoorStates.Up;
        }
    }

    public class DoorUpCommand : ICommand
    {
        private GarageDoor _door;

        public DoorUpCommand(GarageDoor door)
        {
            this._door = door;
        }

        public void Execute()
        {
            this._door.RaiseDoor();
        }

        public void Undo()
        {
            throw new Exception("Invalid opperation");
        }
    }

    public class DoorDownCommand : ICommand
    {
        private GarageDoor _door;

        public DoorDownCommand(GarageDoor _door)
        {
            this._door = _door;
        }

        public void Execute()
        {
            this._door.LowerDoor();
        }

        public void Undo()
        {
            throw new Exception("Invalid opperation");
        }
    }
}
