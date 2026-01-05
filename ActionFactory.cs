using DownloadCleaner.Actions;

namespace DownloadCleaner
{
    public class ActionFactory
    {
        public static IFileAction GetAction(FileDTO dto)
        {
            return dto.Extension switch
            {
                "zip" => new ZipAction(),
                "pdf" => new PdfAction(),
                "jpg" or "jpeg" or "png" or "gif" or "bmp" or "webp" => new ImageAction(),
                "mp3" or "wav" or "aac" => new MusicAction(),
                "mp4" or "mov" or "avi" => new MovieAction(),
                "exe" => new ExeAction(),
                _ => new OtherAction()
            };
        }
    }
}