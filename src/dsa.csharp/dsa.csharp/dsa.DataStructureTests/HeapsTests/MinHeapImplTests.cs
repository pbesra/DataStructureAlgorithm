using dsa.DataStructure.Heaps;

namespace dsa.DataStructureTests.HeapsTests;

public class MinHeapImplTests
{
    private MinHeapImpl  _minHeap;
    public MinHeapImplTests()
    {
        
    }
    
    [Fact]
    public void TestMaxHeap()
    {
        var items = new int[]{8, 2, 10, 1, 5, 7, 3, 12, 6, 4};
        var minItem = items.Min();
        
        _minHeap = new MinHeapImpl(items);
        
        _minHeap.ConstructHeap();
        Assert.Equal(items.Length, _minHeap.Size());
        Assert.Equal(minItem, _minHeap.Peek());
    }
    
    [Fact]
    public void TestConstructHeapAndAddAndPeek()
    {
        var items = new int[]{8, 2, 10, 1, 5, 7, 3, 12, 6, 4};
        _minHeap = new MinHeapImpl(items);
        
        
        _minHeap.ConstructHeap();
        _minHeap.Add(8);
        _minHeap.Add(18);
        int peekItem= _minHeap.Peek();
        Assert.Equal(1, _minHeap.Peek());
        Assert.Equal(items.Length+2, _minHeap.Size());
    }
    
    [Fact]
    public void TestConstructHeapAndAddAndPollAndPeek()
    {
        var items = new int[]{8, 2, 10, 1, 5, 7, 3, 12, 6, 4};
        _minHeap = new MinHeapImpl(items);
        
        _minHeap.ConstructHeap();
        _minHeap.Add(8);
        _minHeap.Add(18);
        _minHeap.Add(10);
        _minHeap.Add(17);
        _minHeap.Poll();
        
        int peekItem= _minHeap.Peek();
        Assert.Equal(2, _minHeap.Peek());
        Assert.Equal(items.Length+3, _minHeap.Size());
    }

}