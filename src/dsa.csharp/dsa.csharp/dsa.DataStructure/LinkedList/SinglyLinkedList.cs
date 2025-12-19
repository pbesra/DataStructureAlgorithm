using dsa.core.Core;
using dsa.core.Core.Corebase;
using dsa.DataStructure.Node;

namespace dsa.DataStructure.LinkedList
{
    public class SinglyLinkedList<T>
    {
        private Node<T>? Head;
        private readonly SizeTracker _sizeTracker;
        private int Length => _sizeTracker.Size;

        public SinglyLinkedList()
        {
            _sizeTracker = new SizeTracker();
        }

        public void Add(T? data)
        {
            Node<T> newNode = new Node<T> { Data = data, Next = null };
            if (Head == null)
            {
                Head = newNode;
                _sizeTracker.IncrementLength();
                return;
            }
            Node<T> currentHead = Head;
            newNode.Next = currentHead;
            Head = newNode;
            _sizeTracker.IncrementLength();
        }

        public int Size()
        {
            return this.Length;
        }

        public void PrintList()
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next!;
            }
        }

        public T? Peek()
        {
            if (Head != null)
            {
                return Head.Data;
            }
            return default;
        }

        public T? Pop()
        {
            if (Head == null)
            {
                return default;
            }
            T data = Head.Data!;
            Head = Head.Next!;
            _sizeTracker.DecrementLength();
            return data;
        }

        public void Remove()
        {
            if (Head != null)
            {
                Head = Head.Next!;
                _sizeTracker.DecrementLength();
            }
        }

        public void Clear()
        {
            if (Head != null)
            {
                Head = null;
                _sizeTracker.DecrementLength(Length);
            }
        }
    }
}