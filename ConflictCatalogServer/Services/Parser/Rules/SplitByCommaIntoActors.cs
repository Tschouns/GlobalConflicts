using Base.RuntimeChecks;
using Services.Parser.Builder;
using System;
using System.Linq;

namespace Services.Parser.Rules
{
    internal class SplitByCommaIntoActors : IParserRule<IBuildSide>
    {
        public void Apply(string textToParse, IBuildSide conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            var actorStrings = textToParse
                .Split(',')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            foreach (var actorName in actorStrings)
            {
                conflictBuilder.AddActor(actorName);
            }
        }
    }
}
