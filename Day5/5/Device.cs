namespace Task5
{
    public abstract class Device
    {
        public abstract void TurnOn();

        public virtual void TurnOff()
        {
            Console.WriteLine("Устройство выключено (базовый класс).");
        }
    }
}