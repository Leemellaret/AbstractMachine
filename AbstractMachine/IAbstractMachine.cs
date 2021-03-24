using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IAbstractMachine<TInput, TOutput, TState>
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        IDomain<TInput> InputDomain { get; }
        IDomain<TOutput> OutputDomain { get; }
        IDomain<TState> StateDomain { get; }
        IMapping<TInput, TOutput, TState> Mapping { get; }
        Information<TState> CurrentState { get; }
        Information<TOutput> Process(Information<TInput> input);
    }
}
