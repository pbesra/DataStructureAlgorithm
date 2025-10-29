using dsa.csharp.interviews_tests.blackbaud;

namespace dsa.csharp;

public class Program
{
    public static void Main(string[] args)
    {
        var res = new PrintFromFirstAndLast();
        res.Output(res.Input().Count, res.Input());
    }
}
