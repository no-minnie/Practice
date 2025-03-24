namespace Task1
{
    public abstract class Transport
    {
        public abstract void Move();
    }

    public class Car : Transport // наследник Transport
    {
        public override void Move()
        {
            Console.WriteLine("Машина едет");
        }
    }

    public class Bike : Transport //наследник Transport
    {
        public override void Move()
        {
            Console.WriteLine("Велосипед едет");
        }
    }

    public class Airplane : Transport // наследник Transport
    {
        public override void Move()
        {
            Console.WriteLine("Самолет летит");
        }
    }

    public class Task1Program
    {
        public static void Run()
        {
            Transport[] transports = new Transport[] { new Car(), new Bike(), new Airplane() };

            foreach (Transport transport in transports) 
            {
                transport.Move();
            }
        }
    }
}