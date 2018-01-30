using System.Configuration;

namespace Framework.Utils
{
    public static class Config
    {
        public static string AppName => 
            ConfigurationManager.AppSettings["appName"];

        public static string AppPath =>
            ConfigurationManager.AppSettings["appPath"];

        public static string AppProperty(string propertyKey) =>
            ConfigurationManager.AppSettings[propertyKey];
    }
}
