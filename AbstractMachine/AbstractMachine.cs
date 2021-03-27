using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class AbstractMachine<TInput, TOutput, TState> : IAbstractMachine<TInput, TOutput, TState>
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        public IDomain<TInput> InputDomain { get; }

        public IDomain<TOutput> OutputDomain { get; }

        public IDomain<TState> StateDomain { get; }

        public IMapping<TInput, TOutput, TState> Mapping { get; }

        public Information<TState> CurrentState { get; private set; }

        public AbstractMachine(IDomain<TInput> inputDomain, IDomain<TOutput> outputDomain, IDomain<TState> stateDomain, IMapping<TInput, TOutput, TState> mapping, Information<TState> initialState)
        {
            InputDomain = inputDomain;
            OutputDomain = outputDomain;
            StateDomain = stateDomain;


            if (!MappingValidityChecker.IsMappingInDomains(mapping, inputDomain, outputDomain, stateDomain))
                throw new ArgumentOutOfRangeException(nameof(mapping), "At least one of values in given mapping is not in its domain.");

            Mapping = mapping;


            if (!stateDomain.Contains(initialState))
                throw new ArgumentOutOfRangeException(nameof(initialState), "Given initial state is not in StateDomain.");

            CurrentState = initialState;
        }

        public Information<TOutput> Process(Information<TInput> input)
        {
            var mappingInput = new MappingData<TInput, TState>(input.Value, CurrentState.Value);


            if (!Mapping.CanMap(mappingInput))
                throw new Exception("Mapping cannot process given input with current state");//TODO: создать своё исключение для этого случая

            var mappingOutput = Mapping.Process(mappingInput);

            CurrentState = new Information<TState>(mappingOutput.State, StateDomain);

            return new Information<TOutput>(mappingOutput.Data, OutputDomain);

        }
    }
}
