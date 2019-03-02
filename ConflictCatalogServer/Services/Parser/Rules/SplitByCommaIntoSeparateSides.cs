using Base.RuntimeChecks;
using Services.Parser.Builder;

namespace Services.Parser.Rules
{
    internal class SplitByCommaIntoSeparateSides : IParserRule<IBuildConflict>
    {
        private readonly IParserRule<IBuildSide> followUpRule;

        public SplitByCommaIntoSeparateSides(IParserRule<IBuildSide> followUpRule)
        {
            Argument.AssertIsNotNull(followUpRule, nameof(followUpRule));

            this.followUpRule = followUpRule;
        }

        public void Apply(string textToParse, IBuildConflict conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            var sideStrings = textToParse.Split(',');
            foreach (var sideString in sideStrings)
            {
                this.followUpRule.Apply(sideString, conflictBuilder.AddSide());
            }
        }
    }
}
