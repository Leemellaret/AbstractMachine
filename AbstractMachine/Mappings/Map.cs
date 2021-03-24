using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class Map<TInput, TOutput, TState>//TODO: нужно ли здесь, чтобы типы-параметры реализовывали IValue?
        where TInput : IValue<TInput>
        where TOutput : IValue<TOutput>
        where TState : IValue<TState>
    {
        public TInput InputValue { get; set; }
        public TState InputState { get; set; }
        public TOutput OutputValue { get; set; }
        public TState OutputState { get; set; }
    }
}
