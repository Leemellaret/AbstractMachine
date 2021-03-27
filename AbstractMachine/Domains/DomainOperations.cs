using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine.Domains
{
    public static class DomainOperations
    {
        public static IDomain<T> UnionWith<T>(this IDomain<T> first, IDomain<T> second) where T : IValue<T>
        {
            var result = new DomainBuilder<T>(first);

            foreach (var v in second)
            {
                result.AddValue(v);
            }

            return result.CreateInstance();

        }
        
        public static IDomain<T> IntersectionWith<T>(this IDomain<T> first, IDomain<T> second) where T : IValue<T>
        {
            var result = new DomainBuilder<T>();

            foreach (var v in first)
            {
                if (second.Contains(v))
                    result.AddValue(v);
            }

            return result.CreateInstance();
        }

        public static IDomain<T> DifferenceWith<T>(this IDomain<T> first, IDomain<T> second) where T : IValue<T>
        {
            var result = new DomainBuilder<T>(first);

            foreach (var v in second)
            {
                result.RemoveValue(v);
            }

            return result.CreateInstance();
        }

        public static IDomain<TResult> CartesianProduct<T1, T2, TResult>(this IDomain<T1> first, IDomain<T2> second, Func<T1, T2, TResult> selector)
            where T1 : IValue<T1>
            where T2 : IValue<T2>
            where TResult : IValue<TResult>
        {
            var result = new DomainBuilder<TResult>();

            foreach (var item1 in first)
            {
                foreach (var item2 in second)
                {
                    result.AddValue(selector(item1, item2));
                }
            }

            return result.CreateInstance();
        }
    }
}
