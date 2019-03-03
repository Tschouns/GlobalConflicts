using Base.RuntimeChecks;
using Services.Parser.Builder;
using System.Linq;

namespace Services.Parser.Rules
{
    internal class SplitByCommaIntoActors : IParserRule<IBuildSide>
    {
        public void Apply(string textToParse, IBuildSide conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            var actorStrings = ParserHelper.SplitByCharacterNotInBrackets(textToParse, ParserHelper.Comma)
                .Select(s => s.Trim().Trim('(', ')'))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Where(s => s.Length > 1)
                .ToList();

            foreach (var actorName in actorStrings)
            {
                var location = actorName;

                if (actorName.Contains('('))
                {
                    location = actorName.Substring(0, actorName.IndexOf('(')).Trim();
                }

                conflictBuilder.AddActor(actorName, location);
            }
        }
    }
}
