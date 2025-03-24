namespace Task3
{
    public abstract class ITSpecialist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // интерфейсы
    public interface IInterface1
    {
        void DoSomething1();
    }

    public interface IInterface2
    {
        void DoSomething2();
    }
    public interface IProgrammer
    {
        void Code();
    }
    public interface IDesigner
    {
        void Design();
    }

    // классы, реализующие интерфейсы
    public class ClassA : ITSpecialist, IInterface1
    {
        public void DoSomething1()
        {
            Console.WriteLine($"{Name}: ClassA.DoSomething1");
        }
    }
    public class ClassB : ITSpecialist, IInterface2
    {
        public void DoSomething2()
        {
            Console.WriteLine($"{Name}: ClassB.DoSomething2");
        }
    }
    public class BackendDeveloper : ITSpecialist, IProgrammer
    {
        public void Code()
        {
            Console.WriteLine($"{Name}: Backend пишет код");
        }
    }
    public class UXDesigner : ITSpecialist, IDesigner
    {
        public void Design()
        {
            Console.WriteLine($"{Name}: UX делает дизайн");
        }
    }

    public static class CombinedTaskLogic
    {
        public static List<T> Filter<T>(List<ITSpecialist> list) where T : class
        {
            return list.OfType<T>().ToList();
        }
    }

    public class CombinedTaskProgram
    {
        public static void Run()
        {
            List<ITSpecialist> specialists = new List<ITSpecialist>
            {
                new ClassA { Id = 1, Name = "A1" },
                new ClassB { Id = 2, Name = "B2" },
                new BackendDeveloper { Id = 3, Name = "Бэк" },
                new UXDesigner { Id = 4, Name = "UX" }
            };


            List<IInterface1> interface1List = CombinedTaskLogic.Filter<IInterface1>(specialists);
            foreach (var item in interface1List)
            {
                item.DoSomething1();
            }

            List<IInterface2> interface2List = CombinedTaskLogic.Filter<IInterface2>(specialists);
            foreach (var item in interface2List)
            {
                item.DoSomething2();
            }

            List<IProgrammer> programmerList = CombinedTaskLogic.Filter<IProgrammer>(specialists);
            foreach (var item in programmerList)
            {
                item.Code();
            }
        }
    }
}
