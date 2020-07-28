using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Common
{
    public interface IOpenClose<T>
    {
        double CalcularArea(T value);
    }
}
