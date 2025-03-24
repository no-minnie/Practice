using Task4;
    public class MyClass : IMyInterface1, IMyInterface2
    {
        void IMyInterface1.DoSomething()
        {
            Console.WriteLine("IMyInterface1.DoSomething() вызван");
        }

        void IMyInterface2.DoSomething()
        {
            Console.WriteLine("IMyInterface2.DoSomething() вызван");
        }
    }
