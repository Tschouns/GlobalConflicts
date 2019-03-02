
namespace Services.Parser.Builder
{
    internal interface IBuildSide : IBuild
    {
        void AddActor(string fullName, string location);
    }
}
