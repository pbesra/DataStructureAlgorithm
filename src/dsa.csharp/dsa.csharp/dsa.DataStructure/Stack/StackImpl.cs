namespace dsa.DataStructure.Stack
{
    public class StackImpl<T>
    {
        private T[] StackArray;
        private int MaxSize;
        private int Top;

        public StackImpl()
        {
            MaxSize = 0;
            StackArray = new T[MaxSize];
            Top = -1;
        }

        public void Push(T data)
        {
            if (Top == MaxSize - 1)
            {
                Resize();
            }

            StackArray[++Top] = data;
        }

        public T Pop()
        {
            if (Top == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return StackArray[Top--];
        }

        public int Size()
        {
            return Top + 1;
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }

        public T Peek()
        {
            if (Top == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return StackArray[Top];
        }

        public void Clear()
        {
            Top = -1;
        }

        private void Resize()
        {
            MaxSize = MaxSize == 0 ? 1 : MaxSize * 2;
            T[] newStackArray = new T[MaxSize];
            Array.Copy(StackArray, newStackArray, StackArray.Length);
            StackArray = newStackArray;
        }
    }
}