using solid.Common;
using solid.Common.LiskovSubtitution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Models.LiskovModels
{
    public class Human : ISpeak, ISwim, IFly
    {
        void IFly.Fly()
        {
            throw new NotImplementedException();
        }

        void ISpeak.Speak()
        {
            throw new NotImplementedException();
        }

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
