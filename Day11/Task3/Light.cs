namespace Task3
{
    public class Light : IDevice
    {
        public void Update(string state)
        {
            if (state == "Ночь")
            {
                Console.WriteLine("Свет: приглушаю яркость.");
            }
            else
            {
                Console.WriteLine("Свет: включаю обычную яркость.");
            }
        }
    }
}