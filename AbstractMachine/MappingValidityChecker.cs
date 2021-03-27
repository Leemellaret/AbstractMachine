using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public static class MappingValidityChecker
    {
        public static bool IsMappingInDomains<TInput, TOutput, TState>(IMapping<TInput, TOutput, TState> mapping, IDomain<TInput> inputDomain, IDomain<TOutput> outputDomain, IDomain<TState> stateDomain)
            where TInput : IValue<TInput>
            where TOutput : IValue<TOutput>
            where TState : IValue<TState>
        {
            foreach (var map in mapping)
            {
                if (!inputDomain.Contains(map.InputValue))
                    return false;

                if (!stateDomain.Contains(map.InputState))
                    return false;

                if (!outputDomain.Contains(map.OutputValue))
                    return false;

                if (!stateDomain.Contains(map.OutputState))
                    return false;
            }

            return true;
        }
    }
}
