using FileWatcherTask;
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/37529/Desktop/практика C#/Новик_06/test.txt");

            if (!File.Exists(filePath))
            {
                File.CreateText(filePath).Close();
            }

            // созд экземпляры классов
            FileWatcher watcher = new FileWatcher(filePath);
            FileMonitor monitor = new FileMonitor();
            BackupService backupService = new BackupService();
            Logger logger = new Logger();

            // созд FileChangeManager и подписываем обработчики
            FileChangeManager manager = new FileChangeManager(watcher, monitor, backupService, logger);

            Console.WriteLine("Начинаем отслеживание изменений в файле test.txt.");
            Console.WriteLine("Измените файл, чтобы увидеть результат.");
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();

            watcher.StopWatching();
        }
    }
