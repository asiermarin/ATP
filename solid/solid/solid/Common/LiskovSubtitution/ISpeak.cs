using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Common.LiskovSubtitution
{
    public interface ISpeak : ILiskovSubtitution
    {
         void Speak();
    }
}
