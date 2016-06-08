using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plausibel.Parser;
using System.Collections.Generic;
using Plausibel.Cirquit;
using Plausibel.Operator;

namespace UnitTestPlausibel
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ParserTestInit()
        {
            // arrange
            FileParser p = new FileParser();
            p.SetCircuitName("one");

            // act
            Dictionary<string, string> d = p.GetInitialization();
            p.StopParsing();

            //  assert
            Assert.AreEqual("INPUTHIGH", d["A"]);
            Assert.AreEqual("NOT", d["NODE7"]);
        }

        [TestMethod]
        public void ParserTestDecorator()
        {
            // arrange
            FileParser p = new FileParser();
            CirquitCreator cc = new CirquitCreator(p);

            // act
            Cirquit c = cc.GetCirquit("one");
            List<InputOperator> InputOperators = c.GetInputOperators();

            // assert
            Assert.AreEqual(3, InputOperators.Count);
            Assert.AreEqual("A", InputOperators[0].GetName());
            Assert.AreEqual("B", InputOperators[1].GetName());
            Assert.AreEqual("Cin", InputOperators[2].GetName());
        }
    }
}
