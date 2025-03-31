namespace Task21
{
    public class TextFormatter
    {
        private ITextFormatStrategy _strategy;

        public TextFormatter(ITextFormatStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy), "Стратегия не может быть null.");
        }

        public void SetFormatStrategy(ITextFormatStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy), "Стратегия не может быть null.");
        }

        public string FormatText(string text)
        {
            if (text == null)
            {
                return null;
            }
            return _strategy.Format(text);
        }
    }
}