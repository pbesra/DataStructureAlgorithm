namespace dsa.csharp.interviews_tests.blackbaud;

public class PrintFromFirstAndLast
{
    public List<int> Input()
    {
        return new List<int> { 1, 9, 4, 5, 2 , 8};
    }

    public void Output(int n, List<int> list)
    {
        Stack<int> stack = new Stack<int>();
        int left = 0;
        int right = n-1;
        while (left<=right)
        {
            stack.Push(list[left]);
            left++;
            if (left<=right)
            {
                stack.Push(list[right]);
                right--;
            }
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }
    }
}