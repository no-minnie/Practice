using Task5;
    public class Program
    {
        public static void Main(string[] args)
        {
            Device mySmartphone = new Smartphone();
            Device myLaptop = new Laptop();

            mySmartphone.TurnOn();
            mySmartphone.TurnOff();

            myLaptop.TurnOn();
            myLaptop.TurnOff();
        }
    }
