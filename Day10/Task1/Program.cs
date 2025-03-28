using Task1;
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            FileInfoProvider fileInfoProvider = new FileInfoProvider();

            string familyName = "ivanov";
            string initials = "ii";
            string filePath = $"{familyName}.{initials}";
            string copiedFilePath = "example_copy.txt";
            string movedDirectoryPath = "moved_files";
            string renamedFilePath = "sidorov.pp";
            string searchPattern = "*.txt";
            string tempDir = "temp_dir";

            // 1. Создать файл, записать в него текст, прочитать и вывести в консоль.
            fileManager.CreateAndWriteToFile(filePath, "Привет, мир! Это пример записи в файл.");
            fileInfoProvider.ReadAndDisplayFileContent(filePath);

            // 2. Проверить существование файла перед его удалением.
            fileManager.DeleteFileIfExists(filePath);

            // 3. Получить информацию о файле (размер, даты).
            fileManager.CreateAndWriteToFile(filePath, "Этот файл будет использоваться для получения информации.");
            fileInfoProvider.GetFileInfo(filePath);

            // 4. Скопировать файл и убедиться, что копия существует.
            fileManager.CopyFile(filePath, copiedFilePath);
            //Console.WriteLine($"Копия файла существует: {fileInfoProvider.CheckFileExists(copiedFilePath)}");

            // 5. Переместить файл в новую директорию.
            fileManager.MoveFile(copiedFilePath, movedDirectoryPath);

            // 6. Переименовать файл в файл familiya.io
            string movedFilePath = Path.Combine(movedDirectoryPath, Path.GetFileName(copiedFilePath));
            fileManager.RenameFile(movedFilePath, renamedFilePath);

            // 7. Обработать ошибку при удалении несуществующего файла.
            fileManager.DeleteFileIfExists("nonexistent_file.txt");

            // 8. Сравнить два файла по размеру.
            fileManager.CreateAndWriteToFile("file1.txt", "AAA");
            fileManager.CreateAndWriteToFile("file2.txt", "AAAAA");
            fileInfoProvider.CompareFileSizes("file1.txt", "file2.txt");
            fileManager.DeleteFileIfExists("file1.txt");
            fileManager.DeleteFileIfExists("file2.txt");

            // 9. Удалить все файлы в папке, соответствующие определенному шаблону. С расширением ii (см. выше)
            Directory.CreateDirectory(tempDir);
            fileManager.CreateAndWriteToFile(Path.Combine(tempDir, "file1.txt"), "test");
            fileManager.CreateAndWriteToFile(Path.Combine(tempDir, "file2.txt"), "test");
            fileManager.CreateAndWriteToFile(Path.Combine(tempDir, "ivanov.ii"), "test");
            fileManager.DeleteFilesByPattern(tempDir, searchPattern); // Remove .txt
            fileManager.DeleteFileIfExists(Path.Combine(tempDir, "ivanov.ii")); // Then remove ii
            Directory.Delete(tempDir, true);

            // 10. Вывести список всех файлов в заданной директории.
            fileInfoProvider.ListFiles(Directory.GetCurrentDirectory());

            // 11. Запретить запись в файл и попытаться записать в него.
            fileManager.CreateAndWriteToFile(filePath, "Этот файл будет использоваться для проверки прав доступа.");
            fileInfoProvider.DenyWriteToFile(filePath);

            // 12. Проверить доступные права к файлу (чтение, запись, выполнение).
            fileInfoProvider.CheckFileAccessRights(filePath);
            // Clean up : Delete file after all operations
            fileManager.DeleteFileIfExists(filePath);

            string renamedFullpath = Path.Combine(movedDirectoryPath, renamedFilePath);
            fileManager.DeleteFileIfExists(renamedFullpath);

            if (Directory.Exists(movedDirectoryPath))
            {
                Directory.Delete(movedDirectoryPath);
            }

            Console.WriteLine("Программа завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
