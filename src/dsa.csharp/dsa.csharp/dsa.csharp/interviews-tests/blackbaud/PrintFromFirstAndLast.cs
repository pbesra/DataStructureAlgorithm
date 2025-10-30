var print = new PrintFromFirstAndLast();
var input = print.Input();
print.Output(input.Count, input);

public class PrintFromFirstAndLast
{
    public List<int> Input() => new() { 1, 9, 4, 5, 2, 8 };

    public void Output(int n, List<int> list)
    {
        Stack<int> stack = new();
        int left = 0, right = n - 1;
        while (left <= right)
        {
            stack.Push(list[left++]);
            if (left <= right) stack.Push(list[right--]);
        }

        while (stack.Count > 0)
            Console.Write(stack.Pop());
    }
}