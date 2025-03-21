namespace Task4
{
    public static class DateTime
    {
        public static int GetAge(this System.DateTime birthDate)
        {
            System.DateTime now = System.DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
    }
}