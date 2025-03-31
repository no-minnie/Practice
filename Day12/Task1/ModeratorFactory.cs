namespace Task1
{
    public class ModeratorFactory : UserFactory
    {
        public override IUser CreateUser()
        {
            return new ModeratorUser();
        }
    }
}