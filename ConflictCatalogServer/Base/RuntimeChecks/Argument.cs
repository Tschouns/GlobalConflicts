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
    }
}
