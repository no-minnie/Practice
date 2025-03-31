namespace Task1
{
    public class RegularUser : IUser
    {
        public string[] GetPermissions()
        {
            return new string[] { "чтение", "запись", "комментирование" };
        }
    }
}