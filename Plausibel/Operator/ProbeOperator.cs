using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    class ProbeOperator : BaseOperator
    {

        private Boolean _Value;

        public ProbeOperator(String name) : base(name) { }

        public override bool PerformOperation()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(bool input)
        {
            _IsFull = true;
            _IsUsed = true;
            _Value = input;
        }

        public bool GetValue()
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
    }
}
