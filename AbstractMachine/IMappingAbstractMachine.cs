using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IMappingAbstractMachine<TInput, TOutput, TState> : IAbstractMachine<TInput, TOutput, TState>
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        IMapping<TInput, TOutput, TState> Mapping { get; }
    }
}
