using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine.Domains
{
    public static class DomainOperationsExtensions
    {
        public static IDomain<T> UnionWith<T>(this IDomain<T> first, IDomain<T> second) where T : IValue<T>
        {
            var result = new DomainBuilder<T>(first);



            return result.CreateInstance();

        }
        
        public static IDomain<T> IntersectionWith<T>(this IDomain<T> first, IDomain<T> second) where T : IValue<T>
        {
            var result = new DomainBuilder<T>(first);



            return result.CreateInstance();
        }

        public static IDomain<T> Difference<T>(this IDomain<T> first, IDomain<T> second) where T : IValue<T>
        {
            var result = new DomainBuilder<T>(first);



            return result.CreateInstance();
        }
    }
}
