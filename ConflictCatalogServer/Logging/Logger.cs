using Base.RuntimeChecks;
using Logging.Internal;

namespace Logging
{
    public static class Logger
    {
        private static ILog _log = new DummyLogger();

        public static ILog Log { get; private set; }

        public static void SetLogger(ILog logger)
        {
            Argument.AssertIsNotNull(logger, nameof(logger));

            Log = logger;
        }
    }
}
