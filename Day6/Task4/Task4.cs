using Task4;
    public class Task4Program
    {
        public static void Run()
        {
            MyClass myObject = new MyClass(); // два интерфейса с одинаковыми методами.

            IMyInterface1 iface1 = (IMyInterface1)myObject;
            IMyInterface2 iface2 = (IMyInterface2)myObject;

            iface1.DoSomething(); // вызов IMyInterface1.DoSomething()
            iface2.DoSomething(); // вызов IMyInterface2.DoSomething()

            //работа с бд
            DatabaseConnector connector = new DatabaseConnector();

            ISqlDatabase sqlDb = (ISqlDatabase)connector;
            INoSqlDatabase noSqlDb = (INoSqlDatabase)connector;

            sqlDb.Connect();       // вызов ISqlDatabase.Connect()
            noSqlDb.Connect();     // вызов INoSqlDatabase.Connect()
        }
    }
