namespace Task4
{
    public class FileWatcher
    {
        private readonly string _directoryPath;
        private readonly string _filter;
        private readonly FileSystemWatcher _watcher;

        public FileWatcher(string directoryPath, string filter)
        {
            _directoryPath = directoryPath;
            _filter = filter;

            _watcher = new FileSystemWatcher(_directoryPath, _filter);
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Changed += OnChanged;
            _watcher.Renamed += OnRenamed;
            _watcher.Error += OnError;

            _watcher.EnableRaisingEvents = true;
            _watcher.IncludeSubdirectories = false;

            Console.WriteLine($"Наблюдение за директорией: {_directoryPath} с фильтром: {_filter}");
            LogEvent($"Наблюдение за директорией: {_directoryPath} с фильтром: {_filter} запущено.");
        }

        // методы для обработки событий
        private void OnCreated(object source, FileSystemEventArgs e)
        {
            string message = $"Файл создан: {e.Name}";
            Console.WriteLine(message);
            SendEmailNotification(message);
            LogEvent(message);
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            string message = $"Файл удален: {e.Name}";
            Console.WriteLine(message);
            LogEvent(message);
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string message = $"Файл изменен: {e.Name}";
            Console.WriteLine(message);
            AnalyzeFile(e.FullPath);
            LogEvent(message);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            string message = $"Файл переименован: {e.OldName} в {e.Name}";
            Console.WriteLine(message);
            LogEvent(message);
        }

        private void OnError(object source, ErrorEventArgs e)
        {
            string message = $"Ошибка: {e.GetException().Message}";
            Console.WriteLine(message);
            LogEvent(message);
        }

        // доп действия
        private void SendEmailNotification(string message)
        {
            Console.WriteLine($"Отправка email-уведомления: {message}");
            LogEvent($"[EMAIL]: {message}");//отправляем сообщения в лог
        }

        private void LogEvent(string message)
        {
            string logFilePath = Path.Combine(_directoryPath, "filewatcher.log");
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в лог-файл: {ex.Message}");
            }
        }

        private void AnalyzeFile(string filePath)
        {
            try
            {
                int lineCount = File.ReadLines(filePath).Count();
                string message = $"Файл '{filePath}' содержит {lineCount} строк.";
                Console.WriteLine(message);
                LogEvent(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при анализе файла: {ex.Message}");
            }
        }

        public void StartWatching()
        {
            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}