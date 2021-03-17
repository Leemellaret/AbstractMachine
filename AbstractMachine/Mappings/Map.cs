using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class Map<TInput, TOutput, TState>
    {
        public TInput InputValue { get; set; }
        public TState InputState { get; set; }
        public TOutput OutputValue { get; set; }
        public TState OutputState { get; set; }
    }
}
