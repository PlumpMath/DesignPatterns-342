using System;
using DesignPatterns.DecoratorPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    [TestClass]
    public class DecoratorPatternTests
    {
        [TestMethod]
        [TestCategory("Decorator")]
        public void StartBuzz()
        {
            Beverage testBeverage = new Decaf();
            testBeverage = new Whip(testBeverage);
            testBeverage = new SteamedMilk(testBeverage);
            testBeverage = new Soy(testBeverage);

            Assert.AreEqual("Decaf, Whip, Steamed Milk, Soy", testBeverage.GetDescription());
            Assert.AreEqual((double)(1.05 + .10 + .10 + .15), testBeverage.Cost());
        }

        [TestMethod]
        [TestCategory("Decorator")]
        public void Reader()
        {
            string inputString = "A Cool New Value";
            string uppercaseString = inputString.ToUpper();
            string lowercaseString = inputString.ToLower();
            
            #region String Reader
            Reader testReader = new StringReader(inputString);
            UppercaseReader upperReader = new UppercaseReader(testReader);
            LowercaseReader lowerReader = new LowercaseReader(testReader);
            Assert.AreEqual(lowercaseString, lowerReader.Read());
            Assert.AreEqual(uppercaseString, upperReader.Read());
            #endregion

            #region File Reader
            // Make a test file
            System.IO.FileInfo testFileInfo = new System.IO.FileInfo(".\\testFile.txt");
            //testFileInfo.Create();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(testFileInfo.OpenWrite()))
            {
                writer.Write(inputString);
            }

            Reader reader = new FileReader(testFileInfo);
            UppercaseReader upperFileReader = new UppercaseReader(reader);
            LowercaseReader lowerFileReader = new LowercaseReader(reader);
            Assert.AreEqual(uppercaseString, upperFileReader.Read());
            Assert.AreEqual(lowercaseString, lowerFileReader.Read());
            #endregion
        }
    }
}
