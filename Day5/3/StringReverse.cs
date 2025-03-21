namespace Task3
{
    public static class StringReverse
    {
        public static string ReverseString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return ReverseString(str.Substring(1)) + str[0];
        }
    }
}