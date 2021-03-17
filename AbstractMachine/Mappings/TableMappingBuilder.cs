using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class TableMappingBuilder<TInput, TOutput, TState>
    {
        private Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>> rows;

        public TableMappingBuilder()
        {
            rows = new Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>>();
        }

        public void AddRow(MappingData<TInput, TState> input, MappingData<TOutput, TState> output)
        {
            if (IsRowExist(input))
                throw new InvalidOperationException("This row already exist in table.");

            rows.Add(input, output);
        }

        public void RemoveRow(MappingData<TInput, TState> input)
        {
            if (!IsRowExist(input))
                throw new InvalidOperationException("This row does not exist in table.");

            rows.Remove(input);
        }

        public bool IsRowExist(MappingData<TInput, TState> input)
        {
            return rows.ContainsKey(input);
        }

        public Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>> Rows
        {
            get
            {
                return new Dictionary<MappingData<TInput, TState>, MappingData<TOutput, TState>>(rows);
            }
        }
    }
}
