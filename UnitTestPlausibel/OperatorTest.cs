using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plausibel.Operator;

namespace UnitTestPlausibel
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod]
        public void OperatorTestAnd()
        {
            // arrange
            AndOperator and = new AndOperator("and");
            ProbeOperator probe = new ProbeOperator("probe");
            and.SetNextOperator(probe);

            // act
            and.SetValue(true);
            and.SetValue(true);

            // assert
            Assert.AreEqual(true, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestAndNegative()
        {
            // arrange
            AndOperator and = new AndOperator("and");
            ProbeOperator probe = new ProbeOperator("probe");
            and.SetNextOperator(probe);

            // act
            and.SetValue(false);
            and.SetValue(true);

            // assert
            Assert.AreEqual(false, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestOr()
        {
            // arrange
            OrOperator op = new OrOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(false);
            op.SetValue(true);

            // assert
            Assert.AreEqual(true, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestOrNegative()
        {
            // arrange
            OrOperator op = new OrOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(false);
            op.SetValue(false);

            // assert
            Assert.AreEqual(false, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestNand()
        {
            // arrange
            NandOperator op = new NandOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(true);
            op.SetValue(false);

            // assert
            Assert.AreEqual(true, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestNandNegative()
        {
            // arrange
            NandOperator op = new NandOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(true);
            op.SetValue(true);

            // assert
            Assert.AreEqual(false, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestNor()
        {
            // arrange
            NorOperator op = new NorOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(false);
            op.SetValue(false);

            // assert
            Assert.AreEqual(true, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestNorNegative()
        {
            // arrange
            NorOperator op = new NorOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(false);
            op.SetValue(true);

            // assert
            Assert.AreEqual(false, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestNot()
        {
            // arrange
            NotOperator op = new NotOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(false);

            // assert
            Assert.AreEqual(true, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestXor()
        {
            // arrange
            XorOperator op = new XorOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(true);
            op.SetValue(false);

            // assert
            Assert.AreEqual(true, probe.GetValue());
        }

        [TestMethod]
        public void OperatorTestXorNegative()
        {
            // arrange
            XorOperator op = new XorOperator("operator");
            ProbeOperator probe = new ProbeOperator("probe");
            op.SetNextOperator(probe);

            // act
            op.SetValue(true);
            op.SetValue(true);

            // assert
            Assert.AreEqual(false, probe.GetValue());
        }
    }
}
