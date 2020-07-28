using Local.Proyect.Core.Models;
using Microsoft.Extensions.Logging;
using solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Common
{
    interface ISingleResponsability<T> : IService<User>
    {
        // void CrateandLogType(ILoggerFactory logger);
        Task<CrudResult<T>> GetAsync();
        Task<CrudResult<T>> DeleteAsync();

        Task<CrudResult<T>> AddAsync(T value);
    }
}
