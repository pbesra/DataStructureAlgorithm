using dsa.DataStructure.Trees;

namespace dsa.DataStructureTests.TreeTests;

public class BinarySearchTreeTests
{
    [Fact]
    public void TestsBstAddAndPreOrder()
    {
        var bst=new BinarySearchTree<int>();
        bst.Add(9);
        bst.Add(4);
        bst.Add(1);
        bst.Add(8);
        bst.Add(5);
        bst.Add(7);
        bst.Add(3);
        var items=bst.PrintPreOrder();
        
    }
}