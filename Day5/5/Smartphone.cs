namespace Task5
{
    public class Smartphone : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Smartphone is turning on");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Smartphone is turning off.");
        }
    }
}