namespace Task1
{
    public class AdminFactory : UserFactory
    {
        public override IUser CreateUser()
        {
            return new AdminUser();
        }
    }
}