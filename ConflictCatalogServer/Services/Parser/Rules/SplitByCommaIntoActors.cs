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
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Where(s => s.Length > 1)
                .ToList();

            foreach (var a in actorStrings)
            {
                var actor = a;

                // Special case: the whole thing is in brackets...
                if (a.First() == '(' && a.Last() == ')')
                {
                    actor = a.Trim('(', ')');
                }

                var location = actor;

                if (actor.Contains('('))
                {
                    location = actor.Substring(0, actor.IndexOf('(')).Trim();
                }

                conflictBuilder.AddActor(actor, location);
            }
        }
    }
}
