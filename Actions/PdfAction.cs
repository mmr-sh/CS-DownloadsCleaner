using DownloadCleaner.Common;
using System.IO;

namespace DownloadCleaner.Actions
{
    public class PdfAction : IFileAction
    {
        public void Execute(FileDTO dto)
        {
            string targetDir;
            if (dto.LastModified < DateTime.Now.AddDays(-30))
            {
                targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "削除予定"));
            }
            else
            {
                targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "pdf"));
            }
            FileUtility.SafeMoveFile(dto.FilePath, targetDir);
        }
    }
}