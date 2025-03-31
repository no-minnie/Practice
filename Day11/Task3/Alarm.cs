namespace Task3
{
    public class Alarm : IDevice
    {
        public void Update(string state)
        {
            if (state == "Ночь")
            {
                Console.WriteLine("Сигнализация: включаю ночной режим охраны.");
            }
            else
            {
                Console.WriteLine("Сигнализация: отключаю ночной режим охраны.");
            }
        }
    }
}