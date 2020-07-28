using solid.Common;
using solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Services.OpenClosePrinciple
{
    public class Rectangle : IOpenClose<Entity>
    {
        public double CalcularArea(Entity entity)
        {
            return entity.Height * entity.Width;
        }
    }
}
