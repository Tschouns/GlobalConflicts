using Base.RuntimeChecks;
using Services.Parser.Builder;
using System.Linq;

namespace Services.Parser.Rules
{
    internal class SplitByDashIntoSeparateSides : IParserRule<IBuildConflict>
    {
        private readonly IParserRule<IBuildSide> followUpRule;

        public SplitByDashIntoSeparateSides(IParserRule<IBuildSide> followUpRule)
        {
            Argument.AssertIsNotNull(followUpRule, nameof(followUpRule));

            this.followUpRule = followUpRule;
        }

        public void Apply(string textToParse, IBuildConflict conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            var sideStrings = ParserHelper.SplitByCharacterNotInBrackets(textToParse, ParserHelper.Dash)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            foreach (var sideString in sideStrings)
            {
                this.followUpRule.Apply(sideString, conflictBuilder.AddSide());
            }
        }
    }
}
