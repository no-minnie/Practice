using Task2;
    class Program
    {
        static void Main(string[] args)
        {
            string fileDataPath = "file.data";
            string adultsDataPath = "adults.data";
            string minorsDataPath = "minors.data";

            File.WriteAllText(fileDataPath, string.Empty);
            File.WriteAllText(adultsDataPath, string.Empty);
            File.WriteAllText(minorsDataPath, string.Empty);

            Console.WriteLine("\nСодержимое file.data после записи:");
            Console.WriteLine(File.ReadAllText(fileDataPath));

            PersonFileSplitter splitter = new PersonFileSplitter(fileDataPath, adultsDataPath, minorsDataPath);
            List<Person> people = new List<Person>
            {
                new Person("Петр", 25),
                new Person("Анна", 17),
                new Person("Дмитрий", 40),
                new Person("Елена", 16),
                new Person("Борис", 17)
            };
            splitter.WritePeople(people);

            Console.WriteLine("Запись данных завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
