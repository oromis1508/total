using Framework.Logger;
using Framework.Utils;
using TestStack.White.UIItems.WindowItems;

namespace Framework.BaseClasses
{
    public class BaseWindow
    {
        public static Window Window { get; set; }

        public BaseWindow(Window window)
        {
            Window = window;
        }

        protected internal static Window GetWindow(string windowName)
        {
            try
            {
                var window = ApplicationRunner.MainWindow(windowName);
                LogWriter.AddLog($"{windowName} window founded");
                return window;
            }
            catch
            {
                LogWriter.AddLog($"{windowName} window not found", LogType.Error);
                return null;
            }
        }

        protected internal static void WaitWhileWindowBusy()
        {
            Window.WaitWhileBusy();
        }

        protected internal static void GetModalWindow(string windowName)
        {
            try
            {
                Window = Window.ModalWindow(windowName);
                LogWriter.AddLog($"{windowName} modal window founded");
            }
            catch
            {
                Window = null;
                LogWriter.AddLog($"{windowName} modal window not found", LogType.Error);
            }
        }

        public bool IsWindowExist => Window != null;
    }
}
