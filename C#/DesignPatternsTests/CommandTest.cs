using System;
using System.Text;
using System.Collections.Generic;
using DesignPatterns.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsTests
{
    /// <summary>
    /// Summary description for CommandTest
    /// </summary>
    [TestClass]
    public class CommandTest
    {
        public CommandTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [TestCategory("Command")]
        public void SimpleRemoteTest()
        {
            Remotes remote = new Remotes();
            Light light1 = new Light();
            Light light2 = new Light();
            Assert.AreEqual(light1.CurrentState, Light.States.Off);
            Assert.AreEqual(light2.CurrentState, Light.States.Off);
            LightOnCommand lightOn = new LightOnCommand(light1);

            remote.SetCommand(lightOn);
            remote.ButtonWasPressed();

            // Make sure that only light 1 was turned on after pressing the button
            Assert.AreEqual(light1.CurrentState,Light.States.On);
            Assert.AreEqual(light2.CurrentState, Light.States.Off);
        }

        [TestMethod]
        [TestCategory("Command")]
        public void GarageDoorTest()
        {
            Remotes remote = new Remotes();
            GarageDoor door = new GarageDoor();
            Assert.AreEqual(door.LightState, GarageDoor.LightStates.Off);
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.Down);
            DoorUpCommand doorUp = new DoorUpCommand(door);
            DoorDownCommand doorDown = new DoorDownCommand(door);

            remote.SetCommand(doorUp);
            remote.ButtonWasPressed();

            // Make sure that the door went up and the light turned on
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.Up);
            Assert.AreEqual(door.LightState, GarageDoor.LightStates.On);

            remote.ButtonWasPressed();

            // Make sure that the door stayed up and the light stayed on after a second door up command
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.Up);
            Assert.AreEqual(door.LightState, GarageDoor.LightStates.On);

            door.AddObstruction();

            remote.SetCommand(doorDown);
            remote.ButtonWasPressed();

            // Make sure the door did not start closing when an obstruction was in the way 
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.Up);

            door.RemoveObstruction();
            remote.ButtonWasPressed();

            // Make sure that the door started ot go down when the button was pressed
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.GoingDown);

            door.AddObstruction();

            remote.ButtonWasPressed();

            // Make sure the door detected that something was in the way when is was coming down and went back up
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.Up);

            door.RemoveObstruction();

            remote.ButtonWasPressed();
            remote.ButtonWasPressed();


            // Make sure that when there are no obstructions and the button is pressed twice that the door closes
            // and the light turns off
            Assert.AreEqual(door.DoorState, GarageDoor.DoorStates.Down);
            Assert.AreEqual(door.LightState, GarageDoor.LightStates.Off);
        }

        [TestMethod]
        [TestCategory("Command")]
        public void RemoteTest()
        {
            Remote remote = new Remote();

            Light livingRoomLight = new Light();
            Light kitchenLight = new Light();
            Fan fan = new Fan();
            GarageDoor door = new GarageDoor();
            Stero stero = new Stero();

            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);
            LightOffCommand kitchenlightOff = new LightOffCommand(kitchenLight);
            FanHighCommand fanHighCommand = new FanHighCommand(fan);
            FanOffCommand fanOffCommand = new FanOffCommand(fan);
            DoorUpCommand doorUpCommand = new DoorUpCommand(door);
            DoorDownCommand doorDownCommand = new DoorDownCommand(door);
            SteroOnWithCDCommand steroOn = new SteroOnWithCDCommand(stero);
            SteroOffCommand steroOff = new SteroOffCommand(stero);

            remote.SetCommnd(0, livingRoomLightOn, livingRoomLightOff);
            remote.SetCommnd(1, kitchenLightOn, kitchenlightOff);
            remote.SetCommnd(2, fanHighCommand, fanOffCommand);
            remote.SetCommnd(3, doorUpCommand, doorDownCommand);
            remote.SetCommnd(4, steroOn, steroOff);


            Assert.AreEqual(Light.States.Off, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.Off, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Down, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.Off, door.LightState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Stero.State.Off,stero.CurrentState);

            remote.OnButtonPressed(0);
            Assert.AreEqual(Light.States.On, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.Off, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Down, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.Off, door.LightState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Stero.State.Off, stero.CurrentState);

            remote.OnButtonPressed(1);
            Assert.AreEqual(Light.States.On, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.On, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Down, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.Off, door.LightState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Stero.State.Off, stero.CurrentState);

            remote.OnButtonPressed(2);
            Assert.AreEqual(Fan.Speed.High, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Down, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.Off, door.LightState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Stero.State.Off, stero.CurrentState);

            remote.OnButtonPressed(3);
            Assert.AreEqual(GarageDoor.DoorStates.Up, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.On, door.LightState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Stero.State.Off, stero.CurrentState);

            remote.OnButtonPressed(4);
            Assert.AreEqual((int)11, stero.Volume);
            Assert.AreEqual(Stero.State.CD, stero.CurrentState);

            remote.OffButtonPressed(0);
            Assert.AreEqual(Light.States.Off, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.On, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.High, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Up, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.On, door.LightState);
            Assert.AreEqual((int)11, stero.Volume);
            Assert.AreEqual(Stero.State.CD, stero.CurrentState);

            remote.OffButtonPressed(1);
            Assert.AreEqual(Light.States.Off, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.Off, kitchenLight.CurrentState);
            Assert.AreEqual(GarageDoor.DoorStates.Up, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.On, door.LightState);
            Assert.AreEqual((int)11, stero.Volume);
            Assert.AreEqual(Stero.State.CD, stero.CurrentState);

            remote.OffButtonPressed(2);
            Assert.AreEqual(Light.States.Off, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.Off, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Up, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.On, door.LightState);
            Assert.AreEqual((int)11, stero.Volume);
            Assert.AreEqual(Stero.State.CD, stero.CurrentState);

            remote.OffButtonPressed(3);
            remote.OffButtonPressed(3);
            Assert.AreEqual(Light.States.Off, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.Off, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Down, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.Off, door.LightState);
            Assert.AreEqual((int)11, stero.Volume);
            Assert.AreEqual(Stero.State.CD, stero.CurrentState);

            remote.OffButtonPressed(4);
            Assert.AreEqual(Light.States.Off, livingRoomLight.CurrentState);
            Assert.AreEqual(Light.States.Off, kitchenLight.CurrentState);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
            Assert.AreEqual(GarageDoor.DoorStates.Down, door.DoorState);
            Assert.AreEqual(GarageDoor.LightStates.Off, door.LightState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Stero.State.Off, stero.CurrentState);
        }

        [TestMethod]
        [TestCategory("Command")]
        public void MacroCommandtest()
        {
            Remote remote = new Remote();

            Light light = new Light();
            Stero stero = new Stero();
            Fan fan = new Fan();

            LightOnCommand lightOn = new LightOnCommand(light);
            SteroOnWithCDCommand steroOn = new SteroOnWithCDCommand(stero);
            FanHighCommand fanOn = new FanHighCommand(fan);

            LightOffCommand lightOff = new LightOffCommand(light);
            SteroOffCommand steroOff = new SteroOffCommand(stero);
            FanOffCommand fanOff = new FanOffCommand(fan);

            MacroCommand macroCommandOn = new MacroCommand(new ICommand[] { lightOn, steroOn, fanOn });
            MacroCommand macroCommandOff = new MacroCommand(new ICommand[] { lightOff, steroOff, fanOff });

            remote.SetCommnd(0, macroCommandOn, macroCommandOff);
            remote.OnButtonPressed(0);

            Assert.AreEqual(Light.States.On, light.CurrentState);
            Assert.AreEqual(Stero.State.CD, stero.CurrentState);
            Assert.AreEqual((int)11, stero.Volume);
            Assert.AreEqual(Fan.Speed.High, fan.CurrentSpeed);

            remote.OffButtonPressed(0);
            Assert.AreEqual(Light.States.Off, light.CurrentState);
            Assert.AreEqual(Stero.State.Off, stero.CurrentState);
            Assert.AreEqual((int)0, stero.Volume);
            Assert.AreEqual(Fan.Speed.Off, fan.CurrentSpeed);
        }

        [TestMethod]
        [TestCategory("Command")]
        public void TestUndo()
        {
            // This test method could be fleshed out more for each type of appliance we are controlling.
            Light light = new Light();
            Light.States initialState = light.CurrentState;

            LightOnCommand lightOn = new LightOnCommand(light);
            lightOn.Execute();

            Assert.AreEqual(Light.States.On, light.CurrentState);

            lightOn.Undo();

            Assert.AreEqual(initialState, light.CurrentState);
        }
    }
}
