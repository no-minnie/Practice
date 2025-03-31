namespace Task21
{
    public class UpperCaseFormat : ITextFormatStrategy
    {
        public string Format(string text)
        {
            return text.ToUpper();
        }
    }
}