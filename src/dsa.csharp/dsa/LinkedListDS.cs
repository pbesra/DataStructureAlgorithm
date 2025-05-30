namespace dsa
{
    public class LinkedListDS<T>
    {
        public Node<T> Head { get; set; }

        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new Node<T> { Data = item, Next = null };
                return;
            }
            var newNode = new Node<T> { Data = item, Next = null };
            newNode.Next = Head;
            Head = newNode;
        }

        public void RemovedFirstNode()
        {
            if (Head == null)
            {
                return;
            }
            Head = Head.Next;
        }

        public void RemovedLastNode()
        {
            if (Head == null)
            {
                return;
            }
            if (Head.Next == null)
            {
                Head = null;
                return;
            }

            var current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public void PrintNodes()
        {
            Node<T> current = Head;
            while (current != null)
            {
                System.Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public Node<T> GetHead()
        {
            return Head;
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}