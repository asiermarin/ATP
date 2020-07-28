using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Common.LiskovSubtitution
{
    public interface IFly : ILiskovSubtitution
    {
        protected void Fly();
    }
}
