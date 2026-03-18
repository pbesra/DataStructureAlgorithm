using dsa.DataStructure.Heaps;

namespace dsa.DataStructureTests.HeapsTests;

public class MaxHeapImplTests
{
    private MaxHeapImpl _maxHeap;
    public MaxHeapImplTests()
    {
        _maxHeap = new MaxHeapImpl(new List<int>{8, 2, 10, 1, 5, 7, 3, 12, 6, 4});
    }

    [Fact]
    public void TestMaxHeap()
    {
        _maxHeap = new MaxHeapImpl(new List<int>{8, 2, 10, 1, 5, 7, 3, 12, 6, 4});
        
        _maxHeap.ConstructHeap();
    }
}