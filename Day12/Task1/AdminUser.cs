namespace Task1
{
    public class AdminUser : IUser
    {
        public string[] GetPermissions()
        {
            return new string[] { "чтение", "запись", "удаление", "управление пользователями" };
        }
    }
}