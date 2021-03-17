using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public class MappingData<TData, TState>
    {
        public TData Data { get; }
        public TState State { get; }

        public MappingData(TData data, TState state)
        {
            Data = data;
            State = state;
        }

        public static implicit operator MappingData<TData, TState>((TData Data, TState State) tuple)
        {
            return new MappingData<TData, TState>(tuple.Data, tuple.State);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!GetType().Equals(obj.GetType()))
                return false;

            var cObj = (MappingData<TData, TState>)obj;
            return Data.Equals(cObj.Data) && State.Equals(cObj.State);
        }

        public override int GetHashCode()
        {
            return (Data, State).GetHashCode();
        }
    }
}
