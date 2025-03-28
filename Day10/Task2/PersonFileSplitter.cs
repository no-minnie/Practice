using System.Text;
using Task2;

namespace Task2
{
    public class PersonFileSplitter
    {
        private readonly string _fileDataPath;
        private readonly string _adultsFilePath;
        private readonly string _minorsFilePath;

        public PersonFileSplitter(string fileDataPath, string adultsFilePath, string minorsFilePath) 
        {
            _fileDataPath = fileDataPath;
            _adultsFilePath = adultsFilePath;
            _minorsFilePath = minorsFilePath;
        }

        public void WritePeople(List<Person> people)
        {
            try
            {



                List<Person> adults = people.Where(p => p.Age >= 18)
                                        .OrderBy(p => p.Name)
                                        .ToList();

                List<Person> minors = people.Where(p => p.Age < 18)
                                       .OrderBy(p => p.Name)
                                       .ToList();

                foreach (Person person in people)
                {
                    using (StreamWriter dataWriter = new StreamWriter(_fileDataPath, true, Encoding.UTF8))
                    {
                        dataWriter.WriteLine(person.ToString());
                        Console.WriteLine($"Записан человек: {person.Name}, {person.Age} в файл {_fileDataPath}");
                    }
                }


                using (StreamWriter writer = new StreamWriter(_adultsFilePath, true, Encoding.UTF8))
                {
                    foreach (Person person in adults)
                    {
                        writer.WriteLine(person.ToString());
                        Console.WriteLine($"Записан взрослый: {person.Name}, {person.Age} в файл {_adultsFilePath}");
                    }
                }

                using (StreamWriter writer = new StreamWriter(_minorsFilePath, true, Encoding.UTF8))
                {
                    foreach (Person person in minors)
                    {
                        writer.WriteLine(person.ToString());
                        Console.WriteLine($"Записан несовершеннолетний: {person.Name}, {person.Age} в файл {_minorsFilePath}");
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файлы: {ex.Message}");
            }

            Console.WriteLine("\nСодержимое adults.data после записи:");
            Console.WriteLine(File.ReadAllText(_adultsFilePath));

            Console.WriteLine("\nСодержимое minors.data после записи:");
            Console.WriteLine(File.ReadAllText(_minorsFilePath));
        }
    }
}