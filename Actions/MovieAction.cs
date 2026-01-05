using DownloadCleaner.Common;
using System.IO;

namespace DownloadCleaner.Actions
{
    public class MovieAction : IFileAction
    {
        public void Execute(FileDTO dto)
        {
            string targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "動画"));
            FileUtility.SafeMoveFile(dto.FilePath, targetDir);
        }
    }
}