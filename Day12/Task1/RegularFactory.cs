namespace Task1
{
    public class RegularFactory : UserFactory
    {
        public override IUser CreateUser()
        {
            return new RegularUser();
        }
    }
}