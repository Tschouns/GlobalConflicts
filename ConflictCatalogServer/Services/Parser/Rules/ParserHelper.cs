using Base.RuntimeChecks;
using System.Collections.Generic;

namespace Services.Parser.Rules
{
    internal static class ParserHelper
    {
        public static IEnumerable<string> SplitByCharacterNotInBrackets(string text, char character)
        {
            Argument.AssertIsNotNull(text, nameof(text));

            // Eliminate special cases, where the split char is either the very first or very last character in the string.
            text = text.Trim(character);

            // Exit condition.
            if (!ContainsNotInBrackets(text, character))
            {
                return new[] { text };
            }

            // Split.
            var splitCharacterPosition = IndexOfNotInBrackets(text, character);

            var subStrings = new List<string>();

            var firstPart = text.Substring(0, splitCharacterPosition);
            subStrings.Add(firstPart);

            // Recursive call.
            var secondPart = text.Substring(splitCharacterPosition + 1);
            var restOfSubstrings = SplitByCharacterNotInBrackets(secondPart, character);

            subStrings.AddRange(restOfSubstrings);

            return subStrings;
        }

        public static bool ContainsNotInBrackets(string text, char character)
        {
            var index = IndexOfNotInBrackets(text, character);

            return index >= 0;
        }

        public static int IndexOfNotInBrackets(string text, char character)
        {
            Argument.AssertIsNotNull(text, nameof(text));

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == character && !IsWithinBrackets(text, i))
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool IsWithinBrackets(string text, int pos)
        {
            Argument.AssertIsNotNull(text, nameof(text));

            if (pos < 0 || pos >= text.Length)
            {
                return false;
            }

            if (!text.Contains('(') || !text.Contains(')'))
            {
                return false;
            }

            return
                pos > text.IndexOf('(') &&
                pos < text.LastIndexOf(')');
        }
    }
}
