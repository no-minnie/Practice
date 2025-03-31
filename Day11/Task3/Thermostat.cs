namespace Task3
{
    public class Thermostat : IDevice
    {
        public void Update(string state)
        {
            if (state == "Ночь")
            {
                Console.WriteLine("Термостат: понижаю температуру на 5 градусов.");
            }
            else
            {
                Console.WriteLine("Термостат: поддерживаю комфортную температуру.");
            }
        }
    }
}