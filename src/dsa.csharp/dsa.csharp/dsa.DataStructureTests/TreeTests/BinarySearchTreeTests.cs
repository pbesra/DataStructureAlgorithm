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

    [Fact]
    public void TestsBstAddAndHeight()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        bst.Add(9);
        bst.Add(4);
        bst.Add(1);
        bst.Add(8);
        bst.Add(5);
        bst.Add(7);
        bst.Add(3);
        bst.Add(6);

        var expectedHeight = 5;

        var height = bst.Height();
        Assert.Equal(expectedHeight, height);

    }

    [Fact]
    public void TestsBstAddAndHeight_WithRootNode()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        bst.Add(9);

        var expectedHeight = 0;

        var height = bst.Height();
        Assert.Equal(expectedHeight, height);
    }

    [Fact]
    public void TestsBstAddAndHeight_WithNoRootNode()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        var expectedHeight = -1;

        var height = bst.Height();
        Assert.Equal(expectedHeight, height);
    }
}