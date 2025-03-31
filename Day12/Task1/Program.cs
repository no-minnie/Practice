using Task1;
class Program
{
    static void Main(string[] args)
    {
        UserFactory adminFactory = new AdminFactory();
        IUser admin = adminFactory.CreateUser();
        Console.WriteLine("Разрешения администратора: " + string.Join(", ", admin.GetPermissions()));

        UserFactory moderatorFactory = new ModeratorFactory();
        IUser moderator = moderatorFactory.CreateUser();
        Console.WriteLine("Разрешения модератора: " + string.Join(", ", moderator.GetPermissions()));

        UserFactory regularFactory = new RegularFactory();
        IUser regularUser = regularFactory.CreateUser();
        Console.WriteLine("Разрешения пользователя: " + string.Join(", ", regularUser.GetPermissions()));

        Console.ReadKey();
    }
}