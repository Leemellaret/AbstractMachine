using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class DomainBuilder<T> : IDomainBuilder<T>
        where T : IValue<T>
    {
        private HashSet<T> result;

        public DomainBuilder()
        {
            result = new HashSet<T>();
        }

        public DomainBuilder(IDomain<T> sourceDomain)
        {
            result = sourceDomain.ToHashSet();
        }

        public static DomainBuilder<T> CreateEmptyBuilder()
        {
            return new DomainBuilder<T>();
        }

        public static DomainBuilder<T> CreateBuilderFrom(IDomain<T> sourceDomain)
        {
            return new DomainBuilder<T>(sourceDomain);
        }

        public IDomainBuilder<T> AddValue(T value)
        {
            result.Add(value);

            return this;
        }

        public IDomainBuilder<T> AddRange(T start, T end)
        {
            var range = new RangeDomain<T>(start, end);

            foreach (var value in range)
            {
                result.Add(value);
            }

            return this;
        }

        public IDomainBuilder<T> RemoveValue(T value)
        {
            result.Remove(value);

            return this;
        }

        public IDomainBuilder<T> RemoveRange(T start, T end)
        {
            var range = new RangeDomain<T>(start, end);

            foreach (var value in range)
            {
                result.Remove(value);
            }
            
            return this;
        }

        public IDomain<T> CreateInstance()
        {
            return new SetDomain<T>(result);
        }
    }
}
