using System;
using System.IO;

namespace DownloadCleaner.Common
{
    public static class FileUtility
    {
        public static string GetOrCreateFolder(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

        public static void SafeMoveFile(string srcPath, string destDir)
        {
            string fileName = Path.GetFileName(srcPath);
            string baseName = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            string targetPath = Path.Combine(destDir, fileName);

            if (!File.Exists(targetPath)) { File.Move(srcPath, targetPath); return; }

            string dateStr = "_" + DateTime.Now.ToString("yyyyMMdd");
            targetPath = Path.Combine(destDir, baseName + dateStr + ext);
            if (!File.Exists(targetPath)) { File.Move(srcPath, targetPath); return; }

            for (int n = 2; n <= 99; n++)
            {
                targetPath = Path.Combine(destDir, $"{baseName}{dateStr}({n}){ext}");
                if (!File.Exists(targetPath)) { File.Move(srcPath, targetPath); return; }
            }

            ErrorManager.ReportError(AppErrorCode.ErrCollisionLimitReached, fileName);
        }
    }
}