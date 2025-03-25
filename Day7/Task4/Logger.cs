namespace FileWatcherTask
{
    public class Logger
    {
        public void LogChange(object sender, EventArgs e)
        {
            Console.WriteLine("Logger: Изменения записаны в лог.");
        }
    }
}