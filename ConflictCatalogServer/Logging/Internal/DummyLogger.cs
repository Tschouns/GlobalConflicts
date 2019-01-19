using Base.RuntimeChecks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Internal
{
    class DummyLogger : ILog
    {
        public void Info(string message)
        {
            // Does nothing.
        }

        public void Warning(string message)
        {
            // Does nothing.
        }

        public void Error(string message)
        {
            // Does nothing.
        }

        public void Error(Exception exception)
        {
            Argument.AssertIsNotNull(exception, nameof(exception));

            // Does nothing.
        }
    }
}
