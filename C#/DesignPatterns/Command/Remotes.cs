using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    public class Remotes
    {
        private ICommand slot;

        public Remotes()
        { }

        public void SetCommand(ICommand command)
        {
            slot = command;
        }

        public void ButtonWasPressed()
        {
            slot.Execute();
        }
    }

    public class Remote
    {
        private ICommand[] _onCommands;
        private ICommand[] _offCommands;
        private ICommand _undoCommand;

        public Remote()
        {
            _onCommands = new ICommand[7];
            _offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for(int i = 0; i < _onCommands.Length; i++)
            {
                _onCommands[i] = noCommand;
                _offCommands[i] = noCommand;
            }
        }

        public void SetCommnd(int slot, ICommand onCommand, ICommand offCommand)
        {
            _onCommands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }

        public void OnButtonPressed(int slot)
        {
            _onCommands[slot].Execute();
            _undoCommand = _onCommands[slot];
        }

        public void OffButtonPressed(int slot)
        {
            _offCommands[slot].Execute();
            _undoCommand = _offCommands[slot];
        }

        public void undoButtonPushed()
        {
            _undoCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("\n----- Remote Control -----\n");
            for(int i = 0;i < _onCommands.Length; i++)
            {
                builder.AppendFormat("[slot {0} : {1}]\n", _onCommands[i].GetType(), _offCommands.GetType());
            }

            return builder.ToString();
        }
    }

    public class NoCommand : ICommand
    {
        public void Execute()
        { }

        public void Undo()
        { }
    }
}
