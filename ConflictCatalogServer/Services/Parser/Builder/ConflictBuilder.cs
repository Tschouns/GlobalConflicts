using Base.RuntimeChecks;
using System;

namespace Services.Parser.Builder
{
    internal class ConflictBuilder : IBuildConflict
    {
        private readonly Conflict conflictToBuild = new Conflict();

        public IBuildSide AddSide()
        {
            var newSide = new Side();
            this.conflictToBuild.Sides.Add(newSide);
            return new SideBuilder(newSide);
        }

        public Conflict GetConflict()
        {
            return this.conflictToBuild;
        }
    }
}
