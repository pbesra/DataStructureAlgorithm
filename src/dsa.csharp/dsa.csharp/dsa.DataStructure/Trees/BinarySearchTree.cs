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
            currNode.Left.Parent = currNode;
        }
        else
        {
            currNode.Right = AddNode(data, currNode.Right);
            currNode.Right.Parent = currNode;
        }
        return currNode;
    }

    private void PreOrder(BstNode<T>? currNode, List<T> dataItems)
    {
        if (currNode == null) return;
        Console.WriteLine(currNode.Value);
        Console.WriteLine(currNode.Parent);
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

    private int Height(BstNode<T>? currNode)
    {
        if (currNode == null)
        {
            return -1;
        }
        return Math.Max(Height(currNode.Left), Height(currNode.Right)) + 1;
    }

    public void Remove(T data)
    {
        this.RemoveNode(this._root, data);
    }

    private BstNode<T> FindMaxNode(BstNode<T> node)
    {
        while (node.Right != null)
        {
            node = node.Right;
        }
        return node;
    }
    
    private BstNode<T> RemoveNode(BstNode<T> node, T dataItem)
    {
        if (node == null)
        {
            return null;
        }
        else if (node.Value.CompareTo(dataItem) == 0)
        {
            // It is a leaf node
            if (node.Left == null &&  node.Right == null)
            {
                return null;
            }
            // It has left child only
            if (node.Right == null)
            {
                return node.Left;
            }
            // It has right child only
            if (node.Left == null)
            {
                return node.Right;
            }
            // It has both child
            
            BstNode<T> predecessor = FindMaxNode(node.Left);
            node.Value = predecessor.Value;
            node.Left=RemoveNode(node.Left, predecessor.Value);

        }
        else if (dataItem.CompareTo(node.Value) <= 0)
        {
            node.Left=RemoveNode(node.Left, dataItem);
        }
        else if (dataItem.CompareTo(node.Value) > 0)
        {
            node.Right=RemoveNode(node.Right, dataItem);
        }

        return node;
    }

    public int Height()
    {
        return Height(this._root);
    }
}