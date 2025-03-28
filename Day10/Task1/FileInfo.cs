using System.Security.AccessControl;
using System.Security.Principal;

namespace Task1
{
    public class FileInfoProvider
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

        public void GetFileInfo(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    Console.WriteLine($"Размер: {fileInfo.Length} байт, Создан: {fileInfo.CreationTime}, Изменен: {fileInfo.LastWriteTime}");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения информации: {ex.Message}");
            }
        }

        public void CompareFileSizes(string filePath1, string filePath2)
        {
            try
            {
                FileInfo fileInfo1 = new FileInfo(filePath1);
                FileInfo fileInfo2 = new FileInfo(filePath2);

                if (!fileInfo1.Exists || !fileInfo2.Exists)
                {
                    Console.WriteLine("Один или оба файла не существуют.");
                    return;
                }

                if (fileInfo1.Length > fileInfo2.Length)
                {
                    Console.WriteLine($"'{Path.GetFileName(filePath1)}' больше.");
                }
                else if (fileInfo1.Length < fileInfo2.Length)
                {
                    Console.WriteLine($"'{Path.GetFileName(filePath2)}' больше.");
                }
                else
                {
                    Console.WriteLine("Файлы имеют одинаковый размер.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сравнения размеров: {ex.Message}");
            }
        }


        public void ListFiles(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Console.WriteLine("Список файлов:");
                    string[] files = Directory.GetFiles(directoryPath);
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
                else
                {
                    Console.WriteLine("Директория не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения списка файлов: {ex.Message}");
            }
        }

        public void DenyWriteToFile(string filePath)
        {

            Action attemptWrite = () => File.AppendAllText(filePath, "Попытка записи", System.Text.Encoding.UTF8);

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                FileSecurity fileSecurity = fileInfo.GetAccessControl();
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                FileSystemAccessRule accessRule = new FileSystemAccessRule(everyone, FileSystemRights.Write, AccessControlType.Deny);
                fileSecurity.AddAccessRule(accessRule);
                fileInfo.SetAccessControl(fileSecurity);
                TryExecute(() => attemptWrite(), "проверка прав после запрета");

                Console.WriteLine("Запись запрещена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запрета записи: {ex.Message}");
            }
        }

        public void CheckFileAccessRights(string filePath)
        {
            try
            {
                Console.WriteLine($"Проверка прав доступа к файлу '{filePath}':");
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        Console.WriteLine("Чтение: Доступно");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Чтение: Запрещено");
                }

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                    {
                        Console.WriteLine("Запись: Доступна");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Запись: Запрещено");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка проверки прав доступа: {ex.Message}");
            }
        }

        public void ReadAndDisplayFileContent(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"Содержимое:\n{File.ReadAllText(filePath)}");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }
        }
    }
}