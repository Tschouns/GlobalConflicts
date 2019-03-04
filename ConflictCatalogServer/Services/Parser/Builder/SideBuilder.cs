using Base.RuntimeChecks;
using Services.ConflictStructure;

namespace Services.Parser.Builder
{
    internal class SideBuilder : IBuildSide
    {
        private readonly SideData sideToBuild;

        public SideBuilder(SideData side)
        {
            this.sideToBuild = side;
        }

        public void AddActor(string fullName, string location)
        {
            Argument.AssertStringIsNotEmpty(fullName, nameof(fullName));
            Argument.AssertStringIsNotEmpty(location, nameof(location));

            var actor = new ActorData
            {
                FullName = fullName,
                Location = location
            };
            this.sideToBuild.Actors.Add(actor);
        }
    }
}
