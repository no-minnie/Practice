namespace Task6
{
    public class Name
    {
        public static List<string> GetNames(string gender)
        {
            List<string> manNames = new List<string> { "Иван", "Михаил", "Дмитрий", "Александр", "Сергей" };
            List<string> femaleNames = new List<string> { "Елена", "Ольга", "Наталья", "Татьяна", "Ирина" };

            switch (gender.ToLower()) //проверяем введенный пол
            {
                case "м":
                    return manNames;
                case "ж":
                    return femaleNames;
                default:
                    throw new ArgumentException("Некорректный ввод пола.");
            }
        }
    }
}