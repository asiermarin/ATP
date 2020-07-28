using solid.Common;
using solid.Common.LiskovSubtitution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Models.LiskovModels
{
    public class Fish : ISwim
    {
        void ILiskovSubtitution.SomethingThatEveryoneDo()
        {
            throw new NotImplementedException();
        }

        void ISwim.Swim()
        {
            throw new NotImplementedException();
        }
    }
}
