using Base.RuntimeChecks;
using Services.Parser.Builder;

namespace Services.Parser.Rules
{
    internal class RemoveBracketsRule : IParserRule<IBuildConflict>
    {
        private readonly IParserRule<IBuildConflict> followUpRule;

        public RemoveBracketsRule(IParserRule<IBuildConflict> followUpRule)
        {
            Argument.AssertIsNotNull(followUpRule, nameof(followUpRule));

            this.followUpRule = followUpRule;
        }

        public void Apply(string textToParse, IBuildConflict conflictBuilder)
        {
            Argument.AssertStringIsNotEmpty(textToParse, nameof(textToParse));
            Argument.AssertIsNotNull(conflictBuilder, nameof(conflictBuilder));

            var resultingText = RemoveAllBracketsRecursive(textToParse);

            if (!string.IsNullOrEmpty(resultingText))
            {
                this.followUpRule.Apply(resultingText, conflictBuilder);
            }
        }

        private static string RemoveAllBracketsRecursive(string text)
        {
            // Exit conditions.
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (!text.Contains('(') || !text.Contains(')'))
            {
                return text;
            }

            // Remove first occurring bracket block.
            var openingBracketPos = text.IndexOf('(');
            var closingBracketPos = text.IndexOf(')');

            var resultingText = text.Remove(openingBracketPos, closingBracketPos - openingBracketPos + 1);

            // Recursive call.
            return RemoveAllBracketsRecursive(resultingText);
        }
    }
}
