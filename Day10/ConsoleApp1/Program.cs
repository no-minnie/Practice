using System;
using System.IO;

public class FileWatcher
{
    private FileSystemWatcher _watcher;

    public FileWatcher(string path)
    {
        _watcher = new FileSystemWatcher(path);

        // Подписка на события
        _watcher.Created += OnCreated;
        _watcher.Deleted += OnDeleted;
        _watcher.Changed += OnChanged;
        _watcher.Renamed += OnRenamed;

        _watcher.EnableRaisingEvents = true;
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[Created] Файл создан: {e.FullPath}");
        SendEmailNotification(e.FullPath); // Имитируем отправку email
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[Deleted] Файл удалён: {e.FullPath}");
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[Changed] Файл изменён: {e.FullPath}");
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"[Renamed] Файл переименован: {e.OldFullPath} -> {e.FullPath}");
    }

    private void SendEmailNotification(string filePath)
    {
        // Имитируем отправку email-уведомления
        Console.WriteLine($"[Email Notification] Новый файл: {filePath}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\path\to\your\directory"; // Замените на путь к вашей папке
        FileWatcher watcher = new FileWatcher(path);

        Console.WriteLine("Наблюдение за папкой запущено. Нажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}
