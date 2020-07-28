using Microsoft.Extensions.Logging;
using solid.Common.LiskovSubtitution;
using solid.Models.LiskovModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Services
{
    public class LiskovSubstitutionPrinciple
    {
        private ILoggerFactory _logger;
        public LiskovSubstitutionPrinciple(ILoggerFactory logger)
        {
            _logger = logger;
        }

        public void CreateInstances()
        {
            ISpeak human = new Human();
            human.Speak();

            IFly human2 = new Human();
            // human2.Fly();
        }
    }
}
