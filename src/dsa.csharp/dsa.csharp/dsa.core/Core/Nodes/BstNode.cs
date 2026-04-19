namespace dsa.core.Core.Nodes;

public class BstNode<T>(T value)
    where T : IComparable<T>
{
    public BstNode<T>? Left { get; set; } = null;
    public BstNode<T>? Right { get; set; } = null;
    public T Value { get; set; } = value;
    
    public BstNode<T>? Parent { get; set; } = null;
}