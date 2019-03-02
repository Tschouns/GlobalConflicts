using Services.Parser.Builder;

namespace Services.Parser.Rules
{
    internal interface IParserRule<in TBuilder>
        where TBuilder : class, IBuild
    {
        void Apply(string textToParse, TBuilder conflictBuilder);
    }
}
