﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class OrOperator : DualInputOperator
    {
        public OrOperator(String name) : base(name) { }

        public override bool PerformOperation()
        {
            return _Value[0] || _Value[1];
        }
    }
}
