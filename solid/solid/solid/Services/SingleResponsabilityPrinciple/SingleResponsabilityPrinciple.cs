using Local.Proyect.Core.Models;
using Microsoft.Extensions.Logging;
using solid.Common;
using solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Services.SingleResponsabilityPrinciple
{
    public class SingleResponsabilityPrinciple : ISingleResponsability<User>
    {
        private ILoggerFactory _logger;
        private IConnection _connectionManager;
         public SingleResponsabilityPrinciple(ILoggerFactory logger, IConnection connectionManager)
        {
            _logger = logger;
            _connectionManager = connectionManager;
        }

        public Task<CrudResult<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CrudResult<User>> AddAsync(User newUser)
        {
            var userResgistry = new UserRegistry();
            var user = userResgistry.CreateUser(newUser);

            throw new NotImplementedException();

        }

        public Task<CrudResult<User>> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task CheckConnectionStarted()
        {
            throw new NotImplementedException();
        }
    }
}
