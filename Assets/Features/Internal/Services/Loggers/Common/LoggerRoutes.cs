using Internal.Common;

namespace Internal.Services.Loggers.Common
{
    public static class LoggerRoutes
    {
        public const string ServicePath = InternalRoutes.Root + "Logger/Service";
        public const string ServiceName = "Logger";

        public const string HeaderName = "LoggerHeader_";
        public const string HeaderPath = InternalRoutes.Root + "Logger/Header";
    }
}