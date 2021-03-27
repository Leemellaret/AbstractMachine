using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IAbstractMachine<TInput, TOutput, TState>
    {
        TState CurrentState { get; }
        TOutput Process(TInput input);
    }
}
