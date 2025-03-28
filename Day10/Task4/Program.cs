using Microsoft.Extensions.Configuration;
using Task4;
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:/Users/37529/Desktop/практика C#/Новик_09/Task4/AppSettings.json", optional: false, reloadOnChange: true)
                .Build();

            string directoryPath = config["DirectoryPath"];
            string filter = config["Filter"];

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            FileWatcher watcher = new FileWatcher(directoryPath, filter);
            watcher.StartWatching(); 

            Console.WriteLine("Конец");
            Console.ReadKey();
        }
    }
