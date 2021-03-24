using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    class Integer : IValue<Integer>
    {
        public int Value { get; }
        public Integer(int value)
        {
            Value = value;
        }
        public int CompareTo(Integer other)
        {
            return Value.CompareTo(other.Value);
        }

        public Integer GetNextValue()
        {
            return new Integer(Value + 1);
        }

        public Integer GetPreviousValue()
        {
            return new Integer(Value - 1);
        }

        public static implicit operator int(Integer n)//TODO: дать нормальное название параметру
        {
            return n.Value;
        }

        public static implicit operator Integer(int n)
        {
            return new Integer(n);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!GetType().Equals(obj.GetType()))
                return false;

            var castedObject = (Integer)obj;

            return Value == castedObject.Value;

        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
