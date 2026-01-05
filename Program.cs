using System;
using System.Collections.Generic;
using System.IO;
using DownloadCleaner.Common;

namespace DownloadCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            string dlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string dsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _ = args;

            if (!Directory.Exists(dlPath)) return;

            var results = new Dictionary<string, int>();
            ErrorManager.ResetErrorCount();

            foreach (var filePath in Directory.GetFiles(dlPath))
            {
                var dto = new FileDTO(filePath, dsPath);
                if (dto.IsValid)
                {
                    IFileAction action = ActionFactory.GetAction(dto);
                    action.Execute(dto);

                    string name = action.GetType().Name;
                    results[name] = results.GetValueOrDefault(name) + 1;
                }
            }
            Console.WriteLine("完了しました。");
            Console.ReadLine();
        }
    }
}