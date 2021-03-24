using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IMapping<TInput, TOutput, TState> : IEnumerable<Map<TInput, TOutput, TState>>//TODO: нужно ли здесь, чтобы типы-параметры реализовывали IValue?
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        MappingData<TOutput, TState> Process(MappingData<TInput, TState> input);
        bool CanMap(MappingData<TInput, TState> input);
    }
}
