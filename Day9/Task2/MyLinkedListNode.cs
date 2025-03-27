namespace Task2
{
    public class MyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
        public MyLinkedListNode<T> Previous { get; set; }

        public MyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}