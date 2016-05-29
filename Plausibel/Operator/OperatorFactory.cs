using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    class OperatorFactory
    {
        public BaseOperator GetOperatorByName(string operatorName, string name)
        {
            operatorName = GetClassName(operatorName);

            System.Console.WriteLine("Plausibel.Operator." + operatorName);
            Type type = Type.GetType("Plausibel.Operator." + operatorName);

            return (BaseOperator) Activator.CreateInstance(type, new object[] { name });
        }

        private string GetClassName(string name)
        {
            name = name.ToLower();
            name += "Operator";
            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}
