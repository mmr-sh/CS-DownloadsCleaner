using DownloadCleaner.Common;
using System.IO;

namespace DownloadCleaner.Actions
{
    public class ZipAction : IFileAction
    {
        public void Execute(FileDTO dto)
        {
            string targetDir;
            if (dto.LastModified < DateTime.Now.AddDays(-7))
            {
                targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "削除予定"));
            }
            else
            {
                targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "zip"));
            }
            FileUtility.SafeMoveFile(dto.FilePath, targetDir);
        }
    }
}