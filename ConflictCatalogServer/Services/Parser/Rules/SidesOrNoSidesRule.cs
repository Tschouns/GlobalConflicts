using Base.RuntimeChecks;
using Services.Parser.Builder;
using System.Linq;

namespace Services.Parser.Rules
{
    internal class SidesOrNoSidesRule : IParserRule<IBuildConflict>
    {
        IParserRule<IBuildSide> sidesDefinedFollowUpRule;
        IParserRule<IBuildConflict> noSidesDefinedFollowUpRule;

        public SidesOrNoSidesRule(
            IParserRule<IBuildSide> sidesDefinedFollowUpRule,
            IParserRule<IBuildConflict> noSidesDefinedFollowUpRule)
        {
            this.sidesDefinedFollowUpRule = sidesDefinedFollowUpRule;
            this.noSidesDefinedFollowUpRule = noSidesDefinedFollowUpRule;
        }

        public void Apply(string textToParse, IBuildConflict conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            // No explicitly defined sides?
            if (!textToParse.Contains('-'))
            {
                this.noSidesDefinedFollowUpRule.Apply(textToParse, conflictBuilder);
                return;
            }

            // Split, and process each side.
            var sideStrings = textToParse
                .Split('-')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            foreach(var s in sideStrings)
            {
                this.sidesDefinedFollowUpRule.Apply(s, conflictBuilder.AddSide());
            }
        }
    }
}
