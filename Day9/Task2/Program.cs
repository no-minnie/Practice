using Task2;
class Program
{
    static void Main(string[] args)
    {
        LinkedListManager<int> manager = new LinkedListManager<int>();

        manager.Add(10, true);
        manager.Add(20, false);
        manager.Add(30, true);
        manager.Add(11, true);
        manager.Add(17, true);

        Console.WriteLine("Список:");
        manager.DisplayList();

        Console.WriteLine("Удаляем элементы больше 15.");
        int removed = manager.RemoveAll(x => x > 15);
        Console.WriteLine("Удалено элементов: " + removed);
        manager.DisplayList();

        Console.WriteLine("Первый элемент больше 5:");
        MyLinkedListNode<int> found = manager.FindFirst(x => x > 5);
        if (found != null)
        {
            Console.WriteLine("Найден элемент: " + found.Value);
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }
    }
}