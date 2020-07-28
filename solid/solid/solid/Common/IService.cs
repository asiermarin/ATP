using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Common
{
    interface IService<T>
    {
        Task CheckConnectionStarted();
    }
}
