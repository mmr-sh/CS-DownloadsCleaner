using DownloadCleaner.Common;
using System.IO;

namespace DownloadCleaner.Actions
{
    public class MusicAction : IFileAction
    {
        public void Execute(FileDTO dto)
        {
            string targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "音楽"));
            FileUtility.SafeMoveFile(dto.FilePath, targetDir);
        }
    }
}