using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class MappingBuilder<TInput, TOutput, TState> : IMappingBuilder<TInput, TOutput, TState>
    {
        private Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>> rows;

        public MappingBuilder()
        {
            rows = new Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>>();
        }

        public MappingBuilder(IMapping<TInput, TOutput, TState> sourceTableMapping)
        {
            rows = sourceTableMapping.ToDictionary(
                m => new MappingData<TInput, TState>(m.InputValue, m.InputState), 
                m => new MappingData<TOutput, TState>(m.OutputValue, m.OutputState));
        }

        public IMappingBuilder<TInput, TOutput, TState> AddRow(MappingData<TInput, TState> input, MappingData<TOutput, TState> output)
        {
            if (IsRowExist(input))
                throw new InvalidOperationException("This row already exist in table.");

            rows.Add(input, output);

            return this;
        }

        public IMappingBuilder<TInput, TOutput, TState> RemoveRow(MappingData<TInput, TState> input)
        {
            if (!IsRowExist(input))
                throw new InvalidOperationException("This row does not exist in table.");

            rows.Remove(input);

            return this;
        }

        public bool IsRowExist(MappingData<TInput, TState> input)
        {
            return rows.ContainsKey(input);
        }

        public IMapping<TInput, TOutput, TState> CreateInstance()
        {
            return new TableMapping<TInput, TOutput, TState>(rows);
        }

        public static MappingBuilder<TInput, TOutput, TState> CreateEmptyBuilder()
        {
            return new MappingBuilder<TInput, TOutput, TState>();
        }
    }
}
