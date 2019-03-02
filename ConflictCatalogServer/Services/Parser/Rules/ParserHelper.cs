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

            var depth = 0;
            var lowestDepth = 0;

            var foundFirst = -1;
            var foundAtDepth = 0;

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    depth++;
                }

                if (text[i] == ')')
                {
                    depth--;
                }

                if (depth < lowestDepth)
                {
                    lowestDepth = depth;
                }

                // check for first occurence, or occurrence at a lower indent level.
                if (text[i] == character &&
                    (foundFirst < 0 || depth < foundAtDepth))
                {
                    foundFirst = i;
                    foundAtDepth = depth;
                }
            }

            // Was the character found within brackets?
            if (foundAtDepth > lowestDepth)
            {
                return -1;
            }

            return foundFirst;
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
