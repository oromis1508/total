using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Framework.Utils
{
    public static class ApplicationRunner
    {
        public static void RunApplication()
        {
            Instance = Application.Launch(Config.AppPath + Config.AppName);
            Assert.IsNotNull(Instance, $"file not found: {Config.AppName}");
        }

        public static Application Instance { get; private set; }

        internal static Window MainWindow(string windowName) => Instance.GetWindow(windowName);
    }
}
