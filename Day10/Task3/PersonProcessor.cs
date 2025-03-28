namespace Task3
{
    public class PersonProcessor
    {
        public Dictionary<string, List<Person>> GroupByAge(List<Person> people)
        {
            Dictionary<string, List<Person>> groups = new Dictionary<string, List<Person>>();

            groups["моложе 18"] = people.Where(p => p.Age < 18).ToList();
            groups["от 18 до 40"] = people.Where(p => p.Age >= 18 && p.Age <= 40).ToList();
            groups["старше 40"] = people.Where(p => p.Age > 40).ToList();

            return groups;
        }
    }
}