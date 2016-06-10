using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class OperatorFactory
    {

        /// <summary>
        /// Return the corresponding Operator by name
        /// </summary>
        /// <param name="operatorName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public BaseOperator GetOperatorByName(string operatorName, string name)
        {
            operatorName = GetClassName(operatorName);
            
            Type type = Type.GetType("Plausibel.Operator." + operatorName);
            
            if(type == null)
            {
                Console.WriteLine("Operator does not exist");
                return null;
            }

            return (BaseOperator) Activator.CreateInstance(type, new object[] { name });
        }

        /// <summary>
        /// Get the full classname by operator name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetClassName(string name)
        {
            name = name.ToLower();
            name += "Operator";
            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}
