using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    abstract public class BaseOperator
    {
        public abstract double Delay
        {
            get;
        }

        protected double _TotalDelay = 0;

        private String _Name = null;
        private List<BaseOperator> _NextOperators = new List<BaseOperator>();
        protected Boolean _IsUsed = false;
        protected Boolean _IsFull = false;

        protected BaseOperator(String name)
        {
            _Name = name;
        }

        public void SetNextOperator(BaseOperator next)
        {
            _NextOperators.Add(next);
        }

        virtual public void Continue(Boolean output)
        {
            foreach (BaseOperator next in _NextOperators)
            {
                System.Console.WriteLine("Nav from " + _Name + " to " + next.GetName());
                next.SetDelay(_TotalDelay + Delay);
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

        protected void SetDelay(double delay)
        {
            _TotalDelay = delay;
        }

        public double GetDelay()
        {
            return _TotalDelay + Delay;
        }

        abstract public Boolean PerformOperation();


        abstract public void SetValue(Boolean input);


    }
}
