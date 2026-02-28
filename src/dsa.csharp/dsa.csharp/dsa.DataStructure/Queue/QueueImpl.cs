namespace dsa.DataStructure.Queue
{
    public class QueueImpl<T>
    {
        private T[] _data;
        private int _capacity;
        private int _front;
        private int _rear;

        public QueueImpl()
        {
            _capacity = 4;
            _front = -1;
            _rear = -1;
            _data = new T[_capacity];
        }

        public void Enqueue(T data)
        {
            int currentSize = Size();
            if (currentSize == _capacity)
            {
                Resize();
            }
            _data[(_rear - 1) % _capacity] = data;  // 6, 10, 56, 16, 14, 18
            _rear = (_rear + 1) % _capacity;
        }

        public T Dequeue()
        {
            var item = Peek();
            _front = (_front + 1) % _capacity;
            return item;
        }

        public T Peek()
        {
            if (_rear == -1)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _data[_front];
        }

        public bool IsEmpty()
        {
            return _front == -1;
        }

        public void Clear()
        {
            _capacity = 0;
            _front = -1;
            _rear = 0;
        }

        public int Size()
        {
            return _rear - _front + 1; // upper not inclusive example: [3, 5, 12, 2, 8], then front = 0, rear = 5, size = 5 - 0 = 5
        }

        public void Resize()
        {
            _capacity = _capacity * 2;
            T[] newData = new T[_capacity];
            int currentSize = Size();
            for (int i = 0; i <= currentSize; i++)
            {
                newData[i] = _data[(_front + i) % currentSize];
            }
            _data = newData;
            _front = 0;
            _rear = currentSize;
        }
    }
}