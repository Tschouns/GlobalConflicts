using Base.RuntimeChecks;
using Services.Parser.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Parser.Rules
{
    internal class RemoveNumericBlocksAtTheEndRule : IParserRule<IBuildConflict>
    {
        private readonly IParserRule<IBuildConflict> followUpRule;

        public RemoveNumericBlocksAtTheEndRule(IParserRule<IBuildConflict> followUpRule)
        {
            Argument.AssertIsNotNull(followUpRule, nameof(followUpRule));

            this.followUpRule = followUpRule;
        }

        public void Apply(string textToParse, IBuildConflict conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            var newText = textToParse;
            var blocks = ParserHelper.SplitByCharacterNotInBrackets(textToParse, ParserHelper.Comma);
            var lastBlock = blocks.Last();

            // Remove the special characters, and split by '-'. If the remaining strings are number, remove the block.
            var textBlock = lastBlock.TrimEnd(ParserHelper.SpecialCharacters);
            if (textBlock.Split(ParserHelper.Dash).All(t => int.TryParse(t, out int i)))
            {
                newText = textToParse
                    .Substring(0, textToParse.Length - lastBlock.Length)
                    .TrimEnd()
                    .TrimEnd(ParserHelper.Comma);
            }

            this.followUpRule.Apply(newText, conflictBuilder);
        }
    }
}