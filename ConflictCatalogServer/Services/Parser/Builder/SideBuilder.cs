using Base.RuntimeChecks;
using Services.ConflictStructureModels;

namespace Services.Parser.Builder
{
    internal class SideBuilder : IBuildSide
    {
        private readonly Side sideToBuild;

        public SideBuilder(Side side)
        {
            this.sideToBuild = side;
        }

        public void AddActor(string fullName, string location)
        {
            Argument.AssertStringIsNotEmpty(fullName, nameof(fullName));
            Argument.AssertStringIsNotEmpty(location, nameof(location));

            var actor = new Actor
            {
                FullName = fullName,
                Location = location
            };
            this.sideToBuild.Actors.Add(actor);
        }
    }
}
