using System;
using System.IO;

namespace Framework.Utils
{
    public static class FileUtil
    {
        private static DateTime _timeOfFileChange;
        private static DirectoryInfo _dirInfo;

        public static DateTime GetDateTimeChange(string filePath = null)
        {
            if (filePath != null)
            {
                _timeOfFileChange = File.GetLastWriteTime(filePath);
            }

            return _timeOfFileChange;
        }

        public static void CreateFolder(string folderPath)
        {
            _dirInfo = new DirectoryInfo(folderPath);
            if (!_dirInfo.Exists)
            {
                _dirInfo.Create();
            }
        }

        public static void DeleteFolder(string folderPath)
        {
            _dirInfo = new DirectoryInfo(folderPath);
            if (_dirInfo.Exists)
            {
                _dirInfo.Delete(true);
            }
        }

        public static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static bool IsFileExist(string filePath) => File.Exists(filePath);
    }
}
