namespace Task2
{
    public class LinkedListManager<T>
    {
        private readonly MyLinkedList<T> _linkedList = new MyLinkedList<T>();

        public void Add(T item, bool toBeginning)
        {
            if (toBeginning)
            {
                _linkedList.AddFirst(item);
            }
            else
            {
                _linkedList.AddLast(item);
            }
        }

        public bool Remove(T item)
        {
            return _linkedList.Remove(item);
        }

        public MyLinkedListNode<T> Find(T item)
        {
            return _linkedList.Find(item);
        }

        public void DisplayList()
        {
            MyLinkedListNode<T> current = _linkedList.Head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Бизнес-логика: Удаление всех элементов, удовлетворяющих условию
        public int RemoveAll(Predicate<T> match)
        {
            int removedCount = 0;
            MyLinkedListNode<T> current = _linkedList.Head;

            while (current != null)
            {
                // Сохраняем ссылку на следующий узел, так как текущий может быть удален
                MyLinkedListNode<T> next = current.Next;

                if (match(current.Value))
                {
                    _linkedList.Remove(current.Value);
                    removedCount++;
                }

                current = next;
            }

            return removedCount;
        }

        // Бизнес-логика: Поиск всех элементов, удовлетворяющих условию
        public MyLinkedListNode<T> FindFirst(Predicate<T> match)
        {
            MyLinkedListNode<T> current = _linkedList.Head;

            while (current != null)
            {
                if (match(current.Value))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }
    }
}