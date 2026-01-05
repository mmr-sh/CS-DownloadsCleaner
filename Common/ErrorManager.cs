using System;

namespace DownloadCleaner.Common
{
    public enum AppErrorCode { ErrNone, ErrCollisionLimitReached }

    public static class ErrorManager
    {
        private static int _errorCount;
        public static void ResetErrorCount() => _errorCount = 0;

        public static bool ReportError(AppErrorCode code, string detail)
        {
            _errorCount++;
            if (code == AppErrorCode.ErrCollisionLimitReached)
                Console.WriteLine($"[Skip] 上限到達: {detail}");

            if (_errorCount >= 10)
            {
                Console.WriteLine("エラー過多のため中断します。");
                Environment.Exit(1);
            }
            return false;
        }
    }
}