namespace dsa.DataStructure.Trees;

public class TrieTree
{
    private TrieNode _root;

    public void Add(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return;
        }
        var currentNode = _root;
        if (currentNode == null)
        {
            currentNode = new TrieNode(word[0]);
             _root = currentNode;
        }
        foreach (var ch in word)
        {
            
        }
    }
}

public class TrieNode
{
    public char Value { get; set; }
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode(char value)
    {
        Value = value;
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}