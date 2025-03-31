namespace Task21
{
    public class LowerCaseFormat : ITextFormatStrategy
    {
        public string Format(string text)
        {
            return text.ToLower();
        }
    }
}