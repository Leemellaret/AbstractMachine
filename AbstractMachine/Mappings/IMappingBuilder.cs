using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IMappingBuilder<TInput, TOutput, TState>
    {
        IMappingBuilder<TInput, TOutput, TState> AddRow(MappingData<TInput, TState> input, MappingData<TOutput, TState> output);
        IMappingBuilder<TInput, TOutput, TState> RemoveRow(MappingData<TInput, TState> input);
        bool IsRowExist(MappingData<TInput, TState> input);
        IMapping<TInput, TOutput, TState> CreateInstance();
    }
}
