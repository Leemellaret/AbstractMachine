﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    public interface IDomain<T> : IEnumerable<T>
        where T : IValue<T>
    {
        bool Contains(T value);
    }
}
