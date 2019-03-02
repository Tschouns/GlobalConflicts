using System;
using System.Collections.Generic;
using System.Linq;
using Base.RuntimeChecks;
using Services.Parser.Builder;

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

        public void Apply(IEnumerable<string> stringsToParse, IBuildConflict conflictBuilder)
        {
            Argument.AssertIsNotNull(stringsToParse, nameof(stringsToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            // No explicitly defined sides?
            if (stringsToParse.Any(s => !s.Contains('-')))
            {
                this.noSidesDefinedFollowUpRule.Apply(stringsToParse, conflictBuilder);
                return;
            }

            // Split, and process each side.
            var sideStrings = stringsToParse.SelectMany(s => s.Split('-')).ToList();
            foreach(var s in sideStrings)
            {
                this.sidesDefinedFollowUpRule.Apply(new[] { s }, conflictBuilder.AddSide());
            }
        }
    }
}
