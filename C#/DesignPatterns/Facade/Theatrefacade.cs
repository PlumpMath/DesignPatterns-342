using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class TheatreFacade
    {
        public Projector Projector;
        public PopcornPopper PopcornPopper;
        public Stero Stero;
        public Lights Lights;

        public TheatreFacade(Projector projector, PopcornPopper popper, Stero stero, Lights lights)
        {
            this.Projector = projector;
            this.PopcornPopper = popper;
            this.Stero = stero;
            this.Lights = lights;
        }

        public void TurnOn()
        {
            this.Projector.TurnOn();
            this.PopcornPopper.TurnOn();
            this.Stero.TurnOn();
            this.Lights.TurnOn();
        }

        public void WatchMovie()
        {
            this.Projector.PlayMovie();
            this.PopcornPopper.TurnOn();
            this.Stero.SetToDVD();
            this.Lights.Dim();
        }

        public void Shutdown()
        {
            this.Projector.TurnOff();
            this.PopcornPopper.TurnOff();
            this.Stero.TurnOff();
            this.Lights.TurnOff();
        }
    }
}
