using Services.Parser.Builder;
using System.Collections.Generic;

namespace Services.Parser.Rules
{
    internal interface IParserRule<in TBuilder>
        where TBuilder : class, IBuild
    {
        void Apply(IEnumerable<string> stringsToParse, TBuilder conflictBuilder);
    }
}
