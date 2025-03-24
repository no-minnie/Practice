namespace Task2
{
    public class Battery //часть композиции
    {
        public int Capacity { get; set; } // емкость 

        public Battery(int capacity)
        {
            Capacity = capacity;
        }
    }
}