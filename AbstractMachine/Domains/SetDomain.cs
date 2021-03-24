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
    }
}
