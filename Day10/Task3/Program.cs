using Task3;
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/37529/Desktop/практика C#/Новик_09/Task2/bin/Debug/net8.0/file.data";
            PersonFileReader reader = new PersonFileReader(filePath);
            List<Person> people = reader.ReadPeople();

            PersonProcessor processor = new PersonProcessor();
            Dictionary<string, List<Person>> ageGroups = processor.GroupByAge(people);

            foreach (var group in ageGroups)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (Person person in group.Value)
                {
                    Console.WriteLine($"  {person.Name}, {person.Age}");
                }
            }

            Console.ReadKey();
        }
    }
