namespace dsa.DataStructure.Heaps;

public class MaxHeapImpl
{
    private int[] _list;
    private int _capacity;
    private int _size;

    public MaxHeapImpl()
    {
        
    }

    public int Size()
    {
        return _size;
    }
    
    
    public MaxHeapImpl(int[] list)
    {
        _list = list;
        _capacity = _list.Length;
        _size = _list.Length;
    }
    public void Heapify(int currIndex)
    {
        int left = currIndex * 2 + 1;
        int right = currIndex * 2 + 2;
        
        
        int largeIndex = currIndex;
        
        if (left < _size && _list[left] > _list[largeIndex])
        {
            largeIndex = left;
        }

        if (right < _size && _list[right] > _list[largeIndex])
        {
            largeIndex = right;
        }

        if (currIndex != largeIndex)
        {
            (_list[currIndex], _list[largeIndex]) = (_list[largeIndex], _list[currIndex]);
            Heapify(largeIndex);
        }
        
    }
    public void ConstructHeap()
    {
        for (int i=(_size-1) / 2; i >= 0; i--)
        {
            Heapify(i);
        }

        var tesu = 10;
    }

    /// <summary>
    /// It goes from bottom to up.
    /// </summary>
    /// <param name="currIndex"></param>
    private void HeapifyUp(int currIndex)
    {
        while (true)
        {
            var parentIndex = (currIndex - 1) / 2;
            if (parentIndex < 0 || _list[currIndex] <= _list[parentIndex])
            {
                return;
            };
            (_list[currIndex], _list[parentIndex]) = (_list[parentIndex], _list[currIndex]);
            currIndex = parentIndex;
        }
    }

    public void Add(int item)
    {
        if (_size ==0 || _size == _capacity)
        {
            Resize();
        }
        _list[_size] = item;
        HeapifyUp(_size);
        _size++;
        
    }

    public int Poll()
    {
        
        if (_size == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        var item = _list[0];
        var lastItem = _list[_size-1];
        _list[0] = lastItem;
        _size--;
        Heapify(0);
        return item;

    }

    public int Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }
        return _list[0];
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }
    
    public void  Clear()
    {
        _size = 0;
    }

    private void Resize()
    {
        _capacity = _capacity*2;
        int[] newList = new int[_capacity];
        Array.Copy(_list, newList, _size);
        _list = newList;
    }
}