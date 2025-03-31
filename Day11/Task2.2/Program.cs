using Task22; 

class Program
{
    static void Main(string[] args)
    {
        ICarBuilder sedanBuilder = new SedanBuilder();
        CarDirector director = new CarDirector(sedanBuilder);

        director.Construct();
        Car sedan = sedanBuilder.GetResult();
        Console.WriteLine("Sedan: " + sedan);

        director.SetBuilder(new SUVBuilder());
        director.Construct();
        Car suv = director.BuildCar();
        Console.WriteLine("SUV: " + suv);

        director.SetBuilder(new TruckBuilder());
        Car truck = director.Construct("Super Truck", "Big Truck", "V8", 6, "Red");
        Console.WriteLine("Truck: " + truck);

        Console.ReadKey();
    }
}