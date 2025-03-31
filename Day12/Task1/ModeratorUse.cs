namespace Task1
{
    public class ModeratorUser : IUser
    {
        public string[] GetPermissions()
        {
            return new string[] { "чтение", "запись", "редактирование", "предупреждение пользователей" };
        }
    }
}