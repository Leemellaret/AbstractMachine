using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    interface IBuilder<TBuildingObject> //TODO: нужен ли этот интерфейс?
    {
        TBuildingObject CreateInstance();
        IBuilder<TBuildingObject> Clone();
    }
}
