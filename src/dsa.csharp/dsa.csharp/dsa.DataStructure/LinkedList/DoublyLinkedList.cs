using dsa.core.Core.Corebase;
using dsa.DataStructure.Node;

namespace dsa.DataStructure.LinkedList
{
    public class DoublyLinkedList<T>
    {
        private DoubleNode<T>? Head;
        

        private readonly SizeTracker _sizeTracker;
        private int Length => _sizeTracker.Size;

        public DoublyLinkedList()
        {
            _sizeTracker = new SizeTracker();
        }

        public void Add(T? data)
        {
            var newNode = new DoubleNode<T>
            {
                Data = data,
                Next = null,
                Prev = null
            };
            if (Head == null)
            {
                Head = newNode;

                return;
            }
            DoubleNode<T> currentHead = Head;
            newNode.Next = currentHead;
            currentHead.Prev = newNode;
            Head = newNode;
            _sizeTracker.IncrementLength();
        }

        public void Clear()
        {
            if (Head != null)
            {
                Head = null;
            }
            _sizeTracker.DecrementLength(Length);
        }

        public T? Pop()
        {
            if (this.Head==null)
            {
                return default;
            }
            return default;
        }

        public int Size()
        {
            return this.Length;
        }
    }
}