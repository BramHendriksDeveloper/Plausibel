using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plausibel.Parser;
using System.Collections.Generic;

namespace UnitTestPlausibel
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParserTester()
        {
            FileParser p = new FileParser();
            p.SetCircuitName("one");

            Dictionary<string, string> d = p.GetInitialization();
            p.StopParsing();

            Assert.AreEqual("INPUTHIGH", d["A"]);
            Assert.AreEqual("NOT", d["NODE7"]);
        }
    }
}
