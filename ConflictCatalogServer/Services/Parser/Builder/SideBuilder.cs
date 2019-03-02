using Base.RuntimeChecks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Parser.Builder
{
    internal class SideBuilder : IBuildSide
    {
        private readonly Side sideToBuild;

        public SideBuilder(Side side)
        {
            this.sideToBuild = side;
        }

        public void AddActor(string actorName)
        {
            Argument.AssertStringIsNotEmpty(actorName, nameof(actorName));

            this.sideToBuild.Actors.Add(actorName);
        }
    }
}
