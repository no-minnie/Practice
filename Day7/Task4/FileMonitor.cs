namespace FileWatcherTask
{
    public class FileMonitor
    {
        public void OnFileChanged(object sender, EventArgs e)
        {
            Console.WriteLine("FileMonitor: Обнаружено изменение файла!");
        }
    }
}