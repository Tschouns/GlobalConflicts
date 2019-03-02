
namespace Services.Parser.Builder
{
    internal interface IBuildConflict : IBuild
    {
        IBuildSide AddSide();
    }
}
