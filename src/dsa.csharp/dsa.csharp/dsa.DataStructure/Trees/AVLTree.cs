using dsa.core.Core.Nodes;

namespace dsa.DataStructure.Trees;

public class AVLTree<T> where T : IComparable<T>
{
    private BstNode<T> _root;

    public BstNode<T> Root
    {
        get { return _root;} 
        private set{ _root = value; }  
    }

    public BstNode<T> LeftRotate(BstNode<T> currNode)
    {
        var rightTree = currNode.Right;
        var rightLeft = rightTree.Left;
        currNode.Right = rightLeft;
        rightTree.Left = currNode;
        return rightTree;
    }
    
    public BstNode<T> RightRotate(BstNode<T> currNode)
    {
        var leftTree=currNode.Left;
        var leftRight = leftTree.Right;
        currNode.Left = leftRight;
        leftTree.Right = currNode;
        return leftTree;
    }

    public int GetBalanceFactor(BstNode<T> currNode)
    {
        return currNode==null
            ? 0
            : GetHeight(currNode.Left)-GetHeight(currNode.Right);
    }

    private bool Contains(BstNode<T> currNode, T data)
    {
        if (currNode == null)
        {
            return false;
        }

        if (data.CompareTo(currNode.Value) == 0)
        {
            return true;
        }
        else if (data.CompareTo(currNode.Value) < 0)
        {
            return Contains(currNode.Left, data);
        }
        return Contains(currNode.Right, data);
    }
    
    public bool Contains(T data)
    {
        return this.Contains(_root, data);
    }

    private BstNode<T> RemoveNode(BstNode<T> currNode, T data)
    {
        if (currNode == null)
        {
            return currNode;
        }

        if (data.CompareTo(currNode.Value) == 0)
        {
            if (currNode.Left == null && currNode.Right == null)
            {
                return null;
            }

            if (currNode.Right == null)
            {
                return currNode.Left;
            }

            if (currNode.Left == null)
            {
                return currNode.Right;
            }
            
            // find right node of the current node
            var rightNode=currNode.Left;
            
            // find minimum node in the rightNode Tree => traverse to the left until null
            while (rightNode!=null & rightNode.Right!=null)
            {
                rightNode = rightNode.Right;
            }
            // rewrite the value => erasing the value=> value deletion
            currNode.Value = rightNode.Value;
            
            // call the method again
            currNode.Left=RemoveNode(rightNode, rightNode.Value);

        }
        else if (data.CompareTo(currNode.Value) < 0)
        {
            currNode.Left=RemoveNode(currNode.Left, data);
        }
        else if (data.CompareTo(currNode.Value) > 0)
        {
            currNode.Right=RemoveNode(currNode.Right, data);
        }
        
        var balanceFactor = GetBalanceFactor(currNode); // Height(leftTree)-Height(rightTree)
        
        // LL - case
        //                o
        //              /
        //            o
        //          /
        //        o
        if (balanceFactor > 1 && GetBalanceFactor(currNode.Left) >= 0)
        {
            return this.RightRotate(currNode);
        }
        
        // RR - case
        //    o        
        //      \         
        //        o     
        //          \ 
        //            o

        if (balanceFactor < -1 && GetBalanceFactor(currNode.Right) >= 0)
        {
            return LeftRotate(currNode);
        }
        
        // LR - case
        //        
        //          o
        //         /  
        //        o
        //         \
        //           o

        if (balanceFactor > 1 && GetBalanceFactor(currNode.Left) < 0)
        {
            currNode.Left = LeftRotate(currNode.Left);
            return RightRotate(currNode);
        }
        
        // RL - case
        //        
        //     o
        //       \     
        //         o
        //        /
        //      o     

        if (balanceFactor < -1 && GetBalanceFactor(currNode.Right) >0)
        {
            currNode.Right = RightRotate(currNode.Right);
            return LeftRotate(currNode);
        }
        
        return currNode;
    }

    public void RemoveData(T data)
    {
        _root = this.RemoveNode(_root, data);
    }

    private BstNode<T> Balance(BstNode<T> currNode)
    {
        var balanceFactor = GetBalanceFactor(currNode); // Height(leftTree)-Height(rightTree)
        
        // LL - case
        //                o
        //              /
        //            o
        //          /
        //        o
        if (balanceFactor > 1 && GetBalanceFactor(currNode.Left) >= 0)
        {
            return this.RightRotate(currNode);
        }
        
        // RR - case
        //    o        
        //      \         
        //        o     
        //          \ 
        //            o

        if (balanceFactor < -1 && GetBalanceFactor(currNode.Right) >= 0)
        {
            return LeftRotate(currNode);
        }
        
        // LR - case
        //        
        //          o
        //         /  
        //        o
        //         \
        //           o

        if (balanceFactor > 1 && GetBalanceFactor(currNode.Left) < 0)
        {
            currNode.Left = LeftRotate(currNode.Left);
            return RightRotate(currNode);
        }
        
        // RL - case
        //        
        //     o
        //       \     
        //         o
        //        /
        //      o     

        if (balanceFactor < -1 && GetBalanceFactor(currNode.Right) >0)
        {
            currNode.Right = RightRotate(currNode.Right);
            return LeftRotate(currNode);
        }

        return currNode;
    }

    public BstNode<T> AddNode(T data, BstNode<T> currNode)
    {
        if (currNode == null)
        {
            return new BstNode<T>(data);
        }else if (data.CompareTo(currNode.Value) < 0)
        {
            currNode.Left = AddNode(data, currNode.Left);
        }else if (data.CompareTo(currNode.Value) >= 0)
        {
            currNode.Right = AddNode(data, currNode.Right);
        }
        var balanceFactor = GetBalanceFactor(currNode); // Height(leftTree)-Height(rightTree)
        
        // LL - case
        //                o
        //              /
        //            o
        //          /
        //        o
        if (balanceFactor > 1 && data.CompareTo(currNode.Left.Value) < 0)
        {
            return this.RightRotate(currNode);
        }
        
        // RR - case
        //    o        
        //      \         
        //        o     
        //          \ 
        //            o

        if (balanceFactor < -1 && data.CompareTo(currNode.Right.Value) > 0)
        {
            return LeftRotate(currNode);
        }
        
        // LR - case
        //        
        //          o
        //         /  
        //        o
        //         \
        //           o

        if (balanceFactor > 1 && data.CompareTo(currNode.Left.Value) > 0)
        {
            currNode.Left = LeftRotate(currNode.Left);
            return RightRotate(currNode);
        }
        
        // RL - case
        //        
        //     o
        //       \     
        //         o
        //        /
        //      o     

        if (balanceFactor < -1 && data.CompareTo(currNode.Right.Value) < 0)
        {
            currNode.Right = RightRotate(currNode.Right);
            return LeftRotate(currNode);
        }

        return currNode;
    }
    
    public void Add(T data)
    {
        _root = AddNode(data, _root);
    }

    public void Remove(T data)
    {
        
    }

    private int GetHeight(BstNode<T> currNode)
    {
        if (currNode == null)
        {
            return -1;
        }
        return Math.Max(GetHeight(currNode.Left), GetHeight(currNode.Right))+1;
    }

    public int GetHeight()
    {
        return GetHeight(_root);
    }
}