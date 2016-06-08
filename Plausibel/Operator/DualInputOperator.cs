using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public abstract class DualInputOperator : BaseOperator
    {
        protected Boolean[] _Value = new bool[2];
        private int _Iterator = 0;

         public DualInputOperator(String name) : base(name) { }

        public override void SetValue(bool input)
        {
            _Value[_Iterator++] = input;

            if(_Iterator >= _Value.Length)
            {
                _IsFull = true;

                Boolean output = PerformOperation();
                Continue(output);
            }

            _IsUsed = true;
        }

        public override void Reset()
        {
            base.Reset();
            _Value = new bool[2];
            _Iterator = 0;
        }
    }
}
