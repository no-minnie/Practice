namespace Task2
{
    public class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head { get; private set; }
        public MyLinkedListNode<T> Tail { get; private set; }

        public void AddFirst(T item)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(item);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
        }

        public void AddLast(T item)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(item);
            if (Tail == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public bool Remove(T item)
        {
            MyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (Equals(current.Value, item))
                {
                    // Обновляем Head, если удаляем первый элемент
                    if (current.Previous == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    // Обновляем Tail, если удаляем последний элемент
                    if (current.Next == null)
                    {
                        Tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public MyLinkedListNode<T> Find(T item)
        {
            MyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (Equals(current.Value, item))
                    return current;
                current = current.Next;
            }
            return null;
        }
    }
}