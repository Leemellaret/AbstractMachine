using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IMapping<TInput, TOutput, TState> : IEnumerable<Map<TInput, TOutput, TState>>
    {
        MappingData<TOutput, TState> Process(MappingData<TInput, TState> input);
        bool CanMap(MappingData<TInput, TState> input);
    }
}
