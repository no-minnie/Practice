namespace Task21
{
    public class TitleCaseFormat : ITextFormatStrategy
    {
        public string Format(string text)
        {
            System.Globalization.TextInfo textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}