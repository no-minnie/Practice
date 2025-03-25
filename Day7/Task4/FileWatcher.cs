namespace FileWatcherTask
{
    public class FileWatcher
    {
        public event EventHandler FileChanged;

        private string _filePath;
        private FileSystemWatcher _watcher;

        public FileWatcher(string filePath)
        {
            _filePath = filePath;

            _watcher = new FileSystemWatcher(Path.GetDirectoryName(_filePath));
            _watcher.Filter = Path.GetFileName(_filePath);
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Changed += OnFileChanged;
            _watcher.EnableRaisingEvents = true;
        }

        protected virtual void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            FileChanged?.Invoke(this, EventArgs.Empty);
        }

        public void StopWatching()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Changed -= OnFileChanged;
            _watcher.Dispose();
        }
    }
}