using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plausibel.Operator;

namespace Plausibel
{
    class Program
    {
        static void Main(string[] args)
        {

            OperatorFactory x = new OperatorFactory();
            Parser p = new Parser();

            Cirquit c = p.GetCirquit("one");
            bool xd = c.Emulate(true, false, false);

            BaseOperator o = x.GetOperatorByName("and", "first");

            System.Console.WriteLine(o.GetType());

        }
    }
}
