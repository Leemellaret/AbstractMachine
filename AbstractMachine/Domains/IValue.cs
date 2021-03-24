using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IValue<T> : IComparable<T>
    {
        T GetNextValue();
        T GetPreviousValue();
    }
}
