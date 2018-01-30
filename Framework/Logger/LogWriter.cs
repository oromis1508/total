using NLog;

namespace Framework.Logger
{
    public static class LogWriter
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        public static void AddLog(string message, LogType logType = LogType.Info)
        {
            Logger.Log(LogLevel.FromString(logType.ToString()), message);
        }
    }
}
