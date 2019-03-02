using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Parser.Builder
{
    internal interface IBuildSide : IBuild
    {
        void AddActor(string actorName);
    }
}
