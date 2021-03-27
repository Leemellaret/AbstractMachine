using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IMappingAbstractMachine<TInput, TOutput, TState> : IAbstractMachine<Information<TInput>, Information<TOutput>, Information<TState>>
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        IDomain<TInput> InputDomain { get; }
        IDomain<TOutput> OutputDomain { get; }
        IDomain<TState> StateDomain { get; }
        IMapping<TInput, TOutput, TState> Mapping { get; }
    }
}
