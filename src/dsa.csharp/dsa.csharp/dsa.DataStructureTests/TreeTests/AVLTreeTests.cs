using dsa.DataStructure.Trees;

namespace dsa.DataStructureTests.TreeTests;

public class AVLTreeTests
{
    private readonly AVLTree<int> tree;
    public AVLTreeTests()
    {
        tree = new AVLTree<int>();
    }

    [Fact]
    public void Insert_Test()
    {
        var items = new List<int> { 10, 6, 19, 34, 16, 13};
        var avlTreeTreeItems = new List<int> { 16, 10, 6, 13, 19, 34 };

        foreach (var item in items)
        {
            tree.Add(item);
        }
        
        var root = tree.Root;

        var treeTraversal = new TreeTraversal<int>();
        treeTraversal.PreOrder(root);
        var actualTreeItems= treeTraversal.TreeItems;

        for(var i=0;i<avlTreeTreeItems.Count;i++)
        {
            Assert.Equal(avlTreeTreeItems[i], actualTreeItems[i]);
        }
    }
    
    [Fact]
    public void Remove_Test()
    {
        // Arrange
        var items = new List<int> { 30, 20, 40, 10, 25};
        var expectedAvlTreeTreeItems = new List<int> {20, 10, 30, 25 };
        
        // Act
        foreach (var item in items)
        {
            tree.Add(item);
        }
        
        tree.RemoveData(40);
        
        var treeTraversal = new TreeTraversal<int>();
        treeTraversal.PreOrder(tree.Root);
        var actualAvlTreeTreeItems = treeTraversal.TreeItems;
        
        // Assert
        for (int i = 0; i < expectedAvlTreeTreeItems.Count; i++)
        {
            Assert.Equal(expectedAvlTreeTreeItems[i], actualAvlTreeTreeItems[i]);
        }
    }
}