using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class SetDomain<T> : IDomain<T>
        where T : IValue<T>
    {
        private HashSet<T> validValues;

        public SetDomain(HashSet<T> validValues)
        {
            this.validValues = new HashSet<T>(validValues);
        }
        public bool Contains(T information)
        {
            return validValues.Contains(information);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return validValues.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var v in validValues)
            {
                hash = (hash, v).GetHashCode();
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!GetType().Equals(obj.GetType()))
                return false;

            var co = (SetDomain<T>)obj;

            return this.SequenceEqual(co);
        }

        public override string ToString()
        {
            return $"{string.Join(",", validValues)}";
        }
    }
}
