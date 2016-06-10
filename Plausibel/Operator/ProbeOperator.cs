using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class ProbeOperator : BaseOperator
    {
        private static double _Delay = 0.3;

        public override double Delay
        {
            get
            {
                return ProbeOperator._Delay;
            }
        }

        /// <summary>
        /// Since the value of the probe should be accessable over time, save it as a prop
        /// </summary>
        private Boolean _Value;

        public ProbeOperator(String name) : base(name) { }

        public override bool PerformOperation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the value of the probe operator
        /// </summary>
        /// <param name="input"></param>
        /// <param name="showProcess"></param>
        public override void SetValue(bool input, Boolean showProcess)
        {
            _IsFull = true;
            _IsUsed = true;
            _Value = input;
        }

        /// <summary>
        /// Get the value of the probe operator. This method will output errors in the console
        /// </summary>
        /// <returns></returns>
        public Boolean GetValue()
        {
            if (!IsUsed())
            {
                System.Console.WriteLine("This operator ("+ GetName() +") has not been used yet.");
            }
            else if (!IsFull())
            {
                System.Console.WriteLine("This operator (" + GetName() + ") has no value yet.");
            }

            return _Value;
        }

        /// <summary>
        /// Rest the probe operator
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            _Value = false;
        }
    }
}
