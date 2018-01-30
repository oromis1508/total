using System.Diagnostics;

namespace Framework.Utils
{
    public static class ProcessUtil
    {
        public static void CloseApplication()
        {
            var runProcesses = Process.GetProcessesByName(Config.AppName.Split('.')[0]);
       
            if (runProcesses.Length != 0)
            {
                foreach (var process in runProcesses)
                {
                    process.Kill();
                }
            }
        }
    }
}
