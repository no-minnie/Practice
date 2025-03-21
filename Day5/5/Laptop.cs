namespace Task5
{
    public class Laptop : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Laptop is turning On");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Laptop is turning off.");
        }
    }
}