using dsa.core.Core.Nodes;

namespace dsa.DataStructure.Trees;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private BstNode<T>? _root;

    public void Add(T data)
    {
        _root = AddNode(data, _root);
    }

    private BstNode<T>? AddNode(T data, BstNode<T>? currNode = null)
    {
        if (currNode == null)
        {
            currNode = new BstNode<T>(data);
            return currNode;
        }
        else if (data.CompareTo(currNode.Value) <= 0)
        {
            currNode.Left = AddNode(data, currNode.Left);
        }
        else
        {
            currNode.Right = AddNode(data, currNode.Right);
        }
        return currNode;
    }

    private void PreOrder(BstNode<T>? currNode, List<T> dataItems)
    {
        if (currNode == null) return;
        dataItems.Add(currNode.Value);
        PreOrder(currNode.Left, dataItems);
        PreOrder(currNode.Right, dataItems);
    }

    private void InOrder(BstNode<T>? currNode, List<T> dataItems)
    {
        if (currNode == null) return;
        InOrder(currNode.Left, dataItems);
        dataItems.Add(currNode.Value);
        InOrder(currNode.Right, dataItems);
    }

    private void PostOrder(BstNode<T>? currNode, List<T> dataItems)
    {
        if (currNode == null) return;
        PostOrder(currNode.Left, dataItems);
        PostOrder(currNode.Right, dataItems);
        dataItems.Add(currNode.Value);
    }

    public List<T> PrintPreOrder()
    {
        var dataItems = new List<T>();
        PreOrder(_root, dataItems);
        return dataItems;
    }

    public List<T> PrintInOrder()
    {
        var dataItems = new List<T>();
        InOrder(_root, dataItems);
        return dataItems;
    }

    public List<T> PrintPostOrder()
    {
        var dataItems = new List<T>();
        PostOrder(_root, dataItems);
        return dataItems;
    }

    public void Remove(T data)
    {
    }

    private int Height(BstNode<T>? currNode)
    {
        if (currNode == null)
        {
            return -1;
        }
        return Math.Max(Height(currNode.Left), Height(currNode.Right)) + 1;
    }

    public int Height()
    {
        return Height(this._root);
    }
}