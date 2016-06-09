using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plausibel.Operator;
using Plausibel.Parser;
using Plausibel.Cirquit;

namespace UnitTestPlausibel
{
    [TestClass]
    public class CircuitTest
    {

        [TestMethod]
        public void CircuitTestOne()
        {
            // arrange
            OperatorFactory opFactory = new OperatorFactory();
            FileParser fParser = new FileParser();
            CirquitCreator cCreator = new CirquitCreator(fParser);
            Cirquit cirquit = cCreator.GetCirquit("one");

            // act
            Dictionary<string, bool> output = cirquit.Emulate(new Dictionary<string, bool> {
                { "A", false },
                { "B", false },
                { "Cin", false },
            });

            // assert
            Assert.AreEqual(false, output["S"]);
            Assert.AreEqual(false, output["Cout"]);
        }

        [TestMethod]
        public void CircuitTestOne2()
        {
            // arrange
            OperatorFactory opFactory = new OperatorFactory();
            FileParser fParser = new FileParser();
            CirquitCreator cCreator = new CirquitCreator(fParser);
            Cirquit cirquit = cCreator.GetCirquit("one");

            // act
            Dictionary<string, bool> output = cirquit.Emulate(new Dictionary<string, bool> {
                { "A", false },
                { "B", true },
                { "Cin", false },
            });

            // assert
            Assert.AreEqual(true, output["S"]);
            Assert.AreEqual(false, output["Cout"]);
        }

        [TestMethod]
        public void CircuitTestOne3()
        {
            // arrange
            OperatorFactory opFactory = new OperatorFactory();
            FileParser fParser = new FileParser();
            CirquitCreator cCreator = new CirquitCreator(fParser);
            Cirquit cirquit = cCreator.GetCirquit("one");

            // act
            Dictionary<string, bool> output = cirquit.Emulate(new Dictionary<string, bool> {
                { "A", false },
                { "B", true },
                { "Cin", true },
            });

            // assert
            Assert.AreEqual(false, output["S"]);
            Assert.AreEqual(true, output["Cout"]);
        }

        [TestMethod]
        public void CircuitTestOne4()
        {
            // arrange
            OperatorFactory opFactory = new OperatorFactory();
            FileParser fParser = new FileParser();
            CirquitCreator cCreator = new CirquitCreator(fParser);
            Cirquit cirquit = cCreator.GetCirquit("one");

            // act
            Dictionary<string, bool> output = cirquit.Emulate(new Dictionary<string, bool> {
                { "A", true },
                { "B", true },
                { "Cin", true },
            });

            // assert
            Assert.AreEqual(true, output["S"]);
            Assert.AreEqual(true, output["Cout"]);
        }

        [TestMethod]
        public void CircuitTestThree()
        {
            // arrange
            OperatorFactory opFactory = new OperatorFactory();
            FileParser fParser = new FileParser();
            CirquitCreator cCreator = new CirquitCreator(fParser);
            Cirquit cirquit = cCreator.GetCirquit("three");

            // act
            Dictionary<string, bool> output = cirquit.Emulate(new Dictionary<string, bool> {
                { "A", false }
            });

            // assert
            Assert.AreEqual(false, output["F"]);
        }
    }
}
