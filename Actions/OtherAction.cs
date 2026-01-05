using DownloadCleaner.Common;
using System.IO;

namespace DownloadCleaner.Actions
{
    public class OtherAction : IFileAction
    {
        public void Execute(FileDTO dto)
        {
            string targetDir;
            if (dto.LastModified < DateTime.Now.AddDays(-10))
            {
                targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "削除予定"));
            }
            else
            {
                targetDir = FileUtility.GetOrCreateFolder(Path.Combine(dto.DestDesktopPath, "その他ファイル"));
            }
            FileUtility.SafeMoveFile(dto.FilePath, targetDir);
        }
    }
}