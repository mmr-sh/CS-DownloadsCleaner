using DownloadCleaner.Common;
using System.IO;

namespace DownloadCleaner.Actions
{
    public class ImageAction : IFileAction
    {
        public void Execute(FileDTO dto)
        {
            string targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "画像"));
            FileUtility.SafeMoveFile(dto.FilePath, targetDir);
        }
    }
}