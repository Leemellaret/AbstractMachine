using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class MappingAbstractMachineBuilder<TInput, TOutput, TState>//TODO: нужен ли этот класс вообще? если да, то не слишком ли много на нём ответственности?
                                                                       //TODO: Подумать над исключениями
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        private IMappingBuilder<TInput, TOutput, TState> mappingBuilder;
        
        private IDomainBuilder<TInput> inputDomainBuilder;
        private IDomainBuilder<TOutput> outputDomainBuilder;
        private IDomainBuilder<TState> stateDomainBuilder;

        private TState initialState;

        public MappingAbstractMachineBuilder()
        {
            mappingBuilder = new MappingBuilder<TInput, TOutput, TState>();

            inputDomainBuilder = new DomainBuilder<TInput>();
            outputDomainBuilder = new DomainBuilder<TOutput>();
            stateDomainBuilder = new DomainBuilder<TState>();

            initialState = default;
        }
        public MappingAbstractMachineBuilder(MappingAbstractMachine<TInput, TOutput, TState> s)
        {
            mappingBuilder = new MappingBuilder<TInput, TOutput, TState>(s.Mapping);

            inputDomainBuilder = new DomainBuilder<TInput>(s.InputDomain);
            outputDomainBuilder = new DomainBuilder<TOutput>(s.OutputDomain);
            stateDomainBuilder = new DomainBuilder<TState>(s.StateDomain);

            initialState = s.InitialState;
        }

        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddValueToInputDomain(TInput value)
        {
            inputDomainBuilder.AddValue(value);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddRangeToInputDomain(TInput start, TInput end)
        {
            inputDomainBuilder.AddRange(start, end);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveValueFromInputDomain(TInput value)
        {
            inputDomainBuilder.RemoveValue(value);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveRangeFromInputDomain(TInput start, TInput end)
        {
            inputDomainBuilder.RemoveRange(start, end);

            return this;
        }

        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddValueToOutputDomain(TOutput value)
        {
            outputDomainBuilder.AddValue(value);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddRangeToOutputDomain(TOutput start, TOutput end)
        {
            outputDomainBuilder.AddRange(start, end);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveValueFromOutputDomain(TOutput value)
        {
            outputDomainBuilder.RemoveValue(value);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveRangeFromOutputDomain(TOutput start, TOutput end)
        {
            outputDomainBuilder.RemoveRange(start, end);

            return this;
        }

        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddValueToStateDomain(TState value)
        {
            stateDomainBuilder.AddValue(value);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddRangeToStateDomain(TState start, TState end)
        {
            stateDomainBuilder.AddRange(start, end);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveValueFromStateDomain(TState value)
        {
            stateDomainBuilder.RemoveValue(value);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveRangeFromStateDomain(TState start, TState end)
        {
            stateDomainBuilder.RemoveRange(start, end);

            return this;
        }


        public MappingAbstractMachineBuilder<TInput, TOutput, TState> AddRow(MappingData<TInput, TState> input, MappingData<TOutput, TState> output)
        {
            mappingBuilder.AddRow(input, output);

            return this;
        }
        public MappingAbstractMachineBuilder<TInput, TOutput, TState> RemoveRow(MappingData<TInput, TState> input)
        {
            mappingBuilder.RemoveRow(input);

            return this;
        }

        public MappingAbstractMachineBuilder<TInput, TOutput, TState> SetInitialState(TState state)
        {
            initialState = state;

            return this;
        }

        public bool IsRowExist(MappingData<TInput, TState> input)
        {
            return mappingBuilder.IsRowExist(input);
        }

        public MappingAbstractMachine<TInput, TOutput, TState> CreateInstance()
        {
            var inputDomain = inputDomainBuilder.CreateInstance();
            var outputDomain = outputDomainBuilder.CreateInstance();
            var stateDomain = stateDomainBuilder.CreateInstance();
            var mapping = mappingBuilder.CreateInstance();
            var initState = new Information<TState>(initialState, stateDomain);
            
            return new MappingAbstractMachine<TInput, TOutput, TState>(inputDomain, outputDomain, stateDomain, mapping, initState);
        }

        public IDomain<TInput> GetInputDomainInstance()//TODO: Если весь класс нужен, то нужен ли в нём этот метод? Его ли это ответственность?
        {
            return inputDomainBuilder.CreateInstance();
        }
        public IDomain<TOutput> GetOutputDomainInstance()//TODO: Если весь класс нужен, то нужен ли в нём этот метод? Его ли это ответственность?
        {
            return outputDomainBuilder.CreateInstance();
        }
        public IDomain<TState> GetStateDomainInstance()//TODO: Если весь класс нужен, то нужен ли в нём этот метод? Его ли это ответственность?
        {
            return stateDomainBuilder.CreateInstance();
        }
        public IMapping<TInput, TOutput, TState> GetMappingInstance()//TODO: Если весь класс нужен, то нужен ли в нём этот метод? Его ли это ответственность?
        {
            return mappingBuilder.CreateInstance();
        }
    }
}
