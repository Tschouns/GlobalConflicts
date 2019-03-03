using Base.RuntimeChecks;
using Services.Parser.Builder;

namespace Services.Parser.Rules
{
    internal class SidesOrNoSidesRule : IParserRule<IBuildConflict>
    {
        IParserRule<IBuildConflict> sidesDefinedFollowUpRule;
        IParserRule<IBuildConflict> noSidesDefinedFollowUpRule;

        public SidesOrNoSidesRule(
            IParserRule<IBuildConflict> sidesDefinedFollowUpRule,
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
            if (ParserHelper.ContainsNotInBrackets(textToParse, ParserHelper.Dash))
            {
                this.sidesDefinedFollowUpRule.Apply(textToParse, conflictBuilder);
            }
            else
            {
                this.noSidesDefinedFollowUpRule.Apply(textToParse, conflictBuilder);
            }
        }
    }
}
