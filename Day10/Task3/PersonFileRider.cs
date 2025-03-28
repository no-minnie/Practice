namespace Task3
{
    public class PersonFileReader
    {
        private readonly string _filePath;

        public PersonFileReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Person> ReadPeople()
        {
            List<Person> people = new List<Person>();

            try
            {
                if (File.Exists(_filePath))
                {
                    string[] lines = File.ReadAllLines(_filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string name = parts[0].Trim();
                            if (int.TryParse(parts[1].Trim(), out int age))
                            {
                                people.Add(new Person(name, age));
                            }
                            else
                            {
                                Console.WriteLine($"Некорректный возраст в строке: {line}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Некорректный формат строки: {line}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Файл не найден: {_filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return people;
        }
    }
}