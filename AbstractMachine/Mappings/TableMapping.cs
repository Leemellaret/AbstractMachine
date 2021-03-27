using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class TableMapping<TInput, TOutput, TState> : IMapping<TInput, TOutput, TState>
    {
        private Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>> table;

        public TableMapping(TableMappingBuilder<TInput, TOutput, TState> builder)
        {
            table = builder.Rows;
        }

        public bool CanMap(MappingData<TInput, TState> value)
        {
            return table.ContainsKey(value);
        }

        public MappingData<TOutput, TState> Process(MappingData<TInput, TState> input)
        {
            if (!CanMap(input))
                throw new ArgumentOutOfRangeException(nameof(input), "There are no row in table with such input data.");

            return table[input];
        }

        public IEnumerator<Map<TInput, TOutput, TState>> GetEnumerator()
        {
            foreach (var item in table)
            {
                var input = item.Key;
                var output = item.Value;

                yield return new Map<TInput, TOutput, TState>
                {
                    InputValue = input.Data,
                    InputState = input.State,
                    
                    OutputValue = output.Data,
                    OutputState = output.State
                };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
