using Microsoft.Extensions.Logging;
using solid.Common;
using solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Services.OpenClosePrinciple
{
    public class OpenClosePrinciple 
    {
        private ILoggerFactory _logger;
        private IOpenClose<Entity> _openCloseEntity;
        public OpenClosePrinciple(ILoggerFactory logger, IOpenClose<Entity> openCloseRectangle, Entity entity)
        {
            _logger = logger;
            _openCloseEntity = openCloseRectangle;

            ComputarArea(openCloseRectangle, entity);
        }

        public void ComputarArea(IOpenClose<Entity> openCloseRectangle, Entity entity)
        {
            double area = openCloseRectangle.CalcularArea(entity);
        }

    }
}
