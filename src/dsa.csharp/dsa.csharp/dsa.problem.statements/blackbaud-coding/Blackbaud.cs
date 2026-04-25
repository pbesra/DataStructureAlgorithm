namespace dsa.problem.statements.blackbaud_coding;

public class Blackbaud
{
    // Remove all couple char where first char is a letter and second char is a '-'
    public void RemoveSpecialCharacters(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (char.IsLetter(c))
            {
                stack.Push(c);
            }
            else if(stack.Count > 0 && c == '-')
            {
                stack.Pop();
            }
        }

        var res = stack.Reverse().ToArray();
        Console.WriteLine(res);
    }
}