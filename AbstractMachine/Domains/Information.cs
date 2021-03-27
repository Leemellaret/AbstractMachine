using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class Information<T>
        where T : IValue<T>
    {
        public T Value { get; }
        public IDomain<T> Domain { get; }

        public Information(T value, IDomain<T> domain)
        {
            if (!domain.Contains(value))
                throw new ArgumentOutOfRangeException(nameof(value), "Given value is not in given domain");

            Value = value;
            Domain = domain;
        }

        public static implicit operator T(Information<T> information)
        {
            return information.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!GetType().Equals(obj.GetType()))
                return false;

            var castedObj = (Information<T>)obj;

            return Value.Equals(castedObj.Value) && Domain.Equals(castedObj.Domain);
        }

        public override int GetHashCode()
        {
            return (Value, Domain).GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
