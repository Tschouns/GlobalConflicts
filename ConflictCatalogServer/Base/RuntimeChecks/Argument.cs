using System;

namespace Base.RuntimeChecks
{
    public static class Argument
    {
        public static void AssertIsNotNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
