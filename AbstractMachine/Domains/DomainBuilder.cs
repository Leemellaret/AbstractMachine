using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class DomainBuilder<T> //TODO: нормально ли я делаю билдеры? может лучше вместо this возвращать новый экземпляр?
                                  //TODO: Может отказаться от этого билдера вовсе и сделать extension методы для IDomain?
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

        public DomainBuilder<T> AddValue(T value)
        {
            result.Add(value);

            return this;
        }

        public DomainBuilder<T> AddRange(T start, T end)
        {
            var range = new RangeDomain<T>(start, end);

            foreach (var value in range)
            {
                result.Add(value);
            }

            return this;
        }

        public IDomain<T> Build()
        {
            return new SetDomain<T>(result);
        }
    }
}
