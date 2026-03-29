using dsa.DataStructure.Trees;

namespace dsa.DataStructureTests.TreeTests;

public class BinarySearchTreeTests
{
    [Fact]
    public void TestsBstAddAndPreOrder()
    {
        // Arrange
        var items = new List<int> {9, 4, 1, 8, 5, 7, 3 };
        var bst=new BinarySearchTree<int>();
        foreach (var bstItem in items)
        {
            bst.Add(bstItem);
        }
        var bstItems=bst.PrintPreOrder();
        
        var expectedPreOrderItems = new List<int> {9, 4, 1, 3, 8, 5, 7};
        
        // Assert
        for (var i=0;i<expectedPreOrderItems.Count;i++)
        {
            Assert.Equal(expectedPreOrderItems.ElementAt(i),bstItems[i]);
        }
        
    }
    
    [Fact]
    public void TestsBstAddAndInOrder()
    {
        // Arrange
        var items = new List<int> {9, 4, 1, 8, 5, 7, 3 };
        var bst=new BinarySearchTree<int>();
        foreach (var bstItem in items)
        {
            bst.Add(bstItem);
        }

        var sortedItems = items.Select(bstItem => bstItem).Order();
        
        var bstItems=bst.PrintInOrder();
        
        // Assert
        for (var i=0;i<items.Count;i++)
        {
            Assert.Equal(sortedItems.ElementAt(i),bstItems[i]);
        }
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