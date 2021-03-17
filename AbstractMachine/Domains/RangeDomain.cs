using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    class RangeDomain<T> : IDomain<T>
        where T : IComparable<T>
    {
        public T Start { get; }
        public T End { get; }

        public RangeDomain(T start, T end)
        {
            if (start.CompareTo(end) > 0)
                throw new ArgumentOutOfRangeException(nameof(end), "End of range cannot be less than start of range");

            Start = start;
            End = end;
        }

        public bool Contains(T value)
        {
            bool biggerOrEqualThanStart = Start.CompareTo(value) <= 0;
            bool lessOrEqualThanEnd = End.CompareTo(value) >= 0;

            return biggerOrEqualThanStart && lessOrEqualThanEnd;
        }
    }
}
