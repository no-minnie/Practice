namespace Task2
{
    public static class DigitCounter
    {
        public static void CountSum(int k, out int c, out int s)
        {
            if (k <= 0)
            {
                throw new System.ArgumentException("Число должно быть целым и положительным.");
            }

            string kStr = k.ToString();
            c = kStr.Length;
            s = 0;

            foreach (char digitChar in kStr)
            {
                s += int.Parse(digitChar.ToString());
            }
        }
    }
}