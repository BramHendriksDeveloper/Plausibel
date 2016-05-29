using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    abstract public class BaseOperator
    {

        private String _Name = null;
        private List<BaseOperator> _NextOperators = new List<BaseOperator>();
        protected Boolean _IsUsed = false;
        protected Boolean _IsFull = false;

        protected BaseOperator (String name)
        {
            _Name = name;
        }

        public void SetNextOperator(BaseOperator next)
        {
            _NextOperators.Add(next);
        }

        virtual public void Continue(Boolean output)
        {
            foreach(BaseOperator next in _NextOperators)
            {
                System.Console.WriteLine("Nav from " + _Name + " to " + next.GetName());
                next.SetValue(output);
            }
        }

        public Boolean IsUsed()
        {
            return _IsUsed;
        }

        public Boolean IsFull()
        {
            return _IsFull;
        }

        public string GetName()
        {
            return _Name;
        }

        abstract public Boolean PerformOperation();


        abstract public void SetValue(Boolean input);

        
    }
}
