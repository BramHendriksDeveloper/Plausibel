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
            _Value = input;
        }

        public bool GetValue()
        {
            return _Value;
        }
    }
}
