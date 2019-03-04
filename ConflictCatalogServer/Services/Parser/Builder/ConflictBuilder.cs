using Base.RuntimeChecks;
using Services.ConflictStructure;
using System;

namespace Services.Parser.Builder
{
    internal class ConflictBuilder : IBuildConflict
    {
        private readonly ConflictData conflictToBuild = new ConflictData();

        public IBuildSide AddSide()
        {
            var newSide = new SideData();
            this.conflictToBuild.Sides.Add(newSide);
            return new SideBuilder(newSide);
        }

        public ConflictData GetConflict()
        {
            return this.conflictToBuild;
        }
    }
}
