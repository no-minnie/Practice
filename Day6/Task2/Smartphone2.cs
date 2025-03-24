namespace Task2
{
    public class SmartphoneTaskProgram
    {
        public static void RunSmartphoneTask()
        {
            var battery = new Battery(3000); // компоненты
            var user = new User("Иван");

            var phone = new Smartphone(battery, user);//композиция: батарея создается вместе с телефоном

            var app1 = new App("Калькулятор"); //приложения
            var app2 = new App("Карты");

            phone.InstallApp(app1);// устанавка, агрегация: приложения можно добавлять и удалять
            phone.InstallApp(app2);

            phone.ShowInstalledApps();//показываем установленные приложения

            phone.UninstallApp(app1); //удаляем 

            phone.ShowInstalledApps();//снова показываем 

            phone.Owner = new User("Мария"); // меняем владельца ассоциация
            Console.WriteLine($"Телефон теперь принадлежит: {phone.Owner.Name}");
        }
    }
}