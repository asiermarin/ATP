using solid.Common;
using solid.Common.LiskovSubtitution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Models.LiskovModels
{
    public class Bird : IFly
    {
        void IFly.Fly()
        {
            throw new NotImplementedException();
        }

        void ILiskovSubtitution.SomethingThatEveryoneDo()
        {
            throw new NotImplementedException();
        }
    }
}
