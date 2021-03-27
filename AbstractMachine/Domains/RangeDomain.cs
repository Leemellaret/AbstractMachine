using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    class RangeDomain<T> : IDomain<T>
        where T : IValue<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            for (T v = Start; v.CompareTo(End) <= 0; v = v.GetNextValue())
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override int GetHashCode()
        {
            return (Start, End).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!GetType().Equals(obj.GetType()))
                return false;

            var castedObj = (RangeDomain<T>)obj;

            return Start.Equals(castedObj.Start) && End.Equals(castedObj.End);
        }

        public override string ToString()
        {
            return $"[{Start}, {End}]";
        }
    }
}
