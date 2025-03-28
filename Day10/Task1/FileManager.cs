using System.Diagnostics;

namespace Task1
{
    public class FileManager
    {
        private void TryExecute(Action action, string operationDescription)
        {
            try
            {
                action();
                Console.WriteLine($"Выполнено: {operationDescription}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {operationDescription}: {ex.Message}");
            }
        }

        public void CreateAndWriteToFile(string filePath, string content)
        {
            TryExecute(() => File.WriteAllText(filePath, content), $"создание/запись {filePath}");
        }

        public void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                TryExecute(() => File.Delete(filePath), $"удаление {filePath}");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }

        public void CopyFile(string sourceFilePath, string destinationFilePath)
        {
            TryExecute(() => File.Copy(sourceFilePath, destinationFilePath, true), $"копирование в {destinationFilePath}");
        }

        public void MoveFile(string sourceFilePath, string destinationDirectoryPath)
        {
            TryExecute(() =>
            {
                Directory.CreateDirectory(destinationDirectoryPath);
                File.Move(sourceFilePath, Path.Combine(destinationDirectoryPath, Path.GetFileName(sourceFilePath)));
            }, $"перемещение в {destinationDirectoryPath}");
        }

        public void RenameFile(string filePath, string newFileName)
        {
            TryExecute(() => File.Move(filePath, Path.Combine(Path.GetDirectoryName(filePath), newFileName)), $"переименование {filePath}");
        }

        public void DeleteFilesByPattern(string directoryPath, string searchPattern)
        {
            try
            {
                string[] files = Directory.GetFiles(directoryPath, searchPattern);
                foreach (string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine($"Удален: {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка удаления по шаблону: {ex.Message}");
            }
        }

        public void ViewFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                TryExecute(
                () => Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true }),
               $"открытие {filePath}"
               );
            }

            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
    }
}