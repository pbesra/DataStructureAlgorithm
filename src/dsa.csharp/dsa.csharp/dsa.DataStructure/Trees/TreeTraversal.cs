using dsa.core.Core.Nodes;

namespace dsa.DataStructure.Trees;

public class TreeTraversal<T> where T : IComparable<T>
{
    public List<T> TreeItems;
    public TreeTraversal()
    {
        TreeItems = new List<T>();
    }
    
    public void PreOrder(BstNode<T> node) 
    {
        if (node == null)
            return;
        Console.WriteLine(node.Value);
        TreeItems.Add(node.Value);
        PreOrder(node.Left);
        PreOrder(node.Right);
    }

    public void InOrder(BstNode<T> node) 
    {
        if (node == null)
            return;
        InOrder(node.Left);
        Console.WriteLine(node.Value);
        TreeItems.Add(node.Value);
        InOrder(node.Right);
    }

    public void PostOrder(BstNode<T> node)
    {
        if(node == null)
            return;
        PostOrder(node.Left);
        PostOrder(node.Right);
        Console.WriteLine(node.Value);
        TreeItems.Add(node.Value);
    }
}