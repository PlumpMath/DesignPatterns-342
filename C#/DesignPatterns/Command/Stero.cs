using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    public class Stero
    {
        public int Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public State CurrentState
        {
            get { return _state; }
        }

        private bool _powered;
        public enum State { Off, CD, DVD, Radio}

        private int _volume;
        private State _state;
        
        public Stero()
        {
            this._state = State.Off;
            this._volume = 0;
            this._powered = false;
        }

        internal void TurnToCD()
        {
            if(_powered)
            {
                _state = State.CD;
            }
        }

        internal void TurnToDVD()
        {
            if(_powered)
                this._state = State.DVD;
        }

        internal void TurnToradio()
        {
            if(_powered)
                this._state = State.Radio;
        }

        internal void PowerOn()
        {
            _powered = true;
        }

        internal void PowerOff()
        {
            _powered = false;
            _state = State.Off;
            _volume = 0;
        }
    }

    public class SteroOnWithCDCommand : ICommand
    {
        private Stero _stero;
        private Stero.State _previousState;
        private int _previousVolume;

        public SteroOnWithCDCommand(Stero stero)
        {
            this._stero = stero;
        }

        public void Execute()
        {
            _previousState = _stero.CurrentState;
            _stero.PowerOn();
            _stero.Volume = 11;
            _stero.TurnToCD();
        }

        public void Undo()
        {
            if(_previousState == Stero.State.CD)
            {
                _stero.PowerOn();
                _stero.Volume = _previousVolume;
                _stero.TurnToCD();
                return;
            }
            if (_previousState == Stero.State.DVD)
            {
                _stero.PowerOn();
                _stero.Volume = _previousVolume;
                _stero.TurnToDVD();
                return;
            }
            if (_previousState == Stero.State.Radio)
            {
                _stero.PowerOn();
                _stero.Volume = _previousVolume;
                _stero.TurnToradio();
                return;
            }
            if (_previousState == Stero.State.Off)
            {
                _stero.PowerOff();
                _stero.Volume = _previousVolume;
                return;
            }
        }
    }

    public class SteroOffCommand :ICommand
    {
        private Stero _stero;
        private Stero.State _previousState;
        private int _previousVolume;

        public SteroOffCommand(Stero stero)
        {
            this._stero = stero;
        }

        public void Execute()
        {
            this._stero.PowerOff();
        }

        public void Undo()
        {
            if (_previousState == Stero.State.CD)
            {
                _stero.PowerOn();
                _stero.Volume = _previousVolume;
                _stero.TurnToCD();
                return;
            }
            if (_previousState == Stero.State.DVD)
            {
                _stero.PowerOn();
                _stero.Volume = _previousVolume;
                _stero.TurnToDVD();
                return;
            }
            if (_previousState == Stero.State.Radio)
            {
                _stero.PowerOn();
                _stero.Volume = _previousVolume;
                _stero.TurnToradio();
                return;
            }
            if (_previousState == Stero.State.Off)
            {
                _stero.PowerOff();
                _stero.Volume = _previousVolume;
                return;
            }
        }
    }
}
