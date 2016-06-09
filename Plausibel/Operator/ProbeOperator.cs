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

        private Boolean _Value;

        public ProbeOperator(String name) : base(name) { }

        public override bool PerformOperation()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(bool input, Boolean showProcess)
        {
            _IsFull = true;
            _IsUsed = true;
            _Value = input;
        }

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

        public override void Reset()
        {
            base.Reset();
            _Value = false;
        }
    }
}
