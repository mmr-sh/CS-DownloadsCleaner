using System;
using System.IO;

namespace DownloadCleaner
{
    public class FileDTO
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string Extension { get; private set; } = string.Empty;
        public DateTime LastModified { get; private set; }
        public string DestDesktopPath { get; private set; }
        public bool IsValid { get; private set; }
        public long FileSize { get; private set; } // 未使用。拡張用

        public FileDTO(string filePath, string destPath)
        {
            var info = new FileInfo(filePath);
            FileName = info.Name;
            FilePath = info.FullName;
            FileSize = info.Length;

            // 1. ベースとなる整理フォルダ名
            string rootFolderName = "ダウンロード整理";

            // 2. その下の実行日フォルダ名 (例: 20240520)
            string dateFolderName = DateTime.Now.ToString("yyyyMMdd");

            // 3. Path.Combine で階層を組み立て
            // デスクトップ \ ダウンロード整理 \ 20250105 といったパスになる
            DestDesktopPath = Path.Combine(destPath, rootFolderName, dateFolderName);

            if (FileName.StartsWith("~$"))
            {
                IsValid = false;
                return;
            }

            Extension = info.Extension.TrimStart('.').ToLower();
            LastModified = info.LastWriteTime;
            IsValid = true;
        }
    }
}