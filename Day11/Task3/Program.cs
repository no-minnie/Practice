using Task3;

class Program
{
    static void Main(string[] args)
    {
        SmartHomeHub hub = new SmartHomeHub();

        Light light = new Light();
        Thermostat thermostat = new Thermostat();
        Alarm alarm = new Alarm();

        hub.Attach(light);
        hub.Attach(thermostat);
        hub.Attach(alarm);

        hub.State = "Ночь";

        Console.WriteLine("\nНаступило утро\n");
        hub.State = "Утро";

        Console.ReadKey();
    }
}