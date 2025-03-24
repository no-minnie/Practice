namespace Task2
{
    public class Smartphone
    {
        public List<App> InstalledApps { get; set; } = new List<App>();// агрегация массив приложений 

        public Battery Battery { get; } // композиция батарея 

        public User Owner { get; set; } // ассоциация пользователь (телефон может принадлежать пользователю)

        public Smartphone(Battery battery, User owner) // конструктор 
        {
            Battery = battery; // создаем батарею при создании телефона (композиция)
            Owner = owner;     // устанавливаем владельца (ассоциация)
        }

        public void InstallApp(App app) // метод для установки приложения
        {
            InstalledApps.Add(app);
        }

        public void UninstallApp(App app) // метод для удаления приложения
        {
            InstalledApps.Remove(app);
        }

        public void ShowInstalledApps() // метод для отображения установленных приложений
        {
            Console.WriteLine("Установленные приложения:");
            foreach (var app in InstalledApps)
            {
                Console.WriteLine($"- {app.Name}");
            }
        }
    }
}