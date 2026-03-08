namespace dsa.DataStructure.Queue
{
    public class QueueImpl<T>
    {
        private T[] _data;
        private int _capacity;
        private int _front;
        private int _rear;
        private int _size;

        public QueueImpl()
        {
            _capacity = 2;
            _front = 0;
            _rear = 0;
            _size = 0;
            _data = new T[_capacity];
        }
        
        public void Enqueue(T item)
        {
            if (_size == 0 || _size == _capacity)
            {
                Resize();
            }
            _data[(_rear)%_capacity] = item;
            _rear++;
            _size++;
        }

        public T Dequeue()
        {
            var item = Peek();
            _front = (_front + 1) % _capacity;
            _size--;
            return item;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _data[(_front)%_capacity];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Clear()
        {
            _capacity = 0;
            _front = -1;
            _rear = -1;
            _size = 0;
        }

        public int Size()
        {
            return _size;
        }

        private void Resize()
        {
            _capacity = _capacity * 2;
            T[] newData = new T[_capacity];
            for (int i = 0; i < _size; i++)
            {
                newData[i] = _data[(_front + i) %_capacity];
            }

            _data = newData;
        }
    }
}