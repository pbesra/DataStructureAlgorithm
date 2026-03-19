namespace dsa.DataStructure.Heaps;

public class MinHeapImpl
{
    private MaxHeapImpl _maxHeap;
    private int[] _list;
    public MinHeapImpl(int[] items)
    {
        _list = items;
    }

    public void ConstructHeap()
    {
        Minify(_list);
        _maxHeap = new MaxHeapImpl(_list);
        _maxHeap.ConstructHeap();
    }

    private void Minify(int[] items)
    {
        _list=items.Select((x, i) => -_list[i]).ToArray();
    }

    public void Add(int item)
    {
        _maxHeap.Add(-item);
    }

    public int Poll()
    {
        var item=_maxHeap.Poll();
        return -item;
    }

    public int Peek()
    {
        return -_maxHeap.Peek();
    }

    public int Size()
    {
        return _maxHeap.Size();
    }
}