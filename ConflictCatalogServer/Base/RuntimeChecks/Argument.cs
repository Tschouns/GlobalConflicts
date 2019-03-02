using System;

namespace Base.RuntimeChecks
{
    public static class Argument
    {
        public static void AssertIsNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void AssertStringIsNotEmpty(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException("The specified string argument is empty.", argumentName);
            }
        }
    }
}
