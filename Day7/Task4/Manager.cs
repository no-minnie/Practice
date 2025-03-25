namespace FileWatcherTask;
    public class FileChangeManager
    {
        private FileWatcher _watcher;
        private FileMonitor _monitor;
        private BackupService _backupService;
        private Logger _logger;

        public FileChangeManager(FileWatcher watcher, FileMonitor monitor, BackupService backupService, Logger logger)
        {
            _watcher = watcher;
            _monitor = monitor;
            _backupService = backupService;
            _logger = logger;

            // подписываем обработчики на событие FileChanged
            _watcher.FileChanged += _monitor.OnFileChanged;
            _watcher.FileChanged += _backupService.CreateBackup;
            _watcher.FileChanged += _logger.LogChange;
        }
    }
