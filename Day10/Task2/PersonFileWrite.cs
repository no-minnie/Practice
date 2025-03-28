using System.Text;

namespace Task2
{
    public class PersonFileWriter
    {
        private readonly string _filePath;

        public PersonFileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void WritePerson(Person person)
        {
            try
            {
                using (var writer = new StreamWriter(_filePath, true, Encoding.UTF8))
                {
                    writer.WriteLine(person.ToString());
                    Console.WriteLine($"Записан человек: {person.Name}, {person.Age} в файл {_filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл {_filePath}: {ex.Message}");
            }
        }
    }
}