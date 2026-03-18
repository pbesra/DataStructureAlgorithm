namespace dsa.DataStructure.Heaps;

public class MaxHeapImpl
{
    private List<int> _list;

    int GetSize()
    {
        return _list.Count;
    }
    
    public MaxHeapImpl(List<int> list)
    {
        _list = list;
    }
    public void Heapify(int currIndex)
    {
        int left = currIndex * 2 + 1;
        int right = currIndex * 2 + 2;
        int size=GetSize();
        
        int largeIndex = currIndex;
        
        if (left < size && _list[left] > _list[largeIndex])
        {
            largeIndex = left;
        }

        if (right < size && _list[right] > _list[largeIndex])
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
        for (int i=(_list.Count-1) / 2; i >= 0; i--)
        {
            Heapify(i);
        }

        var tesu = 10;
    }

    public void Print()
    {
        foreach (var i  in _list)
        {
            Console.WriteLine(i);
        }
    }

    public void Add(int item)
    {
        
    }

    public void Remove(int item)
    {
        
    }

    public int Peek()
    {
        return 0;
    }
}