using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IDomainBuilder<T>
        where T : IValue<T>
    {
        IDomainBuilder<T> AddValue(T value);
        IDomainBuilder<T> AddRange(T start, T end);
        IDomainBuilder<T> RemoveValue(T value);
        IDomainBuilder<T> RemoveRange(T start, T end);
        IDomain<T> CreateInstance();
    }
}
