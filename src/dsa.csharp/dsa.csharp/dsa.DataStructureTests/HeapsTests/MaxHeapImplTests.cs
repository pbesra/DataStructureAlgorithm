using dsa.DataStructure.Heaps;

namespace dsa.DataStructureTests.HeapsTests;

public class MaxHeapImplTests
{
    private MaxHeapImpl _maxHeap;
    public MaxHeapImplTests()
    {
        
    }

    [Fact]
    public void TestMaxHeap()
    {
        var items = new int[]{8, 2, 10, 1, 5, 7, 3, 12, 6, 4};
        var maxItem = items.Max();
        
        _maxHeap = new MaxHeapImpl(items);
        
        _maxHeap.ConstructHeap();
        Assert.Equal(items.Length, _maxHeap.Size());
        Assert.Equal(maxItem, _maxHeap.Peek());
    }
    
    [Fact]
    public void TestConstructHeapAndAddAndPeek()
    {
        var items = new int[]{8, 2, 10, 1, 5, 7, 3, 12, 6, 4};
        _maxHeap = new MaxHeapImpl(items);
        
        
        _maxHeap.ConstructHeap();
        _maxHeap.Add(8);
        _maxHeap.Add(18);
        int peekItem= _maxHeap.Peek();
        Assert.Equal(18, _maxHeap.Peek());
        Assert.Equal(items.Length+2, _maxHeap.Size());
    }
    
    [Fact]
    public void TestConstructHeapAndAddAndPollAndPeek()
    {
        var items = new int[]{8, 2, 10, 1, 5, 7, 3, 12, 6, 4};
        _maxHeap = new MaxHeapImpl(items);
        
        _maxHeap.ConstructHeap();
        _maxHeap.Add(8);
        _maxHeap.Add(18);
        _maxHeap.Add(10);
        _maxHeap.Add(17);
        _maxHeap.Poll();
        
        int peekItem= _maxHeap.Peek();
        Assert.Equal(17, _maxHeap.Peek());
        Assert.Equal(items.Length+3, _maxHeap.Size());
    }
    
}