using System;
using DesignPatterns.Adapter;
using DesignPatterns.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsTests
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        [TestCategory("Adapter/Facade")]
        public void TurkeyAdapter()
        {
            IDuck mDuck = new MallardDuck();
            ITurkey wTurkey = new WildTurkey();

            IDuck turkeyAdapter = new TurkeyAdapter(wTurkey);

            mDuck.Fly();
            mDuck.Quack();
            string expecteDuckBehavior = Strings.Fly + Strings.Quack;

            turkeyAdapter.Fly();
            turkeyAdapter.Quack();
            string expectedTurkeyAdapterBehavior = Strings.Fly + Strings.Fly + Strings.Fly + 
                Strings.Fly + Strings.Fly + Strings.Gobble;

            Assert.AreEqual(expecteDuckBehavior, mDuck.GetStatus());
            Assert.AreEqual(expectedTurkeyAdapterBehavior, turkeyAdapter.GetStatus());
            Assert.AreEqual(expectedTurkeyAdapterBehavior, wTurkey.GetStatus());
        }

        [TestMethod]
        [TestCategory("Adapter/Facade")]
        public void FacadeTest()
        {
            Projector projector = new Projector();
            PopcornPopper popper = new PopcornPopper();
            Stero stero= new Stero();
            Lights lights = new Lights();

            TheatreFacade theaterControl = new TheatreFacade(projector, popper, stero, lights);

            Assert.AreEqual(Projector.States.Off, projector.State);
            Assert.AreEqual(PopcornPopper.States.Off, popper.State);
            Assert.AreEqual(Stero.States.Off, stero.State);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Lights.States.Off, lights.State);


            theaterControl.TurnOn();

            Assert.AreEqual(Projector.States.On, projector.State);
            Assert.AreEqual(PopcornPopper.States.Popping, popper.State);
            Assert.AreEqual(Stero.States.On, stero.State);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Lights.States.On, lights.State);

            theaterControl.WatchMovie();

            Assert.AreEqual(Projector.States.PlayingMovie, projector.State);
            Assert.AreEqual(PopcornPopper.States.Popping, popper.State);
            Assert.AreEqual(Stero.States.DVD, stero.State);
            Assert.AreEqual((int)5, stero.Volume);
            Assert.AreEqual(Lights.States.Dim, lights.State);


            theaterControl.Shutdown();

            Assert.AreEqual(Projector.States.Off, projector.State);
            Assert.AreEqual(PopcornPopper.States.Off, popper.State);
            Assert.AreEqual(Stero.States.Off, stero.State);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Lights.States.Off, lights.State);

            theaterControl.Lights.TurnOn();

            Assert.AreEqual(Projector.States.Off, projector.State);
            Assert.AreEqual(PopcornPopper.States.Off, popper.State);
            Assert.AreEqual(Stero.States.Off, stero.State);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Lights.States.On, lights.State);
        }
    }
}
