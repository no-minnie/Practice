/*Реализовать метод GenerateRandomPersons, создающий массив
случайных объектов Person заданного размера.*/
public static class ArrayOperations
{
    public static Person[] GenerateRandomPersons(int size) // создает массив случайных pers
    {
        Person[] people = new Person[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            string name = "Person" + i; // генерация имени
            int age = random.Next(18, 65);  // возраста от 18 до 64
            people[i] = new Person(name, age);
        }

        return people;
    }

    public static Person[] SortByAge(Person[] people) // сорт по возрасту
    {
        return people.OrderBy(p => p.Age).ToArray();
    }

    public static Person[] FilterByAge(Person[] people, int minAge) // фильтрация по мин
    {
        return people.Where(p => p.Age >= minAge).ToArray();
    }

    public static double AverageAge(Person[] people) // вычисл среднего возраста
    {
        if (people == null || people.Length == 0)
        {
            return 0; 
        }
        return people.Average(p => p.Age);
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age) //констр класса
    {
        Name = name;
        Age = age;
    }

    public override string ToString() // переопределяет метод tostring() 
    {
        return $"Имя: {Name}, Возраст: {Age}";
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Person[] randomPeople = ArrayOperations.GenerateRandomPersons(10);

        Console.WriteLine("Сгенерированные случайные люди:");
        foreach (var person in randomPeople)
        {
            Console.WriteLine(person);
        }

        Person[] sortedPeople = ArrayOperations.SortByAge(randomPeople);
        Console.WriteLine("\nОтсортировано по возрасту:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine(person);
        }

        Person[] filteredPeople = ArrayOperations.FilterByAge(randomPeople, 30);
        Console.WriteLine("\nОтфильтровано (возраст >= 30):");
        foreach (var person in filteredPeople)
        {
            Console.WriteLine(person);
        }

        double averageAge = ArrayOperations.AverageAge(randomPeople);
        Console.WriteLine($"\nСредний возраст: {averageAge}");
    }
}